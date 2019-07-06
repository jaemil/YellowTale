using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MapEditor.Map
{
    class OutputMap
    {
        Draw.DrawImage drawImage = new Draw.DrawImage();
        Map.InputMap inputMap = new InputMap();

        private string content;//saves txt as a string
        StreamWriter writer;

        private void OutputAlgorithm(string path, int[,] arr)
        {
            content = "";
            writer = new StreamWriter(path);

            for (int y = 0; y < drawImage.Height; y++)
            {
                for (int x = 0; x < drawImage.Width; x++)
                {
                    content += Convert.ToString(arr[x, y]) + " ";
                }
                content += Environment.NewLine;
            }

            writer.Write(content);
            writer.Close();

            MessageBox.Show(content);
        }

        public void OutputBackground()
        {
            //MessageBox.Show(StaticMembers.backgroundPath);

            try
            {
                OutputAlgorithm(StaticMembers.backgroundPath, StaticMembers.backgroundArray);
            }
            catch (Exception)
            {
                MessageBox.Show("Please open a file for -Background- first");
            }
        }

        public void OutputLayer1()
        {
            //MessageBox.Show(StaticMembers.layer1Path);

            try
            {
                OutputAlgorithm(StaticMembers.layer1Path, StaticMembers.layer1Array);
            }
            catch (Exception)
            {
                MessageBox.Show("Please open a file for -Layer1- first");
            }
        }

        public void OutputLayer2()
        {
            //MessageBox.Show(StaticMembers.layer2Path);

            try
            {
                OutputAlgorithm(StaticMembers.layer2Path, StaticMembers.layer2Array);
            }
            catch (Exception)
            {
                MessageBox.Show("Please open a file for -Layer2- first");
            }
        }

        public void OutputLayer3()
        {
            //MessageBox.Show(StaticMembers.layer3Path);

            try
            {
                OutputAlgorithm(StaticMembers.layer3Path, StaticMembers.layer3Array);
            }
            catch (Exception)
            {
                MessageBox.Show("Please open a file for -Layer3- first");
            }
        }

        public void OutputCollision()
        {
            //MessageBox.Show(StaticMembers.collisionPath);

            try
            {
                content = "";
                writer = new StreamWriter(StaticMembers.collisionPath);

                for (int y = 0; y < drawImage.Height * 2; y++)
                {
                    for (int x = 0; x < drawImage.Width * 2; x++)
                    {
                        content += Convert.ToString(StaticMembers.collisionArray[x, y]) + " ";
                    }
                    content += Environment.NewLine;
                }

                writer.Write(content);
                writer.Close();

                MessageBox.Show(content);
            }
            catch (Exception)
            {
                MessageBox.Show("Please open a file for -Collision- first");
            }
        }
    }
}
