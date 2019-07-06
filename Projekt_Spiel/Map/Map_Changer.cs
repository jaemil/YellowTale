using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YellowTale
{
    class Map_Changer
    {
        public string mapName;
        Vector2 newPosition;

        public Texture2D blur;

        enum ChangeState { Start, Leave, Enter };

        ChangeState changeState = ChangeState.Start;

        float time = 0;
        int alpha = 255;
        public bool mapLeft = true;

        public Map_Changer()
        {

        }

        public Map_Changer(string loadedmapName)
        {
            mapName = loadedmapName;
        }

        public void checkMapChange(Vector2 playerPosition, int height, int width, Collision _collision, ref bool mapChanged, ObjectManager objectManager, Game1 game)
        {
            newPosition = playerPosition;

            if (mapName == "Haus")
            {
                switch (_collision.MapChangeCheck(ref newPosition, height, width, default(Vector2), default(Vector2), new Vector2(130, 520), new Vector2(953, 266)))
                //_collision.MapChangeCheck(ref newPosition, height, width,      Rechts,           Links,                 Oben,             Unten
                {
                    case 4:
                        mapName = "Stadt";
                        break;
                    default:
                        return;
                }

                mapChanged = true;
                game.changeState(3);

            }
            else if (mapName == "Stadt")
            {
                switch (_collision.MapChangeCheck(ref newPosition, height, width, new Vector2(32, 910), default(Vector2), new Vector2(950, 795), default(Vector2)))
                //_collision.MapChangeCheck(ref newPosition, height, width,      Rechts,           Links,                 Oben,             Unten
                {
                    case 3:
                        mapName = "Haus";
                        break;
                    case 4:
                        mapName = "Eis1";
                        break;
                    case 5:
                        mapName = "Lava1";
                        break;
                    case 6:
                        mapName = "Wald1";
                        break;
                    default:
                        return;
                }

                mapChanged = true;
                game.changeState(3);

            }
            else if (mapName == "Wald1")
            {
                switch (_collision.MapChangeCheck(ref newPosition, height, width, new Vector2(130, 520), default(Vector2), default(Vector2), new Vector2(945, 775)))
                //_collision.MapChangeCheck(ref newPosition, height, width,      Rechts,           Links,                 Oben,             Unten
                {
                    case 3:
                        mapName = "Wald2";
                        break;
                    case 4:
                        mapName = "Haus";
                        break;
                    case 5:
                        mapName = "Stadt";
                        break;
                    default:
                        return;
                }

                mapChanged = true;
                game.changeState(3);

            }
            else if (mapName == "Wald2")
            {
                switch (_collision.MapChangeCheck(ref newPosition, height, width, default(Vector2), default(Vector2), default(Vector2), default(Vector2)))
                //_collision.MapChangeCheck(ref newPosition, height, width,      Rechts,           Links,                 Oben,             Unten
                {
                    case 3:
                        mapName = "Wald3";
                        break;
                    default:
                        return;
                }

                mapChanged = true;
                game.changeState(3);

            }
            else if (mapName == "Wald3")
            {
                switch (_collision.MapChangeCheck(ref newPosition, height, width, default(Vector2), default(Vector2), default(Vector2), default(Vector2)))
                //_collision.MapChangeCheck(ref newPosition, height, width,      Rechts,           Links,                 Oben,             Unten
                {
                    case 5:
                        mapName = "WaldDungeon1";
                        break;
                    default:
                        return;
                }

                mapChanged = true;
                game.changeState(3);

            }
            else if (mapName == "WaldDungeon1")
            {
                switch (_collision.MapChangeCheck(ref newPosition, height, width, default(Vector2), default(Vector2), default(Vector2), default(Vector2)))
                //_collision.MapChangeCheck(ref newPosition, height, width,      Rechts,           Links,                 Oben,             Unten
                {
                    case 3:
                        mapName = "WaldDungeon2";
                        break;
                    default:
                        return;
                }

                mapChanged = true;
                game.changeState(3);

            }
            else if (mapName == "WaldDungeon2")
            {
                switch (_collision.MapChangeCheck(ref newPosition, height, width, default(Vector2), default(Vector2), default(Vector2), default(Vector2)))
                //_collision.MapChangeCheck(ref newPosition, height, width,      Rechts,           Links,                 Oben,             Unten
                {
                    case 5:
                        mapName = "WaldDungeon3";
                        break;
                    default:
                        return;
                }

                mapChanged = true;
                game.changeState(3);

            }
            else if (mapName == "WaldDungeon3")
            {
                switch (_collision.MapChangeCheck(ref newPosition, height, width, new Vector2(130, 520), default(Vector2), default(Vector2), default(Vector2)))
                //_collision.MapChangeCheck(ref newPosition, height, width,      Rechts,           Links,                 Oben,             Unten
                {
                    case 5:
                        mapName = "Stadt";
                        break;
                    default:
                        return;
                }

                mapChanged = true;
                game.changeState(3);

            }
            else if (mapName == "Eis1")
            {
                switch (_collision.MapChangeCheck(ref newPosition, height, width, default(Vector2), default(Vector2), new Vector2(947, 937), default(Vector2)))
                //_collision.MapChangeCheck(ref newPosition, height, width,      Rechts,           Links,                 Oben,             Unten
                {
                    case 3:
                        mapName = "Stadt";
                        break;
                    case 5:
                        mapName = "Eis2";
                        break;
                    default:
                        return;
                }

                mapChanged = true;
                game.changeState(3);

            }
            else if (mapName == "Eis2")
            {
                switch (_collision.MapChangeCheck(ref newPosition, height, width, default(Vector2), default(Vector2), default(Vector2), default(Vector2)))
                //_collision.MapChangeCheck(ref newPosition, height, width,      Rechts,           Links,                 Oben,             Unten
                {
                    case 5:
                        mapName = "Eis3";
                        break;
                    default:
                        return;
                }

                mapChanged = true;
                game.changeState(3);

            }
            else if (mapName == "Eis3")
            {
                switch (_collision.MapChangeCheck(ref newPosition, height, width, new Vector2(1846, 553), default(Vector2), default(Vector2), default(Vector2)))
                //_collision.MapChangeCheck(ref newPosition, height, width,      Rechts,           Links,                 Oben,             Unten
                {
                    case 5:
                        mapName = "EisDungeon1";
                        break;
                    default:
                        return;
                }

                mapChanged = true;
                game.changeState(3);

            }
            else if (mapName == "EisDungeon1")
            {
                switch (_collision.MapChangeCheck(ref newPosition, height, width, default(Vector2), default(Vector2), new Vector2(10, 530), default(Vector2)))
                //_collision.MapChangeCheck(ref newPosition, height, width,      Rechts,           Links,                 Oben,             Unten
                {
                    case 3:
                        mapName = "EisDungeon2";
                        break;
                    default:
                        return;
                }

                mapChanged = true;
                game.changeState(3);

            }
            else if (mapName == "EisDungeon2")
            {
                switch (_collision.MapChangeCheck(ref newPosition, height, width, default(Vector2), default(Vector2), new Vector2(10, 500), default(Vector2)))
                //_collision.MapChangeCheck(ref newPosition, height, width,      Rechts,           Links,                 Oben,             Unten
                {
                    case 5:
                        mapName = "EisDungeon3";
                        break;
                    default:
                        return;
                }

                mapChanged = true;
                game.changeState(3);

            }
            else if (mapName == "EisDungeon3")
            {
                switch (_collision.MapChangeCheck(ref newPosition, height, width, default(Vector2), default(Vector2), new Vector2(947, 937), default(Vector2)))
                //_collision.MapChangeCheck(ref newPosition, height, width,      Rechts,           Links,                 Oben,             Unten
                {
                    case 3:
                        mapName = "Stadt";
                        break;
                    default:
                        return;
                }

                mapChanged = true;
                game.changeState(3);

            }
            else if (mapName == "Lava1")
            {
                switch (_collision.MapChangeCheck(ref newPosition, height, width, new Vector2(32, 680), new Vector2(1735, 515), default(Vector2), default(Vector2)))
                //_collision.MapChangeCheck(ref newPosition, height, width,      Rechts,           Links,                 Oben,             Unten
                {
                    case 5:
                        mapName = "Lava2";
                        break;
                    case 6:
                        mapName = "Stadt";
                        break;
                    default:
                        return;
                }

                mapChanged = true;
                game.changeState(3);

            }
            else if (mapName == "Lava2")
            {
                switch (_collision.MapChangeCheck(ref newPosition, height, width, default(Vector2), default(Vector2), default(Vector2), default(Vector2)))
                //_collision.MapChangeCheck(ref newPosition, height, width,      Rechts,           Links,                 Oben,             Unten
                {
                    case 5:
                        mapName = "Lava3";
                        break;
                    default:
                        return;
                }

                mapChanged = true;
                game.changeState(3);

            }
            else if (mapName == "Lava3")
            {
                switch (_collision.MapChangeCheck(ref newPosition, height, width, new Vector2(57, 554), default(Vector2), default(Vector2), default(Vector2)))
                //_collision.MapChangeCheck(ref newPosition, height, width,      Rechts,           Links,                 Oben,             Unten
                {
                    case 5:
                        mapName = "LavaDungeon1";
                        break;
                    default:
                        return;
                }

                mapChanged = true;
                game.changeState(3);

            }
            else if (mapName == "LavaDungeon1")
            {
                switch (_collision.MapChangeCheck(ref newPosition, height, width, default(Vector2), default(Vector2), default(Vector2), default(Vector2)))
                //_collision.MapChangeCheck(ref newPosition, height, width,      Rechts,           Links,                 Oben,             Unten
                {
                    case 5:
                        mapName = "LavaDungeon2";
                        break;
                    default:
                        return;
                }

                mapChanged = true;
                game.changeState(3);

            }
            else if (mapName == "LavaDungeon2")
            {
                switch (_collision.MapChangeCheck(ref newPosition, height, width, default(Vector2), default(Vector2), default(Vector2), default(Vector2)))
                //_collision.MapChangeCheck(ref newPosition, height, width,      Rechts,           Links,                 Oben,             Unten
                {
                    case 4:
                        mapName = "LavaDungeon3";
                        break;
                    default:
                        return;
                }

                mapChanged = true;
                game.changeState(3);

            }
            else if (mapName == "LavaDungeon3")
            {
                switch (_collision.MapChangeCheck(ref newPosition, height, width, default(Vector2), default(Vector2), new Vector2(1735, 515), default(Vector2)))
                //_collision.MapChangeCheck(ref newPosition, height, width,      Rechts,           Links,                 Oben,             Unten
                {
                    case 3:
                        mapName = "Stadt";
                        break;
                    default:
                        return;
                }

                mapChanged = true;
                game.changeState(3);

            }
        } //3 Oben 4 unten 5 rechts 6 links

        public void changePosition(ref Vector2 posi)
        {
            if (changeState != ChangeState.Start)
            {
                posi = newPosition;
            }
            else
            {
                changeState = ChangeState.Leave;
            }
        }

        public void Update(GameTime gameTime, Game1 game)
        {
            time += gameTime.ElapsedGameTime.Milliseconds;

            if (time >= 8)
            {
                switch (changeState)
                {
                    case ChangeState.Start:

                        if (alpha > 0)
                        {
                            alpha -= 16;
                            if (alpha < 0)
                            {
                                alpha = 0;
                            }
                        }
                        else
                        {
                            changeState = ChangeState.Leave;
                            game.changeState(11);
                            mapLeft = false;
                        }

                        break;
                    case ChangeState.Leave:

                        if (alpha < 255)
                        {
                            alpha += 4;
                            if (alpha > 255)
                            {
                                alpha = 255;
                            }
                        }
                        else
                        {
                            changeState = ChangeState.Enter;
                            mapLeft = true;
                        }

                        break;
                    case ChangeState.Enter:

                        if (alpha > 0)
                        {
                            alpha -= 4;
                            if (alpha < 0)
                            {
                                alpha = 0;
                            }
                        }
                        else
                        {
                            changeState = ChangeState.Leave;
                            game.changeState(1);
                            mapLeft = false;
                        }

                        break;
                    default:
                        break;
                }
            }
        }

        public void DrawBlur(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(blur, Vector2.Zero, new Color(255, 255, 255, alpha));
        }

        public void setStart()
        {
            changeState = ChangeState.Start;
            time = 0;
            alpha = 255;
            mapLeft = true;
        }

        public void mapLoad(Vector2 loadedPos)
        {
            changeState = ChangeState.Start;
            time = 0;
            alpha = 255;
            mapLeft = true;
            newPosition = loadedPos;
        }
    }
}
