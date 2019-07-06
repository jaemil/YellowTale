using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace YellowTale
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphicsDeviseManager;
        SpriteBatch spriteBatch;
        MouseState mouseState;
        MouseState lastmouseState;
        KeyboardState keyState;
        Vector2 scaledMausPosition;

        Matrix bildschirmScaling;
        Matrix mausScaling;

        #region Objekte
        Player _player = new Player();
        EnemyManager enemyManager = new EnemyManager();
        ObjectManager objectManager = new ObjectManager();
        NPCManager nPCManager = new NPCManager();
        ParticleManager particleManager = new ParticleManager();
        AnimationManager animationManager = new AnimationManager();
        AbilityManager abilityManager = new AbilityManager();
        WeaponManager weaponManager = new WeaponManager();
        BulletCollision bulletCollision = new BulletCollision();
        MainMenu _mainmenu;
        PauseMenu _pausemenu;
        GameOver _gameover;
        Map_Changer _mapChanger = new Map_Changer("Haus");
        Movement movement = new Movement();
        Collision collision = new Collision();
        HUD hud = new HUD();
        SaveLoad _saveLoad = new SaveLoad();
        

        Layer drawlayer1 = new Layer();
        Layer drawlayer2 = new Layer();
        Layer drawlayer3 = new Layer();
        Layer background = new Layer();
        #endregion

        enum GameState { menuScreen, gameScreen, pauseScreen, mapChange, gameOver }
        GameState currentState = GameState.menuScreen; //menuScreen als Standard festlegen

        enum Spieler { archer, wizard, knight }
        Spieler currentSpieler = Spieler.archer;
        string currentSpielerstring = "archer";

        int savegame = 0;

        Song songMenu;
        Song songBoss;
        Song songStandard;


        bool ignoreCooldown = false;
        public float musicVolume;

        public int ResolutionWidth;
        public int ResolutionHeight;
        public string windowMode;

        bool newMap = true;

        #region Cooldown

        float clickCooldown = 100;
        float pauseCooldown = 500;

        #endregion


        SpriteFont font;

        Texture2D pause;

        public Game1()
        {
            graphicsDeviseManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            // TODO: Add your initialization logic here            
            IsMouseVisible = true;
            Mouse.SetCursor(MouseCursor.Wait);

            //Größe

            if (_saveLoad.configLoad()[0] == "auto")
            {
                ResolutionWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                ResolutionHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            }
            else
            {
                ResolutionWidth = Convert.ToInt32(_saveLoad.configLoad()[0]);
                ResolutionHeight = Convert.ToInt32(_saveLoad.configLoad()[1]);
            }

            if (_saveLoad.configLoad()[2] == "window")
            {
                graphicsDeviseManager.IsFullScreen = false;
                Window.IsBorderless = false;
                windowMode = _saveLoad.configLoad()[2];
            }
            else if (_saveLoad.configLoad()[2] == "fullscreen")
            {
                graphicsDeviseManager.IsFullScreen = true;
                Window.IsBorderless = true;
                windowMode = _saveLoad.configLoad()[2];
            }
            else if (_saveLoad.configLoad()[2] == "borderless")
            {
                windowMode = _saveLoad.configLoad()[2];
                graphicsDeviseManager.IsFullScreen = false;
                Window.IsBorderless = true;
                Window.Position = new Point(0, 0);
            }

            musicVolume = float.Parse(_saveLoad.configLoad()[3]);

            graphicsDeviseManager.PreferredBackBufferWidth = ResolutionWidth;
            graphicsDeviseManager.PreferredBackBufferHeight = ResolutionHeight;
            graphicsDeviseManager.HardwareModeSwitch = false;
            Window.Title = "Yellow Tale";

            bildschirmScaling = Matrix.CreateScale((float)graphicsDeviseManager.PreferredBackBufferWidth / 1920, (float)(graphicsDeviseManager.PreferredBackBufferHeight) / (1080 + 8), 0);
            mausScaling = Matrix.CreateScale((float)1920 / graphicsDeviseManager.PreferredBackBufferWidth, (float)(1080 + 8) / (graphicsDeviseManager.PreferredBackBufferHeight), 0);
            drawlayer1.scaling = bildschirmScaling;
            drawlayer2.scaling = bildschirmScaling;
            drawlayer3.scaling = bildschirmScaling;
            background.scaling = bildschirmScaling;

            graphicsDeviseManager.ApplyChanges();

            _mainmenu = new MainMenu(musicVolume, _saveLoad.configLoad()[4]);
            _pausemenu = new PauseMenu(musicVolume, _saveLoad.configLoad()[4]);
            _gameover = new GameOver(_saveLoad.configLoad()[4]);

            base.Initialize();
        }
        Texture2D texture;

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("MedievalPixelart");

            songMenu = Content.Load<Song>("music/Menu");
            songBoss = Content.Load<Song>("music/Boss");
            songStandard = Content.Load<Song>("music/Standard");

            MediaPlayer.Play(songMenu);
            MediaPlayer.Volume = musicVolume;
            MediaPlayer.IsRepeating = true;

            pause = this.Content.Load<Texture2D>("HUD/pause");

            texture = this.Content.Load<Texture2D>("texture");

            #region ObjectManager
            objectManager.coinFlip = this.Content.Load<Texture2D>("PickUpItems/coinflip");
            objectManager.xpanimation = this.Content.Load<Texture2D>("PickUpItems/xpanimation");

            objectManager.healthpotionbig1 = this.Content.Load<Texture2D>("PickUpItems/apple_big");
            objectManager.healthpotionbig2 = this.Content.Load<Texture2D>("PickUpItems/fish_big");
            objectManager.healthpotionsmall1 = this.Content.Load<Texture2D>("PickUpItems/apple_small");
            objectManager.healthpotionsmall2 = this.Content.Load<Texture2D>("PickUpItems/fish_small");

            objectManager.hourglass = this.Content.Load<Texture2D>("PickUpItems/hourglass");

            objectManager.chestclosed = this.Content.Load<Texture2D>("InteractiveObjects/chestclosed");
            objectManager.chestopen = this.Content.Load<Texture2D>("InteractiveObjects/chestopen");
            objectManager.trap = this.Content.Load<Texture2D>("InteractiveObjects/trapani");
            objectManager.dynamit = this.Content.Load<Texture2D>("InteractiveObjects/dynamit");

            objectManager.ArrowTrapUpLoaded = this.Content.Load<Texture2D>("InteractiveObjects/Turret_loaded_up");
            objectManager.ArrowTrapUpUnloaded = this.Content.Load<Texture2D>("InteractiveObjects/Turret_unloaded_up");

            objectManager.ArrowTrapRightLoaded = this.Content.Load<Texture2D>("InteractiveObjects/Turret_loaded_right");
            objectManager.ArrowTrapRightUnloaded = this.Content.Load<Texture2D>("InteractiveObjects/Turret_unloaded_right");


            objectManager.dynamitZerstört1 = this.Content.Load<Texture2D>("InteractiveObjects/dynamitzerstört1");
            objectManager.dynamitZerstört2 = this.Content.Load<Texture2D>("InteractiveObjects/dynamitzerstört2");
            objectManager.dynamitZerstört3 = this.Content.Load<Texture2D>("InteractiveObjects/dynamitzerstört3");

            objectManager.dynamitbullet = this.Content.Load<Texture2D>("Projectile/bullet");
            objectManager.arrow = this.Content.Load<Texture2D>("Projectile/arrowBig");
            #endregion

            #region ParticleManager
            particleManager.StandardParticle = this.Content.Load<Texture2D>("Particle/hitparticle");
            particleManager.Font = Content.Load<SpriteFont>("MedievalPixelart");
            #endregion

            #region EnemyManager
            enemyManager.FillSmall = this.Content.Load<Texture2D>("enemies/fillSmall");
            enemyManager.FrameSmall = this.Content.Load<Texture2D>("enemies/frameSmall");
            enemyManager.FillMiddle = this.Content.Load<Texture2D>("enemies/fillMiddle");
            enemyManager.FrameMiddle = this.Content.Load<Texture2D>("enemies/frameMiddle");
            enemyManager.FillBig = this.Content.Load<Texture2D>("enemies/fillBig");
            enemyManager.FrameBig = this.Content.Load<Texture2D>("enemies/frameBig");
            enemyManager.Shadow = this.Content.Load<Texture2D>("Particle/Schatten");

            enemyManager.OrkBigIdle = this.Content.Load<Texture2D>("enemies/OgreBig_idle");
            enemyManager.OrkBigRun = this.Content.Load<Texture2D>("enemies/OgreBig_run");
            enemyManager.OrkSmallIdle = this.Content.Load<Texture2D>("enemies/OrcSmall_idle");
            enemyManager.OrkSmallRun = this.Content.Load<Texture2D>("enemies/OrcSmall_run");
            enemyManager.DemonBigIdle = this.Content.Load<Texture2D>("Enemies/DemonBig_idle");
            enemyManager.DemonBigRun = this.Content.Load<Texture2D>("Enemies/DemonBig_run");
            enemyManager.IceZombie1Idle = this.Content.Load<Texture2D>("Enemies/IceZombie1_idle");
            enemyManager.IceZombie1Run = this.Content.Load<Texture2D>("Enemies/IceZombie1_run");
            enemyManager.IceZombie2Idle = this.Content.Load<Texture2D>("Enemies/IceZombie2_idle");
            enemyManager.IceZombie2Run = this.Content.Load<Texture2D>("Enemies/IceZombie2_run");
            enemyManager.GoblinIdle = this.Content.Load<Texture2D>("Enemies/Goblin_idle");
            enemyManager.GoblinRun = this.Content.Load<Texture2D>("Enemies/Goblin_run");
            enemyManager.ZombieBigIdle = this.Content.Load<Texture2D>("Enemies/ZombieBig_idle");
            enemyManager.ZombieSmallIdle = this.Content.Load<Texture2D>("Enemies/ZombieSmall_idle");
            enemyManager.ZombieSmallRun = this.Content.Load<Texture2D>("Enemies/ZombieSmall_run");
            enemyManager.ZombieTinyIdle = this.Content.Load<Texture2D>("Enemies/ZombieTiny_idle");
            enemyManager.ZombieTinyRun = this.Content.Load<Texture2D>("Enemies/ZombieTiny_run");
            enemyManager.WogolIdle = this.Content.Load<Texture2D>("Enemies/Wogol_idle");
            enemyManager.WogolRun = this.Content.Load<Texture2D>("Enemies/Wogol_run");
            enemyManager.SwampyIdle = this.Content.Load<Texture2D>("Enemies/Swampy_idle");
            enemyManager.SwampyRun = this.Content.Load<Texture2D>("Enemies/Swampy_run");
            enemyManager.NecromancerIdle = this.Content.Load<Texture2D>("Enemies/Necromancer_idle");
            enemyManager.NecromancerRun = this.Content.Load<Texture2D>("Enemies/Necromancer_run");
            enemyManager.MuddyIdle = this.Content.Load<Texture2D>("Enemies/Muddy_idle");
            enemyManager.MuddyRun = this.Content.Load<Texture2D>("Enemies/Muddy_run");
            enemyManager.ImpIdle = this.Content.Load<Texture2D>("Enemies/Imp_idle");
            enemyManager.ImpRun = this.Content.Load<Texture2D>("Enemies/Imp_run");
            enemyManager.OrcMaskedIdle = this.Content.Load<Texture2D>("Enemies/OrcMasked_idle");
            enemyManager.OrcMaskedRun = this.Content.Load<Texture2D>("Enemies/OrcMasked_run");
            enemyManager.SkeletonIdle = this.Content.Load<Texture2D>("Enemies/Skeleton_idle");
            enemyManager.SkeletonRun = this.Content.Load<Texture2D>("Enemies/Skeleton_run");
            enemyManager.ShamanIdle = this.Content.Load<Texture2D>("Enemies/Shaman_idle");
            enemyManager.ShamanIdle = this.Content.Load<Texture2D>("Enemies/Shaman_run");
            enemyManager.ChortIdle = this.Content.Load<Texture2D>("Enemies/Chort_idle");

            enemyManager.EggCrack = this.Content.Load<Texture2D>("Enemies/crack");
            enemyManager.EggCracking = this.Content.Load<Texture2D>("Enemies/cracking animation");
            enemyManager.EggFlap = this.Content.Load<Texture2D>("Enemies/flap animation");

            enemyManager.YetiCharge = this.Content.Load<Texture2D>("Enemies/yeti charge animation");
            enemyManager.YetiIdle = this.Content.Load<Texture2D>("Enemies/yeti idle animation");

            enemyManager.DemonIdle = this.Content.Load<Texture2D>("Enemies/Demon_idle");
            enemyManager.DemonSword = this.Content.Load<Texture2D>("Enemies/Demon Sword");


            enemyManager.Bullet = this.Content.Load<Texture2D>("Projectile/arrow");
            enemyManager.Knife = this.Content.Load<Texture2D>("Projectile/Knife");
            enemyManager.Arrow = this.Content.Load<Texture2D>("Projectile/arrowBig");
            enemyManager.Bow = this.Content.Load<Texture2D>("Weapons/bow");
            enemyManager.Fireball = this.Content.Load<Texture2D>("Projectile/fireball");

            enemyManager.fireball = this.Content.Load<Texture2D>("Projectile/fireball");
            enemyManager.fireball2 = this.Content.Load<Texture2D>("Projectile/fireball2");
            enemyManager.fireball3 = this.Content.Load<Texture2D>("Projectile/fireball3");
            enemyManager.fireball4 = this.Content.Load<Texture2D>("Projectile/fireball4");
            enemyManager.snowball = this.Content.Load<Texture2D>("Projectile/snowball");

            enemyManager.demonshot1 = this.Content.Load<Texture2D>("Projectile/demon shot 1");
            enemyManager.demonshot2ani = this.Content.Load<Texture2D>("Projectile/demon shot 2 animation");
            enemyManager.demonshot3 = this.Content.Load<Texture2D>("Projectile/demon shot 3");
            enemyManager.iceshard = this.Content.Load<Texture2D>("Projectile/iceshard");

            #endregion

            #region WeaponManager
            weaponManager.bow = this.Content.Load<Texture2D>("Weapons/bow");
            weaponManager.magicstaff = this.Content.Load<Texture2D>("Weapons/magicstaff");
            weaponManager.sword = this.Content.Load<Texture2D>("Weapons/sword");
            weaponManager.swordburn = this.Content.Load<Texture2D>("Weapons/swordburning");
            #endregion

            #region NPCManager

            nPCManager.shopNPC = this.Content.Load<Texture2D>("NPC/shopNPC");
            nPCManager.tutorialNPC = this.Content.Load<Texture2D>("NPC/tutorialNPC");
            nPCManager.font = Content.Load<SpriteFont>("MedievalPixelart");

            #endregion

            #region Mainmenu
            _mainmenu.ButtonTexture = this.Content.Load<Texture2D>("Hud/button");
            _mainmenu.arrowLeft = this.Content.Load<Texture2D>("HUD/arrow_left");
            _mainmenu.arrowRight = this.Content.Load<Texture2D>("HUD/arrow_right");
            _mainmenu.menuBackground = this.Content.Load<Texture2D>("menu");
            _mainmenu.en = this.Content.Load<Texture2D>("language/flags/uk");
            _mainmenu.de = this.Content.Load<Texture2D>("language/flags/german");
            _mainmenu.Trackbar = this.Content.Load<Texture2D>("HUD/trackbar");
            _mainmenu.messageBox = this.Content.Load<Texture2D>("HUD/messagebox");
            _mainmenu.Logo = this.Content.Load<Texture2D>("Yellow Tale_Logo");
            #endregion

            #region Pausemenu
            _pausemenu.ButtonTexture = this.Content.Load<Texture2D>("Hud/button");
            _pausemenu.arrowLeft = this.Content.Load<Texture2D>("HUD/arrow_left");
            _pausemenu.arrowRight = this.Content.Load<Texture2D>("HUD/arrow_right");
            _pausemenu.en = this.Content.Load<Texture2D>("language/flags/uk");
            _pausemenu.de = this.Content.Load<Texture2D>("language/flags/german");
            _pausemenu.Trackbar = this.Content.Load<Texture2D>("HUD/trackbar");
            _pausemenu.messageBox = this.Content.Load<Texture2D>("HUD/messagebox");
            #endregion

            #region GameOver

            _gameover.Button = this.Content.Load<Texture2D>("Hud/button");

            #endregion

            #region Player
            animationManager.ArcherHit = this.Content.Load<Texture2D>("Player/ArcherHit");
            animationManager.ArcherIdle = this.Content.Load<Texture2D>("Player/ArcherIdle");
            animationManager.ArcherMove = this.Content.Load<Texture2D>("Player/ArcherMove");

            animationManager.WizardHit = this.Content.Load<Texture2D>("Player/WizardHit");
            animationManager.WizardIdle = this.Content.Load<Texture2D>("Player/WizardIdle");
            animationManager.WizardMove = this.Content.Load<Texture2D>("Player/WizardMove");

            animationManager.KnightHit = this.Content.Load<Texture2D>("Player/KnightHit");
            animationManager.KnightIdle = this.Content.Load<Texture2D>("Player/KnightIdle");
            animationManager.KnightMove = this.Content.Load<Texture2D>("Player/KnightMove");
            #endregion

            #region HUD
            hud.hpFill = this.Content.Load<Texture2D>("HUD/HP bar colors");
            hud.xpFill = this.Content.Load<Texture2D>("HUD/EXP bar colors");
            hud.hpFrame = this.Content.Load<Texture2D>("HUD/HP bar frame");
            hud.xpFrame = this.Content.Load<Texture2D>("HUD/EXP bar frame");
            hud.coin = this.Content.Load<Texture2D>("HUD/coinflip");

            hud.abilityload = this.Content.Load<Texture2D>("HUD/transparent");

            hud.abilitylocked = this.Content.Load<Texture2D>("HUD/ability locked");


            hud.ability1Archer = this.Content.Load<Texture2D>("HUD/Ability1Archer");
            hud.ability2Archer = this.Content.Load<Texture2D>("HUD/Ability2Archer");
            hud.ability3Archer = this.Content.Load<Texture2D>("HUD/Ability3Archer");

            hud.ability1Wizard = this.Content.Load<Texture2D>("HUD/Ability1Wizard");
            hud.ability2Wizard = this.Content.Load<Texture2D>("HUD/Ability2Wizard");
            hud.ability3Wizard = this.Content.Load<Texture2D>("HUD/Ability3Wizard");

            hud.ability1Knight = this.Content.Load<Texture2D>("HUD/Ability1Knight");
            hud.ability2Knight = this.Content.Load<Texture2D>("HUD/Ability2Knight");
            hud.ability3Knight = this.Content.Load<Texture2D>("HUD/Ability3Knight");

            hud.abilityLevel = this.Content.Load<Texture2D>("HUD/AbilityLevel");

            hud.headArcher = this.Content.Load<Texture2D>("HUD/archer head");
            hud.headWizard = this.Content.Load<Texture2D>("HUD/wizard head");
            hud.headKnight = this.Content.Load<Texture2D>("HUD/knight head");

            hud.borderArcher = Content.Load<Texture2D>("HUD/border");
            hud.borderKnight = Content.Load<Texture2D>("HUD/border");
            hud.borderWizard = Content.Load<Texture2D>("HUD/border");

            hud.crosshair = this.Content.Load<Texture2D>("HUD/crosshair_inactive");
            hud.font = Content.Load<SpriteFont>("MedievalPixelart");
            #endregion

            #region Projektile

            abilityManager.arrow = this.Content.Load<Texture2D>("Projectile/arrow");
            abilityManager.arrowice = this.Content.Load<Texture2D>("Projectile/arrowice");
            abilityManager.arrowtoxic = this.Content.Load<Texture2D>("Projectile/arrowtoxic");
            abilityManager.arrowpierce = this.Content.Load<Texture2D>("Projectile/arrowpierce");
            abilityManager.arrowbig = this.Content.Load<Texture2D>("Projectile/arrowBig");
            abilityManager.fireball = this.Content.Load<Texture2D>("Projectile/fireball");
            abilityManager.fireball2 = this.Content.Load<Texture2D>("Projectile/fireball2");
            abilityManager.fireball3 = this.Content.Load<Texture2D>("Projectile/fireball3");
            abilityManager.fireball4 = this.Content.Load<Texture2D>("Projectile/fireball4");

            #endregion

            #region Background

            for (int i = 0; i < background.texturen.Length; i++)
            {
                background.texturen[i] = this.Content.Load<Texture2D>("Textures/" + i.ToString());
            }

            background.missingtexture = this.Content.Load<Texture2D>("missing_texture");

            #endregion

            #region Layer1

            for (int i = 0; i < drawlayer1.texturen.Length; i++)
            {
                drawlayer1.texturen[i] = this.Content.Load<Texture2D>("Textures/" + i.ToString());
            }

            drawlayer1.missingtexture = this.Content.Load<Texture2D>("missing_texture");

            #endregion

            #region Layer2

            for (int i = 0; i < drawlayer2.texturen.Length; i++)
            {
                drawlayer2.texturen[i] = this.Content.Load<Texture2D>("Textures/" + i.ToString());
            }

            drawlayer2.missingtexture = this.Content.Load<Texture2D>("missing_texture");

            #endregion

            #region Layer3

            for (int i = 0; i < drawlayer3.texturen.Length; i++)
            {
                drawlayer3.texturen[i] = this.Content.Load<Texture2D>("Textures/" + i.ToString());
            }

            drawlayer3.missingtexture = this.Content.Load<Texture2D>("missing_texture");

            #endregion

            #region MapChange
            _mapChanger.blur = Content.Load<Texture2D>("mapChange");
            #endregion

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (mouseState.MiddleButton == ButtonState.Pressed)
            {
                //_player.HpArcher = 100;
                _player.LvlWizard = 10;
            }


            if (clickCooldown <= 100)
            {
                clickCooldown += (float)gameTime.ElapsedGameTime.Milliseconds;
            }

            if (pauseCooldown <= 500)
            {
                pauseCooldown += (float)gameTime.ElapsedGameTime.Milliseconds;
            }

            lastmouseState = mouseState;
            mouseState = Mouse.GetState();//Mouse Position aktualisieren 

            scaledMausPosition.X = mouseState.X * mausScaling.Scale.X;
            scaledMausPosition.Y = mouseState.Y * mausScaling.Scale.Y;

            keyState = Keyboard.GetState();



            if ((clickCooldown >= 100 && mouseState.LeftButton == ButtonState.Pressed && lastmouseState.LeftButton == ButtonState.Released) || ignoreCooldown)
            {
                if (currentState == GameState.menuScreen)
                {
                    clickCooldown = 0;
                    ignoreCooldown = false;
                    _mainmenu.clickCheck(new Point((int)scaledMausPosition.X, (int)scaledMausPosition.Y), this, ResolutionWidth.ToString(), windowMode);
                }
                else if (currentState == GameState.pauseScreen)
                {
                    clickCooldown = 0;
                    ignoreCooldown = false;
                    _pausemenu.clickCheck(new Point((int)scaledMausPosition.X, (int)scaledMausPosition.Y), this, ResolutionWidth.ToString(), windowMode);
                }
                else if (currentState == GameState.gameOver)
                {
                    clickCooldown = 0;
                    ignoreCooldown = false;
                    _gameover.ClickCheck(savegame, new Point((int)scaledMausPosition.X, (int)scaledMausPosition.Y), this);
                }
            }

            MediaPlayer.Volume = musicVolume;


            if (this.IsActive == true)
            {
                #region GameState
                switch (currentState)
                {
                    case GameState.menuScreen:
                        {
                            _mainmenu.update(Convert.ToInt32(currentState));

                            break;
                        }
                    case GameState.gameScreen:
                        {
                            if (keyState.IsKeyDown(Keys.Escape) && pauseCooldown >= 500)
                            {
                                currentState = GameState.pauseScreen;//Wenn gameScreen Aktiv ist, wird currentState zu pauseScreen gewechselt
                                pauseCooldown = 0;
                            }

                            UpdateGameScreen(gameTime);

                            break;
                        }
                    case GameState.pauseScreen:
                        {
                            if (keyState.IsKeyDown(Keys.Escape) && pauseCooldown >= 500)
                            {
                                currentState = GameState.gameScreen;//Wenn pauseScreen Aktiv ist, wird currentState zu gameScreen gewechselt
                                pauseCooldown = 0;
                            }

                            _pausemenu.update(Convert.ToInt32(currentState));

                            break;
                        }
                    case GameState.mapChange:
                        {
                            UpdateMapChange(gameTime);

                            break;
                        }
                    case GameState.gameOver:
                        {
                            _gameover.Update(_saveLoad.configLoad()[4]);
                            break;
                        }
                }

                if (keyState.IsKeyDown(Keys.OemComma))//End Fullscreen
                {
                    graphicsDeviseManager.ToggleFullScreen();
                    graphicsDeviseManager.ApplyChanges();
                }

                #endregion
            }
            // TODO: Add your update logic here

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            if (this.IsActive == true)//Wenn Fenster in Fokus ist.
            {
                switch (currentState)
                {
                    case GameState.menuScreen://Wenn currentState == menuScreen -> Menu soll gezeichnet werden
                        {
                            GraphicsDevice.Clear(Color.Black);
                            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, bildschirmScaling);
                            _mainmenu.draw(Convert.ToInt32(currentState), spriteBatch, font, scaledMausPosition.ToPoint());
                            spriteBatch.End();
                            break;
                        }

                    case GameState.gameScreen://Wenn currentState == gameScreen -> Spiel soll gezeichnet werden
                        {
                            DrawGameScreen(gameTime);

                            break;
                        }
                    case GameState.pauseScreen://Wenn currentState == pauseScreen -> Pause soll gezeichnet werden
                        {
                            DrawGameScreen(gameTime);
                            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, bildschirmScaling);
                            spriteBatch.Draw(pause, new Rectangle(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - pause.Width / 4, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2 - 200, pause.Width / 2, pause.Height / 2), Color.White);
                            _pausemenu.draw(Convert.ToInt32(currentState), spriteBatch, font, scaledMausPosition.ToPoint());
                            spriteBatch.End();
                            break;
                        }
                    case GameState.mapChange:
                        {
                            DrawMapChange(gameTime);
                            break;
                        }
                    case GameState.gameOver:
                        {
                            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, bildschirmScaling);
                            _gameover.Draw(spriteBatch, scaledMausPosition.ToPoint(), font);
                            spriteBatch.End();
                            break;
                        }
                }
            }
        }

        public void UpdateGameScreen(GameTime gameTime)//Wenn GameSreen aktiv ist wird es in Update aufgerufen 
        {

            if (clickCooldown >= 100 && mouseState.LeftButton == ButtonState.Pressed && lastmouseState.LeftButton == ButtonState.Released)
            {
                clickCooldown = 0;
                ignoreCooldown = false;
                nPCManager.clickCheck(ref _player, scaledMausPosition.ToPoint(), this);
            }

            if (enemyManager.lstGegnerRanged.Count == 0 && enemyManager.lstGegnerMelee.Count == 0 && enemyManager.lstBoss.Count == 0)//Map Wechsel wenn alle Gegner entfernt sind
            {
                _mapChanger.checkMapChange(movement.position, movement.playerheight, movement.playerwidth, collision, ref newMap, objectManager, this);
                collision.MapPath = @"Content/Maps/" + _mapChanger.mapName + "/" + "collision.txt";
                background.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "background.txt";
                drawlayer1.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "1.txt";
                drawlayer2.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "2.txt";
                drawlayer3.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "3.txt";
            }


            if (newMap)
            {
                currentState = GameState.mapChange;
            }

            movement.moving(collision);

            objectManager.Update(gameTime, movement.position, _player, (int)currentSpieler, particleManager, abilityManager, this);//Objekte aktualisieren
            abilityManager.UpdateAbilities(gameTime, mouseState, keyState, movement, scaledMausPosition, _player, (int)currentSpieler, enemyManager, weaponManager);//Abilities aktualisieren
            abilityManager.UpdateCooldown(gameTime, Convert.ToInt32(currentSpieler));//Cooldown aktualisieren
            enemyManager.Update(gameTime, movement.position, collision, keyState, movement.speed, objectManager);//Gegner aktualisieren
            weaponManager.Update(scaledMausPosition, movement.position, (int)currentSpieler);//Waffen Position aktualisieren
            particleManager.Update(gameTime);//Partikel aktualisieren
            nPCManager.Update(gameTime, Convert.ToInt32(currentSpieler), _player, (int)_pausemenu.language);//NPCs aktualisieren

            bulletCollision.UpdateBulletCollision(gameTime, abilityManager, objectManager, collision, particleManager, enemyManager, movement, (int)currentSpieler, _player, this);//Schuss Kollision Gegner und Spieler

            base.Update(gameTime);
        }

        public void UpdateMapChange(GameTime gameTime)
        {
            if (newMap && _mapChanger.mapLeft)
            {
                _mapChanger.changePosition(ref movement.position);
                collision.Read_Collision();
                background.ReadLayer();
                drawlayer1.ReadLayer();
                drawlayer2.ReadLayer();
                drawlayer3.ReadLayer();

                //Alle Schüsse Entfernen
                abilityManager.lstAbility.RemoveRange(0, abilityManager.lstAbility.Count);
                enemyManager.lstGegnerShot.RemoveRange(0, enemyManager.lstGegnerShot.Count);//Gegner Schüsse entfernen
                objectManager.lstDynamitArrowTrapBullets.RemoveRange(0, objectManager.lstDynamitArrowTrapBullets.Count);//Dynamit Schüsse entfernen

                objectManager.ObjectDelete();//Dynamit, Trap, Chest entfernen
                nPCManager.NPCDelete();
                enemyManager.EnemyDelete();

                //SpawnObject auf True damit neue Objekte erstellt werden
                background.SpawnObject = true;
                drawlayer1.SpawnObject = true;
                drawlayer2.SpawnObject = true;
                drawlayer3.SpawnObject = true;

                newMap = false;
            }

            //Einsammel Radius der Vorhandenen Objekte(Items) vergrößern
            for (int i = 0; i < objectManager.lstCoin.Count; i++)
            {
                objectManager.lstCoin[i].Radius = 2000;
                objectManager.lstCoin[i].Speed = 20;
                objectManager.lstCoin[i].Collected = true;
            }

            for (int i = 0; i < objectManager.lstExperience.Count; i++)
            {
                objectManager.lstExperience[i].Radius = 2000;
                objectManager.lstExperience[i].Speed = 20;
                objectManager.lstExperience[i].Collected = true;
            }

            for (int i = 0; i < objectManager.lstHealthPotionBig.Count; i++)
            {
                objectManager.lstHealthPotionBig[i].Radius = 2000;
                objectManager.lstHealthPotionBig[i].Speed = 20;
                objectManager.lstHealthPotionBig[i].Collected = true;
            }

            for (int i = 0; i < objectManager.lstHealthPotionSmall.Count; i++)
            {
                objectManager.lstHealthPotionSmall[i].Radius = 2000;
                objectManager.lstHealthPotionSmall[i].Speed = 20;
                objectManager.lstHealthPotionSmall[i].Collected = true;
            }

            objectManager.Update(gameTime, movement.position, _player, (int)currentSpieler, particleManager, abilityManager, this);//Objekte aktualisieren
            particleManager.Update(gameTime);
            weaponManager.Update(new Vector2(movement.position.X + 100, movement.position.Y + 20), movement.position, (int)currentSpieler);//Waffen Position aktualisieren

            _mapChanger.Update(gameTime, this);
        }
        
		public void DrawGameScreen(GameTime gameTime)//Wenn GameSreen aktiv ist wird es in Draw aufgerufen 
        {
            background.draw(spriteBatch, gameTime, objectManager, enemyManager, nPCManager, hud, _player);
            drawlayer1.draw(spriteBatch, gameTime, objectManager, enemyManager, nPCManager, hud, _player);

            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, bildschirmScaling);


            objectManager.Draw(spriteBatch, gameTime);//Coin, XP, Healthpotion zeichnen
            enemyManager.Draw(spriteBatch, gameTime);//Gegner zeichnen
            animationManager.PlayerAnimation(movement.position, scaledMausPosition, (int)currentSpieler, keyState, mouseState, spriteBatch, gameTime);//Spieler zeichnen
            weaponManager.DrawWeapon(spriteBatch, Convert.ToInt32(currentSpieler), gameTime);//Spieler Waffe zeichnen
            abilityManager.DrawAbilities(spriteBatch, gameTime);//Abilities zeichnen
            nPCManager.Draw(spriteBatch, gameTime, scaledMausPosition.ToPoint(), font);

            

            spriteBatch.End();

            drawlayer2.draw(spriteBatch, gameTime, objectManager, enemyManager, nPCManager, hud, _player);
            drawlayer3.draw(spriteBatch, gameTime, objectManager, enemyManager, nPCManager, hud, _player);


            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, bildschirmScaling);
            for (int i = 0; i < abilityManager.lstNoCollision.Count; i++)
            {
                abilityManager.lstNoCollision[i].Draw(spriteBatch, gameTime);//Zeichnet Archer Ability3 einzelner Schuss(GeistPfeil)
            }

            hud.DrawHUD(spriteBatch, gameTime, scaledMausPosition, (int)currentSpieler, abilityManager, _player);//HUD zeichnen
            particleManager.Draw(spriteBatch, gameTime);//Partikel zeichnen

            /*
            if (abilityManager.knightRectangles != null)
            {
        
                if (abilityManager.knightRectangles[1, 0].X + 64 > scaledMausPosition.X && abilityManager.knightRectangles[1, 0].X -32 < scaledMausPosition.X && abilityManager.knightRectangles[1, 0].Y +32 > scaledMausPosition.Y)
                {
                    spriteBatch.Draw(texture, abilityManager.knightRectangles[1, 0], Color.FromNonPremultiplied(2 * 80, 2 * 60, 0, 255));
                }else
                if (abilityManager.knightRectangles[0, 1].X + 32 > scaledMausPosition.X && abilityManager.knightRectangles[0, 1].Y + 48 +32 > scaledMausPosition.Y && abilityManager.knightRectangles[0, 1].Y - 32 < scaledMausPosition.Y)
                {
                    spriteBatch.Draw(texture, abilityManager.knightRectangles[0, 1], Color.FromNonPremultiplied(2 * 80, 2 * 60, 0, 255));
                }else
                if (abilityManager.knightRectangles[2, 1].X <= scaledMausPosition.X && abilityManager.knightRectangles[2, 1].Y + 48 +32 > scaledMausPosition.Y && abilityManager.knightRectangles[2, 1].Y - 32 < scaledMausPosition.Y)
                {
                    spriteBatch.Draw(texture, abilityManager.knightRectangles[2, 1], Color.FromNonPremultiplied(2 * 80, 2 * 60, 0, 255));
                }else
                if (abilityManager.knightRectangles[1, 2].X + 64 > scaledMausPosition.X && abilityManager.knightRectangles[1, 2].X - 32 < scaledMausPosition.X && abilityManager.knightRectangles[1, 2].Y < scaledMausPosition.Y)
                {
                    spriteBatch.Draw(texture, abilityManager.knightRectangles[1, 2], Color.FromNonPremultiplied(2 * 80, 2 * 60, 0, 255));
                }

                if (abilityManager.knightRectangles[2, 0].X <= scaledMausPosition.X && abilityManager.knightRectangles[2, 0].Y + 32 > scaledMausPosition.Y)
                {
                    spriteBatch.Draw(texture, abilityManager.knightRectangles[2, 0], Color.FromNonPremultiplied(2 * 80, 2 * 60, 0, 255));
                }
                else
                if (abilityManager.knightRectangles[0, 2].X + 32 > scaledMausPosition.X && abilityManager.knightRectangles[0, 2].Y < scaledMausPosition.Y)
                {
                    spriteBatch.Draw(texture, abilityManager.knightRectangles[0, 2], Color.FromNonPremultiplied(2 * 80, 2 * 60, 0, 255));
                }
                else
                if (abilityManager.knightRectangles[2, 2].X <= scaledMausPosition.X && abilityManager.knightRectangles[2, 2].Y < scaledMausPosition.Y)
                {
                    spriteBatch.Draw(texture, abilityManager.knightRectangles[2, 2], Color.FromNonPremultiplied(2 * 80, 2 * 60, 0, 255));
                }
                else
                if (abilityManager.knightRectangles[0, 0].X + 32 > scaledMausPosition.X && abilityManager.knightRectangles[0, 0].Y + 32 > scaledMausPosition.Y)
                {
                    spriteBatch.Draw(texture, abilityManager.knightRectangles[0, 0], Color.FromNonPremultiplied(2 * 80, 2 * 60, 0, 255));
                }
            }
            */

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void DrawMapChange(GameTime gameTime)
        {
            background.draw(spriteBatch, gameTime, objectManager, enemyManager, nPCManager, hud, _player);
            drawlayer1.draw(spriteBatch, gameTime, objectManager, enemyManager, nPCManager, hud, _player);

            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, bildschirmScaling);


            objectManager.Draw(spriteBatch, gameTime);//Coin, XP, Healthpotion zeichnen
            enemyManager.Draw(spriteBatch, gameTime);//Gegner zeichnen
            animationManager.PlayerAnimation(movement.position, scaledMausPosition, (int)currentSpieler, keyState, mouseState, spriteBatch, gameTime);//Spieler zeichnen
            weaponManager.DrawWeapon(spriteBatch, Convert.ToInt32(currentSpieler), gameTime);//Spieler Waffe zeichnen
            abilityManager.DrawAbilities(spriteBatch, gameTime);//Abilities zeichnen
            nPCManager.Draw(spriteBatch, gameTime, scaledMausPosition.ToPoint(), font);

            spriteBatch.End();

            drawlayer2.draw(spriteBatch, gameTime, objectManager, enemyManager, nPCManager, hud, _player);
            drawlayer3.draw(spriteBatch, gameTime, objectManager, enemyManager, nPCManager, hud, _player);


            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, bildschirmScaling);


            hud.DrawHUD(spriteBatch, gameTime, scaledMausPosition, (int)currentSpieler, abilityManager, _player);//HUD zeichnen
            particleManager.Draw(spriteBatch, gameTime);//Partikel zeichnen

            _mapChanger.DrawBlur(spriteBatch);

            spriteBatch.End();
        }

        public void Load(int sg)
        {
            if (sg == 1)
            {
                savegame = 1;
                _player.loadPlayer(_saveLoad.load(ref _mapChanger.mapName, ref currentSpielerstring, ref movement.position.X, ref movement.position.Y, 1));
                collision.MapPath = @"Content/Maps/" + _mapChanger.mapName + "/" + "collision.txt";
                background.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "background.txt";
                drawlayer1.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "1.txt";
                drawlayer2.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "2.txt";
                drawlayer3.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "3.txt";
                if (currentSpielerstring == "knight")
                {
                    currentSpieler = Spieler.knight;
                }
                else if (currentSpielerstring == "archer")
                {
                    currentSpieler = Spieler.archer;
                }
                else if (currentSpielerstring == "wizard")
                {
                    currentSpieler = Spieler.wizard;
                }
                currentState = GameState.gameScreen;
            }
            else if (sg == 2)
            {
                savegame = 2;
                _player.loadPlayer(_saveLoad.load(ref _mapChanger.mapName, ref currentSpielerstring, ref movement.position.X, ref movement.position.Y, 2));
                collision.MapPath = @"Content/Maps/" + _mapChanger.mapName + "/" + "collision.txt";
                background.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "background.txt";
                drawlayer1.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "1.txt";
                drawlayer2.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "2.txt";
                drawlayer3.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "3.txt";
                if (currentSpielerstring == "knight")
                {
                    currentSpieler = Spieler.knight;
                }
                else if (currentSpielerstring == "archer")
                {
                    currentSpieler = Spieler.archer;
                }
                else if (currentSpielerstring == "wizard")
                {
                    currentSpieler = Spieler.wizard;
                }
                currentState = GameState.gameScreen;
            }
            else if (sg == 3)
            {
                savegame = 3;
                _player.loadPlayer(_saveLoad.load(ref _mapChanger.mapName, ref currentSpielerstring, ref movement.position.X, ref movement.position.Y, 3));
                collision.MapPath = @"Content/Maps/" + _mapChanger.mapName + "/" + "collision.txt";
                background.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "background.txt";
                drawlayer1.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "1.txt";
                drawlayer2.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "2.txt";
                drawlayer3.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "3.txt";
                if (currentSpielerstring == "knight")
                {
                    currentSpieler = Spieler.knight;
                }
                else if (currentSpielerstring == "archer")
                {
                    currentSpieler = Spieler.archer;
                }
                else if (currentSpielerstring == "wizard")
                {
                    currentSpieler = Spieler.wizard;
                }
                currentState = GameState.gameScreen;
            }

            _mapChanger.mapLoad(movement.position);
            MediaPlayer.Play(songStandard);

            newMap = true;
        }

        public void Save()
        {
            if (savegame == 1)
            {
                _saveLoad.save(_mapChanger.mapName, currentSpielerstring, movement.position.X, movement.position.Y, _player.HpArcher, _player.HpArcherMax, _player.XpArcher, _player.XpArcherMax, _player.LvlArcher,
                    _player.HpKnight, _player.HpKnightMax, _player.XpKnight, _player.XpKnightMax, _player.LvlKnight, _player.HpWizard, _player.HpWizardMax, _player.XpWizard, _player.XpWizardMax, _player.LvlWizard,
                    _player.Coin, _player.ArcherAbility1lvl, _player.ArcherAbility2lvl, _player.ArcherAbility3lvl, _player.WizardAbility1lvl, _player.WizardAbility2lvl, _player.WizardAbility3lvl, _player.KnightAbility1lvl
                    , _player.KnightAbility2lvl, _player.KnightAbility3lvl, 1);
                currentState = GameState.gameScreen;
            }
            else if (savegame == 2)
            {
                _saveLoad.save(_mapChanger.mapName, currentSpielerstring, movement.position.X, movement.position.Y, _player.HpArcher, _player.HpArcherMax, _player.XpArcher, _player.XpArcherMax, _player.LvlArcher,
                    _player.HpKnight, _player.HpKnightMax, _player.XpKnight, _player.XpKnightMax, _player.LvlKnight, _player.HpWizard, _player.HpWizardMax, _player.XpWizard, _player.XpWizardMax, _player.LvlWizard,
                    _player.Coin, _player.ArcherAbility1lvl, _player.ArcherAbility2lvl, _player.ArcherAbility3lvl, _player.WizardAbility1lvl, _player.WizardAbility2lvl, _player.WizardAbility3lvl, _player.KnightAbility1lvl
                    , _player.KnightAbility2lvl, _player.KnightAbility3lvl, 2);
                currentState = GameState.gameScreen;
            }
            else if (savegame == 3)
            {
                _saveLoad.save(_mapChanger.mapName, currentSpielerstring, movement.position.X, movement.position.Y, _player.HpArcher, _player.HpArcherMax, _player.XpArcher, _player.XpArcherMax, _player.LvlArcher,
                    _player.HpKnight, _player.HpKnightMax, _player.XpKnight, _player.XpKnightMax, _player.LvlKnight, _player.HpWizard, _player.HpWizardMax, _player.XpWizard, _player.XpWizardMax, _player.LvlWizard,
                    _player.Coin, _player.ArcherAbility1lvl, _player.ArcherAbility2lvl, _player.ArcherAbility3lvl, _player.WizardAbility1lvl, _player.WizardAbility2lvl, _player.WizardAbility3lvl, _player.KnightAbility1lvl
                    , _player.KnightAbility2lvl, _player.KnightAbility3lvl, 3);
                currentState = GameState.gameScreen;
            }
        }

        public void newGame(int sg, string startKlasse)
        {
            if (sg == 1)
            {
                savegame = 1;
                _saveLoad.save("Haus", startKlasse, 950, 400, 100, 100, 0, 100, 1, 100, 100, 0, 100, 1, 100, 100, 0, 100, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1);
                _player.loadPlayer(_saveLoad.load(ref _mapChanger.mapName, ref currentSpielerstring, ref movement.position.X, ref movement.position.Y, 1));
                collision.MapPath = @"Content/Maps/" + _mapChanger.mapName + "/" + "collision.txt";
                background.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "background.txt";
                drawlayer1.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "1.txt";
                drawlayer2.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "2.txt";
                drawlayer3.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "3.txt";
                if (currentSpielerstring == "archer")//Spieler wechseln
                {
                    currentSpieler = Spieler.archer;
                    currentSpielerstring = "archer";
                    //player = this.Content.Load<Texture2D>("Player/archer");
                    movement.speed = 5;
                }
                else if (currentSpielerstring == "wizard")//Spieler wechseln
                {
                    currentSpieler = Spieler.wizard;
                    currentSpielerstring = "wizard";
                    //player = this.Content.Load<Texture2D>("Player/wizard");
                    movement.speed = 5;
                }
                else if (currentSpielerstring == "knight")//Spieler wechseln
                {
                    currentSpieler = Spieler.knight;
                    currentSpielerstring = "knight";
                    //player = this.Content.Load<Texture2D>("Player/knight_run");
                    movement.speed = 5;
                }
                currentState = GameState.gameScreen;
            }
            else if (sg == 2)
            {
                savegame = 2;
                _saveLoad.save("Haus", startKlasse, 950, 400, 100, 100, 0, 100, 1, 100, 100, 0, 100, 1, 100, 100, 0, 100, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2);
                _player.loadPlayer(_saveLoad.load(ref _mapChanger.mapName, ref currentSpielerstring, ref movement.position.X, ref movement.position.Y, 2));
                collision.MapPath = @"Content/Maps/" + _mapChanger.mapName + "/" + "collision.txt";
                background.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "background.txt";
                drawlayer1.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "1.txt";
                drawlayer2.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "2.txt";
                drawlayer3.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "3.txt";
                if (currentSpielerstring == "archer")//Spieler wechseln
                {
                    currentSpieler = Spieler.archer;
                    currentSpielerstring = "archer";
                    //player = this.Content.Load<Texture2D>("Player/archer");
                    movement.speed = 5;
                }
                else if (currentSpielerstring == "wizard")//Spieler wechseln
                {
                    currentSpieler = Spieler.wizard;
                    currentSpielerstring = "wizard";
                    //player = this.Content.Load<Texture2D>("Player/wizard");
                    movement.speed = 5;
                }
                else if (currentSpielerstring == "knight")//Spieler wechseln
                {
                    currentSpieler = Spieler.knight;
                    currentSpielerstring = "knight";
                    //player = this.Content.Load<Texture2D>("Player/knight_run");
                    movement.speed = 5;
                }
                currentState = GameState.gameScreen;
            }
            else if (sg == 3)
            {
                savegame = 3;
                _saveLoad.save("Haus", startKlasse, 950, 400, 100, 100, 0, 100, 1, 100, 100, 0, 100, 1, 100, 100, 0, 100, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3);
                _player.loadPlayer(_saveLoad.load(ref _mapChanger.mapName, ref currentSpielerstring, ref movement.position.X, ref movement.position.Y, 3));
                collision.MapPath = @"Content/Maps/" + _mapChanger.mapName + "/" + "collision.txt";
                background.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "background.txt";
                drawlayer1.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "1.txt";
                drawlayer2.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "2.txt";
                drawlayer3.path = @"Content/Maps/" + _mapChanger.mapName + "/" + "3.txt";
                if (currentSpielerstring == "archer")//Spieler wechseln
                {
                    currentSpieler = Spieler.archer;
                    currentSpielerstring = "archer";
                    //player = this.Content.Load<Texture2D>("Player/archer");
                    movement.speed = 5;
                }
                else if (currentSpielerstring == "wizard")//Spieler wechseln
                {
                    currentSpieler = Spieler.wizard;
                    currentSpielerstring = "wizard";
                    //player = this.Content.Load<Texture2D>("Player/wizard");
                    movement.speed = 5;
                }
                else if (currentSpielerstring == "knight")//Spieler wechseln
                {
                    currentSpieler = Spieler.knight;
                    currentSpielerstring = "knight";
                    //player = this.Content.Load<Texture2D>("Player/knight_run");
                    movement.speed = 5;
                }
                currentState = GameState.gameScreen;
            }

            MediaPlayer.Play(songStandard);
            _mapChanger.mapLoad(movement.position);
            newMap = true;
        }

        public void resetClickCooldown()
        {
            if (mouseState.LeftButton == ButtonState.Released)
            {
                clickCooldown = 0;
                ignoreCooldown = false;
            }
            else
            {
                clickCooldown = 100;
                ignoreCooldown = true;
            }
        }

        public void graphicChange(int window, string language)
        {
            if (window == 0)//Fullscreen
            {
                Window.IsBorderless = true;
                IsMouseVisible = true;
                graphicsDeviseManager.IsFullScreen = true;
                ResolutionWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                ResolutionHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

                graphicsDeviseManager.PreferredBackBufferWidth = ResolutionWidth;
                graphicsDeviseManager.PreferredBackBufferHeight = ResolutionHeight;

                Window.Position = new Point(0, 0);
                bildschirmScaling = Matrix.CreateScale((float)graphicsDeviseManager.PreferredBackBufferWidth / 1920, (float)(graphicsDeviseManager.PreferredBackBufferHeight) / (1080 + 8), 0);
                drawlayer1.scaling = bildschirmScaling;
                drawlayer2.scaling = bildschirmScaling;
                drawlayer3.scaling = bildschirmScaling;
                background.scaling = bildschirmScaling;
                mausScaling = Matrix.CreateScale((float)1920 / graphicsDeviseManager.PreferredBackBufferWidth, (float)(1080 + 8) / (graphicsDeviseManager.PreferredBackBufferHeight), 0);
                windowMode = "fullscreen";

                _saveLoad.configSave("auto", "auto", "fullscreen", musicVolume, language);
            }
            else if (window == 1)//Fenster
            {
                Window.IsBorderless = false;
                graphicsDeviseManager.IsFullScreen = false;

                graphicsDeviseManager.PreferredBackBufferWidth = ResolutionWidth;
                graphicsDeviseManager.PreferredBackBufferHeight = ResolutionHeight;

                bildschirmScaling = Matrix.CreateScale((float)graphicsDeviseManager.PreferredBackBufferWidth / 1920, (float)(graphicsDeviseManager.PreferredBackBufferHeight) / (1080 + 8), 0);
                drawlayer1.scaling = bildschirmScaling;
                drawlayer2.scaling = bildschirmScaling;
                drawlayer3.scaling = bildschirmScaling;
                background.scaling = bildschirmScaling;
                mausScaling = Matrix.CreateScale((float)1920 / graphicsDeviseManager.PreferredBackBufferWidth, (float)(1080 + 8) / (graphicsDeviseManager.PreferredBackBufferHeight), 0);
                windowMode = "window";

                _saveLoad.configSave(ResolutionWidth.ToString(), ResolutionHeight.ToString(), "window", musicVolume, language);
            }
            else if (window == 2)//Randlos
            {
                graphicsDeviseManager.IsFullScreen = false;
                graphicsDeviseManager.ApplyChanges();
                Window.IsBorderless = true;
                Window.Position = new Point(0, 0);
                graphicsDeviseManager.PreferredBackBufferWidth = ResolutionWidth;
                graphicsDeviseManager.PreferredBackBufferHeight = ResolutionHeight;
                bildschirmScaling = Matrix.CreateScale((float)graphicsDeviseManager.PreferredBackBufferWidth / 1920, (float)(graphicsDeviseManager.PreferredBackBufferHeight) / (1080 + 8), 0);
                drawlayer1.scaling = bildschirmScaling;
                drawlayer2.scaling = bildschirmScaling;
                drawlayer3.scaling = bildschirmScaling;
                background.scaling = bildschirmScaling;
                mausScaling = Matrix.CreateScale((float)1920 / graphicsDeviseManager.PreferredBackBufferWidth, (float)(1080 + 8) / (graphicsDeviseManager.PreferredBackBufferHeight), 0);
                windowMode = "borderless";

                _saveLoad.configSave(ResolutionWidth.ToString(), ResolutionHeight.ToString(), "borderless", musicVolume, language);
            }
            else
            {
            }
            _pausemenu.lang(language);
            graphicsDeviseManager.ApplyChanges();
        }

        public void autoResolution()
        {
            ResolutionWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            ResolutionHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        }

        public void BackMainMenu()
        {
            currentState = GameState.menuScreen;
            _mapChanger.setStart();
            MediaPlayer.Play(songMenu);

        }

        public void changeClass(int classNumber)
        {
            switch (classNumber)
            {
                case 0:
                    currentSpieler = Spieler.archer;
                    currentSpielerstring = "archer";
                    break;
                case 1:
                    currentSpieler = Spieler.knight;
                    currentSpielerstring = "knight";
                    break;
                case 2:
                    currentSpieler = Spieler.wizard;
                    currentSpielerstring = "wizard";
                    break;
                default:
                    break;
            }
        }

        public void changeState(int state)
        {
            switch (state)
            {
                case 1:
                    currentState = GameState.gameScreen;
                    Save();
                    break;
                case 3:
                    currentState = GameState.mapChange;
                    break;
                case 4:
                    currentState = GameState.gameOver;

                    if ((_player.HpArcher + _saveLoad.loadHealth(0, savegame) * 0.1) <= _player.HpArcherMax)
                    {
                        if (savegame == 1)
                        {
                            _saveLoad.saveDead(1, 0, (int)(_saveLoad.loadHealth(0, savegame) * 0.5));
                        }
                        else if (savegame == 2)
                        {
                            _saveLoad.saveDead(1, 0, (int)(_saveLoad.loadHealth(0, savegame) * 0.5));
                        }
                        else if (savegame == 3)
                        {
                            _saveLoad.saveDead(1, 0, (int)(_saveLoad.loadHealth(0, savegame) * 0.5));
                        }
                    }                   

                    break;
                case 5:
                    currentState = GameState.gameOver;

                    if ((_player.HpArcher + _saveLoad.loadHealth(1, savegame) * 0.1) <= _player.HpArcherMax)
                    {
                        if (savegame == 1)
                        {
                            _saveLoad.saveDead(1, 1, (int)(_saveLoad.loadHealth(1, savegame) * 0.5));
                        }
                        else if (savegame == 2)
                        {
                            _saveLoad.saveDead(1, 1, (int)(_saveLoad.loadHealth(1, savegame) * 0.5));
                        }
                        else if (savegame == 3)
                        {
                            _saveLoad.saveDead(1, 1, (int)(_saveLoad.loadHealth(1, savegame) * 0.5));
                        }
                    }

                    break;
                case 6:
                    currentState = GameState.gameOver;

                    if ((_saveLoad.loadHealth(2, savegame) + _saveLoad.loadHealth(2, savegame) * 0.1) <= _player.HpWizardMax)
                    {
                        if (savegame == 1)
                        {
                            _saveLoad.saveDead(1, 2, (int)(_saveLoad.loadHealth(2, savegame) * 0.5));
                        }
                        else if (savegame == 2)
                        {
                            _saveLoad.saveDead(1, 2, (int)(_saveLoad.loadHealth(2, savegame) * 0.5));
                        }
                        else if (savegame == 3)
                        {
                            _saveLoad.saveDead(1, 2, (int)(_saveLoad.loadHealth(2, savegame) * 0.5));
                        }
                    }

                    break;
                case 11:
                    currentState = GameState.gameScreen;
                    break;
                default:
                    break;
            }
        }
    }
}