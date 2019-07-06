using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MapEditor
{
    public partial class MainWindow : Form
    {
        private int XOffsetMap = 0;//for moving the Map
        private int YOffsetMap = 0;

        private int XOffsetTileMap = 0;
        private int YOffsetTileMap = 0;//for scrolling the TileSet


        private bool UpdateTileSet = true;
        private bool UpdateSelectedTile = false;

        private bool LoadGrid = true;//Load Grid only once(in event paint)

        Draw.DrawImage drawImage = new Draw.DrawImage();
        Tiles.TileMap tileMap = new Tiles.TileMap();

        Layers.Background background = new Layers.Background();
        Layers.Layer1 layer1 = new Layers.Layer1();
        Layers.Layer2 layer2 = new Layers.Layer2();
        Layers.Layer3 layer3 = new Layers.Layer3();
        Layers.Collision collision = new Layers.Collision();

        public MainWindow()
        {            
            InitializeComponent();
        }


        #region MainWindow: Load ,Close, Minimize, Maximize, Move, KeyDown
        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.splitContainerRight.SplitterWidth = 2;
            this.splitContainerLeft.SplitterWidth = 2;
            KeyPreview = true;
            drawImage.GridColor = colorDialogGridColor.Color;
            pBTileMap.SizeMode = PictureBoxSizeMode.AutoSize;
            this.MouseWheel += new MouseEventHandler(pBTileMap_MouseWheel);
        }

        private void btnClose_Click(object sender, EventArgs e)//Close
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)//Minimize
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Maximized)
            {
                ResetMainWindow();
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                pBTileMap.Size = new Size(293, 812);
                pBMap.Size = new Size(1710, 600);

                label15.Location = new Point(67, 920);
                tBTileID.Location = new Point(114, 920);
                pBSelectedTile.Location = new Point(171, 898);

                rBtnPen.Location = new Point(61, 983);
                rBtnEraser.Location = new Point(108, 983);
                rBtnSelect.Location = new Point(155, 983);
                rBtnTileSelect.Location = new Point(202, 983);

                btnMinimize.Location = new Point(1789, 0);
                btnMaximize.Location = new Point(1834, 0);
                btnClose.Location = new Point(1879, 0);

                label3.Location = new Point(1449, 12);
                tBMouseX.Location = new Point(1516, 12);
                tBMouseY.Location = new Point(1552, 12);
                label4.Location = new Point(1449, 35);
                tBTileX.Location = new Point(1516, 35);
                tBTileY.Location = new Point(1552, 35);

                groupBoxLayers.Location = new Point(243, -4);
                groupBox1.Location = new Point(465, -4);
                groupBox3.Location = new Point(687, -4);
                groupBox4.Location = new Point(910, -4);
                groupBox2.Location = new Point(1132, -4);

                splitContainerLeft.SplitterDistance = 910;
                splitContainerRight.SplitterDistance = 1610;
            }
        }//Maximize

        //Move https://stackoverflow.com/questions/1607841/c-how-to-drag-a-from-by-the-form-and-its-controls
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ResetMainWindow();

                splitContainerLeft.SplitterDistance = 600;
                splitContainerRight.SplitterDistance = 1110;

                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        public void MainWindow_KeyDown(object sender, KeyEventArgs e)//Move Map Offset
        {
            //Hotkey save open
            if (e.KeyCode == Keys.S && e.Control)
            {
                saveAllToolStripMenuItem.PerformClick();
            }
            else if (e.KeyCode == Keys.N && e.Control)
            {
                openToolStripMenuItem.PerformClick();
            }

            //Left = 0, Right = 1, Up = 2, Down = 3
            else if (e.KeyCode == Keys.A)
            {
                if (rBtnCollision.Checked)
                {
                    drawImage.MoveBitmap(4);
                    XOffsetMap -= Convert.ToInt32(drawImage.TileWidth / 2);
                }
                else
                {
                    drawImage.MoveBitmap(0);
                    XOffsetMap -= Convert.ToInt32(drawImage.TileWidth);
                }
            }
            else if (e.KeyCode == Keys.D)
            {
                if (rBtnCollision.Checked)
                {
                    drawImage.MoveBitmap(5);
                    XOffsetMap += Convert.ToInt32(drawImage.TileWidth / 2);
                }
                else
                {
                    drawImage.MoveBitmap(1);
                    XOffsetMap += Convert.ToInt32(drawImage.TileWidth);
                }
            }
            else if (e.KeyCode == Keys.W)
            {
                if (rBtnCollision.Checked)
                {
                    drawImage.MoveBitmap(6);
                    YOffsetMap -= Convert.ToInt32(drawImage.TileHeight / 2);
                }
                else
                {
                    drawImage.MoveBitmap(2);
                    YOffsetMap -= Convert.ToInt32(drawImage.TileHeight);
                }
            }
            else if (e.KeyCode == Keys.S)
            {
                if (rBtnCollision.Checked)
                {
                    drawImage.MoveBitmap(7);
                    YOffsetMap += Convert.ToInt32(drawImage.TileHeight / 2);
                }
                else
                {
                    drawImage.MoveBitmap(3);
                    YOffsetMap += Convert.ToInt32(drawImage.TileHeight);
                }
            }

            //Hotkey Tools
            else if (e.KeyCode == Keys.Y || e.KeyCode == Keys.Z)
            {
                rBtnPen.PerformClick();
            }
            else if (e.KeyCode == Keys.X)
            {
                rBtnEraser.PerformClick();
            }
            else if (e.KeyCode == Keys.C)
            {
                rBtnSelect.PerformClick();
            }
            else if (e.KeyCode == Keys.V)
            {
                rBtnTileSelect.PerformClick();
            }

            //Hotkey Layers Visible
            else if (e.KeyCode == Keys.D1 && e.Shift)
            {
                if (cBBackgroundVisible.Checked == true)
                {
                    cBBackgroundVisible.Checked = false;
                }
                else
                {
                    cBBackgroundVisible.Checked = true;
                }
            }
            else if (e.KeyCode == Keys.D2 && e.Shift)
            {
                if (cBLayer1Visible.Checked == true)
                {
                    cBLayer1Visible.Checked = false;
                }
                else
                {
                    cBLayer1Visible.Checked = true;
                }
            }
            else if (e.KeyCode == Keys.D3 && e.Shift)
            {
                if (cBLayer2Visible.Checked == true)
                {
                    cBLayer2Visible.Checked = false;
                }
                else
                {
                    cBLayer2Visible.Checked = true;
                }
            }
            else if (e.KeyCode == Keys.D4 && e.Shift)
            {
                if (cBLayer3Visible.Checked == true)
                {
                    cBLayer3Visible.Checked = false;
                }
                else
                {
                    cBLayer3Visible.Checked = true;
                }
            }
            else if (e.KeyCode == Keys.D5 && e.Shift)
            {
                if (cBCollisionVisible.Checked == true)
                {
                    cBCollisionVisible.Checked = false;
                }
                else
                {
                    cBCollisionVisible.Checked = true;
                }
            }

            //Hotkey Layers
            else if (e.KeyCode == Keys.D1)
            {
                rBtnBackground.PerformClick();
            }
            else if (e.KeyCode == Keys.D2)
            {
                rBtnLayer1.PerformClick();
            }
            else if (e.KeyCode == Keys.D3)
            {
                rBtnLayer2.PerformClick();
            }
            else if (e.KeyCode == Keys.D4)
            {
                rBtnLayer3.PerformClick();
            }
            else if (e.KeyCode == Keys.D5)
            {
                rBtnCollision.PerformClick();
            }

            //Hotkey Grid
            else if (e.KeyCode == Keys.G)
            {
                if (cBShowGrid.Checked)
                {
                    cBShowGrid.Checked = false;
                }
                else
                {
                    cBShowGrid.Checked = true;
                }
            }

            MapUpdate();
        }

        private void ResetMainWindow()//Reset all GUI Settings, from maximize to minimize
        {
            this.WindowState = FormWindowState.Normal;
            pBTileMap.Size = new Size(293, 512);
            pBMap.Size = new Size(1110, 600);
            pBTileMap.Location = new Point(25, 6);

            label15.Location = new Point(67, 620);
            tBTileID.Location = new Point(114, 620);
            pBSelectedTile.Location = new Point(171, 598);

            rBtnPen.Location = new Point(61, 683);
            rBtnEraser.Location = new Point(108, 683);
            rBtnSelect.Location = new Point(155, 683);
            rBtnTileSelect.Location = new Point(202, 683);

            btnMinimize.Location = new Point(1289, 0);
            btnMaximize.Location = new Point(1334, 0);
            btnClose.Location = new Point(1379, 0);

            label3.Location = new Point(969, 12);
            tBMouseX.Location = new Point(1036, 12);
            tBMouseY.Location = new Point(1072, 12);
            label4.Location = new Point(969, 35);
            tBTileX.Location = new Point(1036, 35);
            tBTileY.Location = new Point(1072, 35);

            groupBoxLayers.Location = new Point(3, -4);
            groupBox1.Location = new Point(225, -4);
            groupBox3.Location = new Point(447, -4);
            groupBox4.Location = new Point(670, -4);
            groupBox2.Location = new Point(892, -4);

            splitContainerLeft.SplitterDistance = 600;
            splitContainerRight.SplitterDistance = 1110;
        }

        #endregion


        #region pBMap: MouseClick, MouseMove, Paint
        private void pBMap_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                drawImage.CurrentTileX = Convert.ToInt32(tBTileX.Text);
                drawImage.CurrentTileY = Convert.ToInt32(tBTileY.Text);


                if (rBtnBackground.Checked)
                {
                    background.TileX = Convert.ToInt32(drawImage.CurrentTileX);
                    background.TileY = Convert.ToInt32(drawImage.CurrentTileY);

                    if (rBtnPen.Checked)
                    {
                        background.WriteArray();
                        drawImage.DrawBackground(true);//true = Write
                    }
                    else if (rBtnEraser.Checked)
                    {
                        background.EraseArray();
                        drawImage.DrawBackground(false);//false = Erase
                    }
                    else if (rBtnTileSelect.Checked)
                    {
                        tBTileID.Text = Convert.ToString(tileMap.ID);
                    }
                }
                else if (rBtnLayer1.Checked)
                {
                    layer1.TileX = Convert.ToInt32(drawImage.CurrentTileX);
                    layer1.TileY = Convert.ToInt32(drawImage.CurrentTileY);

                    if (rBtnPen.Checked)
                    {
                        layer1.WriteArray();
                        drawImage.DrawLayer1(true);
                    }
                    else if (rBtnEraser.Checked)
                    {
                        layer1.EraseArray();
                        drawImage.DrawLayer1(false);
                    }
                }
                else if (rBtnLayer2.Checked)
                {
                    layer2.TileX = Convert.ToInt32(drawImage.CurrentTileX);
                    layer2.TileY = Convert.ToInt32(drawImage.CurrentTileY);

                    if (rBtnPen.Checked)
                    {
                        layer2.WriteArray();
                        drawImage.DrawLayer2(true);
                    }
                    else if (rBtnEraser.Checked)
                    {
                        layer2.EraseArray();
                        drawImage.DrawLayer2(false);
                    }
                }
                else if (rBtnLayer3.Checked)
                {
                    layer3.TileX = Convert.ToInt32(drawImage.CurrentTileX);
                    layer3.TileY = Convert.ToInt32(drawImage.CurrentTileY);

                    if (rBtnPen.Checked)
                    {
                        layer3.WriteArray();
                        drawImage.DrawLayer3(true);
                    }
                    else if (rBtnEraser.Checked)
                    {
                        layer3.EraseArray();
                        drawImage.DrawLayer3(false);
                    }
                }
                else if (rBtnCollision.Checked)
                {
                    drawImage.CurrentTileX = Convert.ToInt32((e.X - drawImage.MouseX) / (drawImage.TileWidth / 2));
                    drawImage.CurrentTileY = Convert.ToInt32((e.Y - drawImage.MouseY) / (drawImage.TileHeight / 2));

                    collision.TileX = Convert.ToInt32((e.X - drawImage.MouseX) / (drawImage.TileWidth / 2));
                    collision.TileY = Convert.ToInt32((e.Y - drawImage.MouseY) / (drawImage.TileHeight / 2));

                    if (rBtnPen.Checked)
                    {
                        collision.WriteArray();
                        drawImage.DrawCollision(true);
                    }
                    else if (rBtnEraser.Checked)
                    {
                        collision.EraseArray();
                        drawImage.DrawCollision(false);
                    }
                }
            }
            catch (Exception)
            {
            }
            

            MapUpdate();
            SelectedTileUpdate();
        }

        public void pBMap_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                tBMouseX.Text = Convert.ToString(e.X - drawImage.MouseX);
                tBMouseY.Text = Convert.ToString(e.Y - drawImage.MouseY);

                tBTileX.Text = Convert.ToString(Convert.ToInt32((e.X - drawImage.MouseX) / drawImage.TileWidth));
                tBTileY.Text = Convert.ToString(Convert.ToInt32((e.Y - drawImage.MouseY) / drawImage.TileHeight));

                if (e.Button == MouseButtons.Left)
                {
                    drawImage.CurrentTileX = Convert.ToInt32(tBTileX.Text);
                    drawImage.CurrentTileY = Convert.ToInt32(tBTileY.Text);

                    
                    if (rBtnBackground.Checked)
                    {
                        background.TileX = Convert.ToInt32(tBTileX.Text);//..
                        background.TileY = Convert.ToInt32(tBTileY.Text);

                        if (rBtnPen.Checked)
                        {
                            background.WriteArray();
                            drawImage.DrawBackground(true);
                        }
                        else if (rBtnEraser.Checked)
                        {
                            background.EraseArray();
                            drawImage.DrawBackground(false);
                        }
                    }
                    else if (rBtnLayer1.Checked)
                    {
                        layer1.TileX = Convert.ToInt32(tBTileX.Text);
                        layer1.TileY = Convert.ToInt32(tBTileY.Text);

                        if (rBtnPen.Checked)
                        {
                            layer1.WriteArray();
                            drawImage.DrawLayer1(true);
                        }
                        else if (rBtnEraser.Checked)
                        {
                            layer1.EraseArray();
                            drawImage.DrawLayer1(false);
                        }
                    }
                    else if (rBtnLayer2.Checked)
                    {
                        layer2.TileX = Convert.ToInt32(tBTileX.Text);
                        layer2.TileY = Convert.ToInt32(tBTileY.Text);

                        if (rBtnPen.Checked)
                        {
                            layer2.WriteArray();
                            drawImage.DrawLayer2(true);
                        }
                        else if (rBtnEraser.Checked)
                        {
                            layer2.EraseArray();
                            drawImage.DrawLayer2(false);
                        }
                    }
                    else if (rBtnLayer3.Checked)
                    {
                        layer3.TileX = Convert.ToInt32(tBTileX.Text);
                        layer3.TileY = Convert.ToInt32(tBTileY.Text);

                        if (rBtnPen.Checked)
                        {
                            layer3.WriteArray();
                            drawImage.DrawLayer3(true);
                        }
                        else if (rBtnEraser.Checked)
                        {
                            layer3.EraseArray();
                            drawImage.DrawLayer3(false);
                        }
                    }
                    else if (rBtnCollision.Checked)
                    {
                        drawImage.CurrentTileX = Convert.ToInt32((e.X - drawImage.MouseX) / (drawImage.TileWidth / 2));
                        drawImage.CurrentTileY = Convert.ToInt32((e.Y - drawImage.MouseY) / (drawImage.TileHeight / 2));

                        collision.TileX = Convert.ToInt32((e.X - drawImage.MouseX) / (drawImage.TileWidth / 2));
                        collision.TileY = Convert.ToInt32((e.Y - drawImage.MouseY) / (drawImage.TileHeight / 2));


                        if (rBtnPen.Checked)
                        {
                            collision.WriteArray();
                            drawImage.DrawCollision(true);
                        }
                        else if (rBtnEraser.Checked)
                        {
                            collision.EraseArray();
                            drawImage.DrawCollision(false);
                        }
                    }

                    MapUpdate();
                }
            }
            catch (Exception)
            {
            }
        }

        private void pBMap_Paint(object sender, PaintEventArgs e)//Draw all Layers
        {
            if (cBBackgroundVisible.Checked)//is drawn first
            {
                e.Graphics.DrawImage((Image)StaticMembers.backgroundBitmap, XOffsetMap, YOffsetMap);
            }

            if (cBLayer1Visible.Checked)
            {
                e.Graphics.DrawImage((Image)StaticMembers.layer1Bitmap, XOffsetMap, YOffsetMap);
            }

            if (cBLayer2Visible.Checked)
            {
                e.Graphics.DrawImage((Image)StaticMembers.layer2Bitmap, XOffsetMap, YOffsetMap);
            }

            if (cBLayer3Visible.Checked)
            {
                e.Graphics.DrawImage((Image)StaticMembers.layer3Bitmap, XOffsetMap, YOffsetMap);
            }

            if (cBCollisionVisible.Checked)//is drawn before Grid
            {
                e.Graphics.DrawImage((Image)StaticMembers.collisionBitmap, XOffsetMap, YOffsetMap);
            }

            if (cBShowGrid.Checked)//is drawn last
            {
                if (LoadGrid)
                {
                    drawImage.ShowGrid();
                    LoadGrid = false;
                }
                
                e.Graphics.DrawImage((Image)drawImage.bmGrid, XOffsetMap, YOffsetMap);
            }
        }
        #endregion

        #region pBTileMap: MouseClick, MouseMove, Paint, ScrollBar , MouseWheel
        private void pBTileMap_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                tBTileID.Text = Convert.ToString(tileMap.TileID());

                background.TileID = tileMap.TileID();//set TileID for background
                layer1.TileID = tileMap.TileID();//set TileID for layer1
                layer2.TileID = tileMap.TileID();//set TileID for layer2
                layer3.TileID = tileMap.TileID();//set TileID for layer3
                collision.TileID = tileMap.TileID();//set TileID for collison 

                SelectedTileUpdate();
            }
            catch (Exception)
            {
            }
        }

        private void pBTileMap_MouseMove(object sender, MouseEventArgs e)
        {
            tileMap.MouseX = e.X + XOffsetTileMap;
            tileMap.MouseY = e.Y + YOffsetTileMap;

            tileMap.TileX = Convert.ToInt32((e.X + XOffsetTileMap) / tileMap.TileWidth);
            tileMap.TileY = Convert.ToInt32((e.Y + YOffsetTileMap) / tileMap.TileHeight);
        }

        private void pBTileMap_Paint(object sender, PaintEventArgs e)
        {
            if (UpdateTileSet)
            {
                MessageBox.Show("Please select a TileSet");
                tileMap.DrawTileMap();
                UpdateTileSet = false;

                if (StaticMembers.bmTileMap.Height >= 8 * tileMap.TileHeight)
                {
                    ScrollBarTileMap.Maximum = StaticMembers.bmTileMap.Height - 8 * tileMap.TileHeight;
                }
                else
                {
                    ScrollBarTileMap.Maximum = StaticMembers.bmTileMap.Height - tileMap.TileHeight;
                }
            }

            if (rBtnCollision.Checked)
            {
                e.Graphics.DrawImage((Image)tileMap.bmCollisionTileSet, XOffsetTileMap, -1 * ScrollBarTileMap.Value);
            }
            else
            {
                e.Graphics.DrawImage((Image)StaticMembers.bmTileMap, XOffsetTileMap, -1 * ScrollBarTileMap.Value);
            }
            
            UpdateSelectedTile = true;
        }


        private void ScrollBarTileMap_ValueChanged(object sender, EventArgs e)
        {
            //Tiles.TileMap tileMap = new Tiles.TileMap();

            YOffsetTileMap = ScrollBarTileMap.Value;
            
            TileSetUpdate();
            
        }

        private void pBTileMap_MouseWheel(object sender, MouseEventArgs e)
        {
            //Tiles.TileMap tileMap = new Tiles.TileMap();

            try
            {
                if (e.Delta > 0)//Scroll Up
                {
                    ScrollBarTileMap.Value -= Convert.ToInt32(nUDTileSetHeight.Value);
                }
                else//Scroll Down
                {
                    ScrollBarTileMap.Value += Convert.ToInt32(nUDTileSetHeight.Value);
                }

                TileSetUpdate();
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region pBSelectedTile: Paint

        private void pBSelectedTile_Paint(object sender, PaintEventArgs e)
        {
            if (UpdateSelectedTile)
            {
                tileMap.DrawSelectedTile();
            }

            if (StaticMembers.bmSelectedTile != null)
            {
                e.Graphics.DrawImage((Image)StaticMembers.bmSelectedTile, 0, 0);
            }
        }
        #endregion


        #region Groupbox Layers: Object, Collision, Animation, Layer1, Layer2

        //RadioButton Layers
        private void rBtnBackground_CheckedChanged(object sender, EventArgs e)
        {
            cBBackgroundVisible.Checked = true;
        }

        private void rBtnLayer1_CheckedChanged(object sender, EventArgs e)
        {
            cBLayer1Visible.Checked = true;
        }

        private void rBtnLayer2_CheckedChanged(object sender, EventArgs e)
        {
            cBLayer2Visible.Checked = true;
        }

        private void rBtnLayer3_CheckedChanged(object sender, EventArgs e)
        {
            cBLayer3Visible.Checked = true;
        }

        public void rBtnCollision_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnCollision.Checked)
            {
                tileMap.collisionChecked = true;
                ScrollBarTileMap.Value = 0;
            }
            else
            {
                tileMap.collisionChecked = false;
            }
            cBCollisionVisible.Checked = true;
            TileSetUpdate();
        }

        //CheckBox Visible
        private void cBBackgroundVisible_CheckedChanged(object sender, EventArgs e)
        {
            btnUpdate.PerformClick();
        }

        private void cBLayer1Visible_CheckedChanged(object sender, EventArgs e)
        {
            btnUpdate.PerformClick();
        }

        private void cBLayer2Visible_CheckedChanged(object sender, EventArgs e)
        {
            btnUpdate.PerformClick();
        }

        private void cBLayer3Visible_CheckedChanged(object sender, EventArgs e)
        {
            btnUpdate.PerformClick();
        }

        private void cBCollisionVisible_CheckedChanged(object sender, EventArgs e)
        {
            btnUpdate.PerformClick();
        }
        #endregion

        #region Groupbox TileMap: MapWidth, MapHeight, TileWidth, TileHeight
        public void nUDWidth_ValueChanged(object sender, EventArgs e)
        {
            drawImage.Width = Convert.ToInt32(nUDWidth.Value);
            drawImage.ShowGrid();
            btnUpdate.PerformClick();
        }

        public void nUDHeight_ValueChanged(object sender, EventArgs e)
        {
            drawImage.Height = Convert.ToInt32(nUDHeight.Value);
            drawImage.ShowGrid();
            btnUpdate.PerformClick();
        }

        public void nUDTileWidth_ValueChanged(object sender, EventArgs e)
        {
            drawImage.TileWidth = Convert.ToInt32(nUDTileWidth.Value);
            drawImage.ShowGrid();
            btnUpdate.PerformClick();
        }

        public void nUDTileHeight_ValueChanged(object sender, EventArgs e)
        {
            drawImage.TileHeight = Convert.ToInt32(nUDTileHeight.Value);
            drawImage.ShowGrid();
            btnUpdate.PerformClick();
        }
        #endregion

        #region Groupbox Settings: ShowGrid, GridColor, Update
        private void cBShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            if (cBShowGrid.Checked)
            {
                drawImage.ShowGrid();
            }

            btnUpdate.PerformClick();
        }

        private void btnGridColor_Click(object sender, EventArgs e)
        {
            colorDialogGridColor.ShowDialog();
            drawImage.GridColor = colorDialogGridColor.Color;
            drawImage.ShowGrid();
            MapUpdate();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MapUpdate();
            TileSetUpdate();
            SelectedTileUpdate();
        }
        #endregion

        #region Groupbox TileSet: Open

        private void btnOpenTileSet_Click(object sender, EventArgs e)
        {
            tileMap.DrawTileMap();
            TileSetUpdate();

            if (StaticMembers.bmTileMap.Height >= 8 * tileMap.TileHeight)
            {
                ScrollBarTileMap.Maximum = StaticMembers.bmTileMap.Height - 8 * tileMap.TileHeight;
            }
            else
            {
                ScrollBarTileMap.Maximum = StaticMembers.bmTileMap.Height - tileMap.TileHeight;
            }

            ScrollBarTileMap.Value = ScrollBarTileMap.Minimum;
        }

        #endregion

        #region Groupbox Open/Save: Open, Save, Reset
        private void btnOpenMap_Click(object sender, EventArgs e)
        {
            Map.InputMap inputMap = new Map.InputMap();

            if (rBtnBackground.Checked)
            {
                if (cBBackgroundVisible.Checked)
                {
                    inputMap.InputBackground();
                    drawImage.ImportBackground(true);
                }
                else
                {
                    MessageBox.Show("Background Visible must be checked");
                }
            }
            else if (rBtnLayer1.Checked)
            {
                if (cBLayer1Visible.Checked)
                {
                    inputMap.InputLayer1();
                    drawImage.ImportLayer1(true);
                }
                else
                {
                    MessageBox.Show("Layer1 Visible must be checked");
                }
                
            }
            else if (rBtnLayer2.Checked)
            {
                if (cBLayer2Visible.Checked)
                {
                    inputMap.InputLayer2();
                    drawImage.ImportLayer2(true);
                }
                else
                {
                    MessageBox.Show("Layer2 Visible must be checked");
                }
            }
            else if (rBtnLayer3.Checked)
            {
                if (cBLayer3Visible.Checked)
                {
                    inputMap.InputLayer3();
                    drawImage.ImportLayer3(true);
                }
                else
                {
                    MessageBox.Show("Layer3 Visible must be checked");
                }
            }
            else if (rBtnCollision.Checked)
            {
                if (cBCollisionVisible.Checked)
                {
                    inputMap.InputCollision();
                    drawImage.ImportCollision(true);
                }
                else
                {
                    MessageBox.Show("Collision Visible must be checked");
                }
            }

            MapUpdate();
            SelectedTileUpdate();
        }

        private void btnSaveMap_Click(object sender, EventArgs e)
        {
            Map.OutputMap outputMap = new Map.OutputMap();

            if (rBtnBackground.Checked)
            {
                outputMap.OutputBackground();
            }
            else if (rBtnLayer1.Checked)
            {
                outputMap.OutputLayer1();
            }
            else if (rBtnLayer2.Checked)
            {
                outputMap.OutputLayer2();
            }
            else if (rBtnLayer3.Checked)
            {
                outputMap.OutputLayer3();
            }
            else if (rBtnCollision.Checked)
            {
                outputMap.OutputCollision();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to reset the selected layer?", "Warning", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (rBtnBackground.Checked)
                {
                    background.ResetArray();
                    drawImage.ImportBackground(false);
                }
                else if (rBtnLayer3.Checked)
                {
                    layer3.ResetArray();
                    drawImage.ImportLayer3(false);
                }
                else if (rBtnLayer1.Checked)
                {
                    layer1.ResetArray();
                    drawImage.ImportLayer1(false);
                }
                else if (rBtnLayer2.Checked)
                {
                    layer2.ResetArray();
                    drawImage.ImportLayer2(false);
                }
                else if(rBtnCollision.Checked)
                {
                    collision.ResetArray();
                    drawImage.ImportCollision(false);
                }
            }

            MapUpdate();
        }
        #endregion


        #region Tools: Pen, Eraser, Select, TileSelect
        public void rBtnPen_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnPen.Checked)
            {
                rBtnPen.Image = MapEditor.Icons.PenDark;
            }
            else
            {
                rBtnPen.Image = MapEditor.Icons.Pen;
            }
        }

        public void rBtnEraser_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnEraser.Checked)
            {
                rBtnEraser.Image = MapEditor.Icons.EraserDark;
            }
            else
            {
                rBtnEraser.Image = MapEditor.Icons.Eraser;
            }
        }

        public void rBtnSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnSelect.Checked)
            {
                rBtnSelect.Image = MapEditor.Icons.SelectDark;
            }
            else
            {
                rBtnSelect.Image = MapEditor.Icons.Select;
            }
        }

        public void rBtnTileSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnTileSelect.Checked)
            {
                rBtnTileSelect.Image = MapEditor.Icons.TileSelectDark;
            }
            else
            {
                rBtnTileSelect.Image = MapEditor.Icons.TileSelect;
            }
        }

        #endregion

        #region MenuStrip
        //File
        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Map.OutputMap outputMap = new Map.OutputMap();

            if (StaticMembers.backgroundPath != null)
            {
                outputMap.OutputBackground();
            }
            if (StaticMembers.layer1Path != null)
            {
                outputMap.OutputLayer1();
            }
            if (StaticMembers.layer2Path != null)
            {
                outputMap.OutputLayer2();
            }
            if (StaticMembers.layer3Path != null)
            {
                outputMap.OutputLayer3();
            }
            if (StaticMembers.collisionPath != null)
            {
                outputMap.OutputCollision();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnOpenMap.PerformClick();
        }

        //Edit
        private void fillAllTilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rBtnBackground.Checked)
            {
                tileMap.FillAllTiles(0);//0 -> background
                drawImage.ImportBackground(true);
            }
            else if (rBtnLayer1.Checked)
            {
                tileMap.FillAllTiles(1);//1 -> layer1
                drawImage.ImportLayer1(true);
            }
            else if (rBtnLayer2.Checked)
            {
                tileMap.FillAllTiles(2);//2 -> layer2
                drawImage.ImportLayer2(true);
            }
            else if (rBtnLayer3.Checked)
            {
                tileMap.FillAllTiles(3);//3 -> layer3
                drawImage.ImportLayer3(true);
            }
            else if (rBtnCollision.Checked)
            {
                tileMap.FillAllTiles(4);//4 -> collision
                drawImage.ImportCollision(true);
            }
            MapUpdate();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnReset.PerformClick();
        }

        //Help
        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form hotkeys = new Hotkeys();
            hotkeys.Show(this);
        }

        private void contaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://jaemil.de");
        }
        #endregion

        #region Update
        void MapUpdate()
        {
            pBMap.Refresh();
        }

        void TileSetUpdate()
        {
            pBTileMap.Refresh();
        }

        void SelectedTileUpdate()
        {
            pBSelectedTile.Refresh();
        }

        #endregion
    }
}
