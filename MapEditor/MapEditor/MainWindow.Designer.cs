namespace MapEditor
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.splitContainerRight = new System.Windows.Forms.SplitContainer();
            this.splitContainerLeft = new System.Windows.Forms.SplitContainer();
            this.tBTileY = new System.Windows.Forms.TextBox();
            this.tBTileX = new System.Windows.Forms.TextBox();
            this.tBMouseY = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tBMouseX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pBMap = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.nUDTileSetHeight = new System.Windows.Forms.NumericUpDown();
            this.btnOpenTileSet = new System.Windows.Forms.Button();
            this.nUDTileSetWidth = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGridColor = new System.Windows.Forms.Button();
            this.cBShowGrid = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSaveMap = new System.Windows.Forms.Button();
            this.btnOpenMap = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nUDTileHeight = new System.Windows.Forms.NumericUpDown();
            this.nUDTileWidth = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nUDHeight = new System.Windows.Forms.NumericUpDown();
            this.nUDWidth = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxLayers = new System.Windows.Forms.GroupBox();
            this.cBLayer2Visible = new System.Windows.Forms.CheckBox();
            this.cBLayer1Visible = new System.Windows.Forms.CheckBox();
            this.cBLayer3Visible = new System.Windows.Forms.CheckBox();
            this.cBCollisionVisible = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cBBackgroundVisible = new System.Windows.Forms.CheckBox();
            this.rBtnLayer2 = new System.Windows.Forms.RadioButton();
            this.rBtnLayer1 = new System.Windows.Forms.RadioButton();
            this.rBtnLayer3 = new System.Windows.Forms.RadioButton();
            this.rBtnCollision = new System.Windows.Forms.RadioButton();
            this.rBtnBackground = new System.Windows.Forms.RadioButton();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.pBSelectedTile = new System.Windows.Forms.PictureBox();
            this.tBTileID = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ScrollBarTileMap = new System.Windows.Forms.VScrollBar();
            this.pBTileMap = new System.Windows.Forms.PictureBox();
            this.rBtnTileSelect = new System.Windows.Forms.RadioButton();
            this.rBtnPen = new System.Windows.Forms.RadioButton();
            this.rBtnSelect = new System.Windows.Forms.RadioButton();
            this.rBtnEraser = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillAllTilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogOpenMap = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogOpenTileSet = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.colorDialogGridColor = new System.Windows.Forms.ColorDialog();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMaximize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).BeginInit();
            this.splitContainerRight.Panel1.SuspendLayout();
            this.splitContainerRight.Panel2.SuspendLayout();
            this.splitContainerRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).BeginInit();
            this.splitContainerLeft.Panel1.SuspendLayout();
            this.splitContainerLeft.Panel2.SuspendLayout();
            this.splitContainerLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBMap)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTileSetHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTileSetWidth)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTileHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTileWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDWidth)).BeginInit();
            this.groupBoxLayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBSelectedTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBTileMap)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerRight
            // 
            this.splitContainerRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            resources.ApplyResources(this.splitContainerRight, "splitContainerRight");
            this.splitContainerRight.Name = "splitContainerRight";
            // 
            // splitContainerRight.Panel1
            // 
            this.splitContainerRight.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.splitContainerRight.Panel1.Controls.Add(this.splitContainerLeft);
            // 
            // splitContainerRight.Panel2
            // 
            this.splitContainerRight.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.splitContainerRight.Panel2.Controls.Add(this.pictureBox3);
            this.splitContainerRight.Panel2.Controls.Add(this.label15);
            this.splitContainerRight.Panel2.Controls.Add(this.pBSelectedTile);
            this.splitContainerRight.Panel2.Controls.Add(this.tBTileID);
            this.splitContainerRight.Panel2.Controls.Add(this.pictureBox2);
            this.splitContainerRight.Panel2.Controls.Add(this.ScrollBarTileMap);
            this.splitContainerRight.Panel2.Controls.Add(this.pBTileMap);
            this.splitContainerRight.Panel2.Controls.Add(this.rBtnTileSelect);
            this.splitContainerRight.Panel2.Controls.Add(this.rBtnPen);
            this.splitContainerRight.Panel2.Controls.Add(this.rBtnSelect);
            this.splitContainerRight.Panel2.Controls.Add(this.rBtnEraser);
            // 
            // splitContainerLeft
            // 
            this.splitContainerLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            resources.ApplyResources(this.splitContainerLeft, "splitContainerLeft");
            this.splitContainerLeft.Name = "splitContainerLeft";
            // 
            // splitContainerLeft.Panel1
            // 
            this.splitContainerLeft.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.splitContainerLeft.Panel1.Controls.Add(this.tBTileY);
            this.splitContainerLeft.Panel1.Controls.Add(this.tBTileX);
            this.splitContainerLeft.Panel1.Controls.Add(this.tBMouseY);
            this.splitContainerLeft.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainerLeft.Panel1.Controls.Add(this.tBMouseX);
            this.splitContainerLeft.Panel1.Controls.Add(this.label4);
            this.splitContainerLeft.Panel1.Controls.Add(this.label3);
            this.splitContainerLeft.Panel1.Controls.Add(this.pBMap);
            // 
            // splitContainerLeft.Panel2
            // 
            this.splitContainerLeft.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.splitContainerLeft.Panel2.Controls.Add(this.groupBox4);
            this.splitContainerLeft.Panel2.Controls.Add(this.groupBox3);
            this.splitContainerLeft.Panel2.Controls.Add(this.groupBox2);
            this.splitContainerLeft.Panel2.Controls.Add(this.groupBox1);
            this.splitContainerLeft.Panel2.Controls.Add(this.groupBoxLayers);
            // 
            // tBTileY
            // 
            this.tBTileY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tBTileY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tBTileY, "tBTileY");
            this.tBTileY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.tBTileY.Name = "tBTileY";
            // 
            // tBTileX
            // 
            this.tBTileX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tBTileX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tBTileX, "tBTileX");
            this.tBTileX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.tBTileX.Name = "tBTileX";
            // 
            // tBMouseY
            // 
            this.tBMouseY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tBMouseY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tBMouseY, "tBMouseY");
            this.tBMouseY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.tBMouseY.Name = "tBMouseY";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // tBMouseX
            // 
            this.tBMouseX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tBMouseX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tBMouseX, "tBMouseX");
            this.tBMouseX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.tBMouseX.Name = "tBMouseX";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label3.Name = "label3";
            // 
            // pBMap
            // 
            this.pBMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            resources.ApplyResources(this.pBMap, "pBMap");
            this.pBMap.Name = "pBMap";
            this.pBMap.TabStop = false;
            this.pBMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pBMap_Paint);
            this.pBMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pBMap_MouseClick);
            this.pBMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pBMap_MouseMove);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.nUDTileSetHeight);
            this.groupBox4.Controls.Add(this.btnOpenTileSet);
            this.groupBox4.Controls.Add(this.nUDTileSetWidth);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label14);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // nUDTileSetHeight
            // 
            this.nUDTileSetHeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.nUDTileSetHeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nUDTileSetHeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            resources.ApplyResources(this.nUDTileSetHeight, "nUDTileSetHeight");
            this.nUDTileSetHeight.Name = "nUDTileSetHeight";
            this.nUDTileSetHeight.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // btnOpenTileSet
            // 
            this.btnOpenTileSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.btnOpenTileSet.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnOpenTileSet, "btnOpenTileSet");
            this.btnOpenTileSet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.btnOpenTileSet.Name = "btnOpenTileSet";
            this.btnOpenTileSet.UseVisualStyleBackColor = false;
            this.btnOpenTileSet.Click += new System.EventHandler(this.btnOpenTileSet_Click);
            // 
            // nUDTileSetWidth
            // 
            this.nUDTileSetWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.nUDTileSetWidth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nUDTileSetWidth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            resources.ApplyResources(this.nUDTileSetWidth, "nUDTileSetWidth");
            this.nUDTileSetWidth.Name = "nUDTileSetWidth";
            this.nUDTileSetWidth.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label13.Name = "label13";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label12.Name = "label12";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label14.Name = "label14";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnGridColor);
            this.groupBox3.Controls.Add(this.cBShowGrid);
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.label11);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // btnGridColor
            // 
            this.btnGridColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.btnGridColor.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnGridColor, "btnGridColor");
            this.btnGridColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.btnGridColor.Name = "btnGridColor";
            this.btnGridColor.UseVisualStyleBackColor = false;
            this.btnGridColor.Click += new System.EventHandler(this.btnGridColor_Click);
            // 
            // cBShowGrid
            // 
            resources.ApplyResources(this.cBShowGrid, "cBShowGrid");
            this.cBShowGrid.Checked = true;
            this.cBShowGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBShowGrid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.cBShowGrid.Name = "cBShowGrid";
            this.cBShowGrid.UseVisualStyleBackColor = true;
            this.cBShowGrid.CheckedChanged += new System.EventHandler(this.cBShowGrid_CheckedChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label11.Name = "label11";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnSaveMap);
            this.groupBox2.Controls.Add(this.btnOpenMap);
            this.groupBox2.Controls.Add(this.label10);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.btnReset.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.btnReset.Name = "btnReset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSaveMap
            // 
            this.btnSaveMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.btnSaveMap.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnSaveMap, "btnSaveMap");
            this.btnSaveMap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.btnSaveMap.Name = "btnSaveMap";
            this.btnSaveMap.UseVisualStyleBackColor = false;
            this.btnSaveMap.Click += new System.EventHandler(this.btnSaveMap_Click);
            // 
            // btnOpenMap
            // 
            this.btnOpenMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.btnOpenMap.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnOpenMap, "btnOpenMap");
            this.btnOpenMap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.btnOpenMap.Name = "btnOpenMap";
            this.btnOpenMap.UseVisualStyleBackColor = false;
            this.btnOpenMap.Click += new System.EventHandler(this.btnOpenMap_Click);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label10.Name = "label10";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nUDTileHeight);
            this.groupBox1.Controls.Add(this.nUDTileWidth);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.nUDHeight);
            this.groupBox1.Controls.Add(this.nUDWidth);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // nUDTileHeight
            // 
            this.nUDTileHeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.nUDTileHeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nUDTileHeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            resources.ApplyResources(this.nUDTileHeight, "nUDTileHeight");
            this.nUDTileHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDTileHeight.Name = "nUDTileHeight";
            this.nUDTileHeight.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.nUDTileHeight.ValueChanged += new System.EventHandler(this.nUDTileHeight_ValueChanged);
            // 
            // nUDTileWidth
            // 
            this.nUDTileWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.nUDTileWidth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nUDTileWidth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            resources.ApplyResources(this.nUDTileWidth, "nUDTileWidth");
            this.nUDTileWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDTileWidth.Name = "nUDTileWidth";
            this.nUDTileWidth.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.nUDTileWidth.ValueChanged += new System.EventHandler(this.nUDTileWidth_ValueChanged);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label9.Name = "label9";
            // 
            // nUDHeight
            // 
            this.nUDHeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.nUDHeight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nUDHeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            resources.ApplyResources(this.nUDHeight, "nUDHeight");
            this.nUDHeight.Name = "nUDHeight";
            this.nUDHeight.Value = new decimal(new int[] {
            17,
            0,
            0,
            0});
            this.nUDHeight.ValueChanged += new System.EventHandler(this.nUDHeight_ValueChanged);
            // 
            // nUDWidth
            // 
            this.nUDWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.nUDWidth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nUDWidth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            resources.ApplyResources(this.nUDWidth, "nUDWidth");
            this.nUDWidth.Name = "nUDWidth";
            this.nUDWidth.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.nUDWidth.ValueChanged += new System.EventHandler(this.nUDWidth_ValueChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label5.Name = "label5";
            // 
            // groupBoxLayers
            // 
            this.groupBoxLayers.Controls.Add(this.cBLayer2Visible);
            this.groupBoxLayers.Controls.Add(this.cBLayer1Visible);
            this.groupBoxLayers.Controls.Add(this.cBLayer3Visible);
            this.groupBoxLayers.Controls.Add(this.cBCollisionVisible);
            this.groupBoxLayers.Controls.Add(this.label2);
            this.groupBoxLayers.Controls.Add(this.label1);
            this.groupBoxLayers.Controls.Add(this.cBBackgroundVisible);
            this.groupBoxLayers.Controls.Add(this.rBtnLayer2);
            this.groupBoxLayers.Controls.Add(this.rBtnLayer1);
            this.groupBoxLayers.Controls.Add(this.rBtnLayer3);
            this.groupBoxLayers.Controls.Add(this.rBtnCollision);
            this.groupBoxLayers.Controls.Add(this.rBtnBackground);
            this.groupBoxLayers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxLayers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            resources.ApplyResources(this.groupBoxLayers, "groupBoxLayers");
            this.groupBoxLayers.Name = "groupBoxLayers";
            this.groupBoxLayers.TabStop = false;
            // 
            // cBLayer2Visible
            // 
            resources.ApplyResources(this.cBLayer2Visible, "cBLayer2Visible");
            this.cBLayer2Visible.Name = "cBLayer2Visible";
            this.cBLayer2Visible.UseVisualStyleBackColor = true;
            this.cBLayer2Visible.CheckedChanged += new System.EventHandler(this.cBLayer2Visible_CheckedChanged);
            // 
            // cBLayer1Visible
            // 
            resources.ApplyResources(this.cBLayer1Visible, "cBLayer1Visible");
            this.cBLayer1Visible.Name = "cBLayer1Visible";
            this.cBLayer1Visible.UseVisualStyleBackColor = true;
            this.cBLayer1Visible.CheckedChanged += new System.EventHandler(this.cBLayer1Visible_CheckedChanged);
            // 
            // cBLayer3Visible
            // 
            resources.ApplyResources(this.cBLayer3Visible, "cBLayer3Visible");
            this.cBLayer3Visible.Name = "cBLayer3Visible";
            this.cBLayer3Visible.UseVisualStyleBackColor = true;
            this.cBLayer3Visible.CheckedChanged += new System.EventHandler(this.cBLayer3Visible_CheckedChanged);
            // 
            // cBCollisionVisible
            // 
            resources.ApplyResources(this.cBCollisionVisible, "cBCollisionVisible");
            this.cBCollisionVisible.Name = "cBCollisionVisible";
            this.cBCollisionVisible.UseVisualStyleBackColor = true;
            this.cBCollisionVisible.CheckedChanged += new System.EventHandler(this.cBCollisionVisible_CheckedChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cBBackgroundVisible
            // 
            resources.ApplyResources(this.cBBackgroundVisible, "cBBackgroundVisible");
            this.cBBackgroundVisible.Name = "cBBackgroundVisible";
            this.cBBackgroundVisible.UseVisualStyleBackColor = true;
            this.cBBackgroundVisible.CheckedChanged += new System.EventHandler(this.cBBackgroundVisible_CheckedChanged);
            // 
            // rBtnLayer2
            // 
            resources.ApplyResources(this.rBtnLayer2, "rBtnLayer2");
            this.rBtnLayer2.Name = "rBtnLayer2";
            this.rBtnLayer2.TabStop = true;
            this.rBtnLayer2.UseVisualStyleBackColor = true;
            this.rBtnLayer2.CheckedChanged += new System.EventHandler(this.rBtnLayer2_CheckedChanged);
            // 
            // rBtnLayer1
            // 
            resources.ApplyResources(this.rBtnLayer1, "rBtnLayer1");
            this.rBtnLayer1.Name = "rBtnLayer1";
            this.rBtnLayer1.TabStop = true;
            this.rBtnLayer1.UseVisualStyleBackColor = true;
            this.rBtnLayer1.CheckedChanged += new System.EventHandler(this.rBtnLayer1_CheckedChanged);
            // 
            // rBtnLayer3
            // 
            resources.ApplyResources(this.rBtnLayer3, "rBtnLayer3");
            this.rBtnLayer3.Name = "rBtnLayer3";
            this.rBtnLayer3.TabStop = true;
            this.rBtnLayer3.UseVisualStyleBackColor = true;
            this.rBtnLayer3.CheckedChanged += new System.EventHandler(this.rBtnLayer3_CheckedChanged);
            // 
            // rBtnCollision
            // 
            resources.ApplyResources(this.rBtnCollision, "rBtnCollision");
            this.rBtnCollision.Name = "rBtnCollision";
            this.rBtnCollision.TabStop = true;
            this.rBtnCollision.UseVisualStyleBackColor = true;
            this.rBtnCollision.CheckedChanged += new System.EventHandler(this.rBtnCollision_CheckedChanged);
            // 
            // rBtnBackground
            // 
            resources.ApplyResources(this.rBtnBackground, "rBtnBackground");
            this.rBtnBackground.Name = "rBtnBackground";
            this.rBtnBackground.TabStop = true;
            this.rBtnBackground.UseVisualStyleBackColor = true;
            this.rBtnBackground.CheckedChanged += new System.EventHandler(this.rBtnBackground_CheckedChanged);
            // 
            // pictureBox3
            // 
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.label15.Name = "label15";
            // 
            // pBSelectedTile
            // 
            resources.ApplyResources(this.pBSelectedTile, "pBSelectedTile");
            this.pBSelectedTile.Name = "pBSelectedTile";
            this.pBSelectedTile.TabStop = false;
            this.pBSelectedTile.Paint += new System.Windows.Forms.PaintEventHandler(this.pBSelectedTile_Paint);
            // 
            // tBTileID
            // 
            this.tBTileID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.tBTileID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.tBTileID, "tBTileID");
            this.tBTileID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.tBTileID.Name = "tBTileID";
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // ScrollBarTileMap
            // 
            resources.ApplyResources(this.ScrollBarTileMap, "ScrollBarTileMap");
            this.ScrollBarTileMap.LargeChange = 64;
            this.ScrollBarTileMap.Maximum = 12800;
            this.ScrollBarTileMap.Name = "ScrollBarTileMap";
            this.ScrollBarTileMap.SmallChange = 64;
            this.ScrollBarTileMap.ValueChanged += new System.EventHandler(this.ScrollBarTileMap_ValueChanged);
            // 
            // pBTileMap
            // 
            this.pBTileMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            resources.ApplyResources(this.pBTileMap, "pBTileMap");
            this.pBTileMap.Name = "pBTileMap";
            this.pBTileMap.TabStop = false;
            this.pBTileMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pBTileMap_Paint);
            this.pBTileMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pBTileMap_MouseClick);
            this.pBTileMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pBTileMap_MouseMove);
            // 
            // rBtnTileSelect
            // 
            resources.ApplyResources(this.rBtnTileSelect, "rBtnTileSelect");
            this.rBtnTileSelect.FlatAppearance.BorderSize = 0;
            this.rBtnTileSelect.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.rBtnTileSelect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.rBtnTileSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.rBtnTileSelect.Name = "rBtnTileSelect";
            this.rBtnTileSelect.TabStop = true;
            this.rBtnTileSelect.UseVisualStyleBackColor = true;
            this.rBtnTileSelect.CheckedChanged += new System.EventHandler(this.rBtnTileSelect_CheckedChanged);
            // 
            // rBtnPen
            // 
            resources.ApplyResources(this.rBtnPen, "rBtnPen");
            this.rBtnPen.FlatAppearance.BorderSize = 0;
            this.rBtnPen.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.rBtnPen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.rBtnPen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.rBtnPen.Name = "rBtnPen";
            this.rBtnPen.TabStop = true;
            this.rBtnPen.UseVisualStyleBackColor = true;
            this.rBtnPen.CheckedChanged += new System.EventHandler(this.rBtnPen_CheckedChanged);
            // 
            // rBtnSelect
            // 
            resources.ApplyResources(this.rBtnSelect, "rBtnSelect");
            this.rBtnSelect.FlatAppearance.BorderSize = 0;
            this.rBtnSelect.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.rBtnSelect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.rBtnSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.rBtnSelect.Name = "rBtnSelect";
            this.rBtnSelect.TabStop = true;
            this.rBtnSelect.UseVisualStyleBackColor = true;
            this.rBtnSelect.CheckedChanged += new System.EventHandler(this.rBtnSelect_CheckedChanged);
            // 
            // rBtnEraser
            // 
            resources.ApplyResources(this.rBtnEraser, "rBtnEraser");
            this.rBtnEraser.FlatAppearance.BorderSize = 0;
            this.rBtnEraser.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.rBtnEraser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.rBtnEraser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.rBtnEraser.Name = "rBtnEraser";
            this.rBtnEraser.TabStop = true;
            this.rBtnEraser.UseVisualStyleBackColor = true;
            this.rBtnEraser.CheckedChanged += new System.EventHandler(this.rBtnEraser_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.bearbeitenToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAllToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            resources.ApplyResources(this.saveAllToolStripMenuItem, "saveAllToolStripMenuItem");
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillAllTilesToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.bearbeitenToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            resources.ApplyResources(this.bearbeitenToolStripMenuItem, "bearbeitenToolStripMenuItem");
            // 
            // fillAllTilesToolStripMenuItem
            // 
            this.fillAllTilesToolStripMenuItem.Name = "fillAllTilesToolStripMenuItem";
            resources.ApplyResources(this.fillAllTilesToolStripMenuItem, "fillAllTilesToolStripMenuItem");
            this.fillAllTilesToolStripMenuItem.Click += new System.EventHandler(this.fillAllTilesToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resources.ApplyResources(this.resetToolStripMenuItem, "resetToolStripMenuItem");
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlsToolStripMenuItem,
            this.contaToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // controlsToolStripMenuItem
            // 
            this.controlsToolStripMenuItem.Name = "controlsToolStripMenuItem";
            resources.ApplyResources(this.controlsToolStripMenuItem, "controlsToolStripMenuItem");
            this.controlsToolStripMenuItem.Click += new System.EventHandler(this.controlsToolStripMenuItem_Click);
            // 
            // contaToolStripMenuItem
            // 
            this.contaToolStripMenuItem.Name = "contaToolStripMenuItem";
            resources.ApplyResources(this.contaToolStripMenuItem, "contaToolStripMenuItem");
            this.contaToolStripMenuItem.Click += new System.EventHandler(this.contaToolStripMenuItem_Click);
            // 
            // openFileDialogOpenMap
            // 
            resources.ApplyResources(this.openFileDialogOpenMap, "openFileDialogOpenMap");
            // 
            // openFileDialogOpenTileSet
            // 
            resources.ApplyResources(this.openFileDialogOpenTileSet, "openFileDialogOpenTileSet");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // colorDialogGridColor
            // 
            this.colorDialogGridColor.Color = System.Drawing.Color.Gray;
            this.colorDialogGridColor.SolidColorOnly = true;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            resources.ApplyResources(this.btnMinimize, "btnMinimize");
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            resources.ApplyResources(this.btnMaximize, "btnMaximize");
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.UseVisualStyleBackColor = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.Controls.Add(this.btnMaximize);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.splitContainerRight);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.splitContainerRight.Panel1.ResumeLayout(false);
            this.splitContainerRight.Panel2.ResumeLayout(false);
            this.splitContainerRight.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).EndInit();
            this.splitContainerRight.ResumeLayout(false);
            this.splitContainerLeft.Panel1.ResumeLayout(false);
            this.splitContainerLeft.Panel1.PerformLayout();
            this.splitContainerLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).EndInit();
            this.splitContainerLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBMap)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTileSetHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTileSetWidth)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTileHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTileWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDWidth)).EndInit();
            this.groupBoxLayers.ResumeLayout(false);
            this.groupBoxLayers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBSelectedTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBTileMap)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainerRight;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.GroupBox groupBoxLayers;
        private System.Windows.Forms.CheckBox cBBackgroundVisible;
        private System.Windows.Forms.RadioButton rBtnLayer2;
        private System.Windows.Forms.RadioButton rBtnLayer1;
        private System.Windows.Forms.RadioButton rBtnLayer3;
        private System.Windows.Forms.RadioButton rBtnBackground;
        private System.Windows.Forms.CheckBox cBLayer2Visible;
        private System.Windows.Forms.CheckBox cBLayer1Visible;
        private System.Windows.Forms.CheckBox cBLayer3Visible;
        private System.Windows.Forms.CheckBox cBCollisionVisible;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.PictureBox pBMap;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSaveMap;
        private System.Windows.Forms.Button btnOpenMap;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.NumericUpDown nUDTileSetHeight;
        private System.Windows.Forms.Button btnOpenTileSet;
        private System.Windows.Forms.NumericUpDown nUDTileSetWidth;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckBox cBShowGrid;
        private System.Windows.Forms.Button btnGridColor;
        public System.Windows.Forms.SplitContainer splitContainerLeft;
        public System.Windows.Forms.NumericUpDown nUDHeight;
        public System.Windows.Forms.NumericUpDown nUDWidth;
        public System.Windows.Forms.NumericUpDown nUDTileHeight;
        public System.Windows.Forms.NumericUpDown nUDTileWidth;
        private System.Windows.Forms.TextBox tBMouseX;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tBTileY;
        private System.Windows.Forms.TextBox tBTileX;
        private System.Windows.Forms.TextBox tBMouseY;
        public System.Windows.Forms.ColorDialog colorDialogGridColor;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        public System.Windows.Forms.OpenFileDialog openFileDialogOpenMap;
        public System.Windows.Forms.RadioButton rBtnPen;
        public System.Windows.Forms.RadioButton rBtnTileSelect;
        public System.Windows.Forms.RadioButton rBtnSelect;
        public System.Windows.Forms.RadioButton rBtnEraser;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.VScrollBar ScrollBarTileMap;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.OpenFileDialog openFileDialogOpenTileSet;
        public System.Windows.Forms.TextBox tBTileID;
        private System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.PictureBox pBTileMap;
        public System.Windows.Forms.RadioButton rBtnCollision;
        public System.Windows.Forms.PictureBox pBSelectedTile;
        private System.Windows.Forms.Button btnMaximize;
        private System.Windows.Forms.ToolStripMenuItem controlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillAllTilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contaToolStripMenuItem;
    }
}

