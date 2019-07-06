using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace MapEditor.Map
{
    class InputMap
    {
        MainWindow mainWindow = new MainWindow();
        Draw.DrawImage drawImage = new Draw.DrawImage();


        StreamReader reader;

        private void InputAlgorithm(int width, int height, string content, int[,] arr)
        {
            try
            {
                int i = 0;
                string storage = "";

                if (content != "")//if txt is empty
                {
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            if (content[i] == 13 || content[i] == 10 || content[i] == 32)//linefeed and \n
                            {
                                if (content[i] == 13 && content[i + 1] == 10)
                                {
                                    i += 2;
                                    x -= 1;
                                    continue;
                                }

                                if (storage == "")
                                {
                                    storage += content[i];
                                }

                                arr[x, y] = Convert.ToInt32(storage);

                                storage = "";
                                i++;
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    storage += content[i];
                                }
                                else
                                {
                                    storage += content[i];
                                }

                                x -= 1;

                                i++;
                            }
                        }
                    }

                }
            }
            catch (Exception)
            {
            }
        }//drawImage.Height, drawImage.Width, txtfile

        public void InputBackground()
        {
            if (mainWindow.openFileDialogOpenMap.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StaticMembers.backgroundPath = mainWindow.openFileDialogOpenMap.FileName;

                MessageBox.Show(StaticMembers.backgroundPath);

                reader = new StreamReader(StaticMembers.backgroundPath);
                string objecttxt = reader.ReadToEnd();//Copying whole txt to string

                reader.Close();

                InputAlgorithm(drawImage.Width, drawImage.Height, objecttxt, StaticMembers.backgroundArray);

                MessageBox.Show("Object: \n" + objecttxt);
            }
        }

        public void InputLayer1()
        {
            if (mainWindow.openFileDialogOpenMap.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StaticMembers.layer1Path = mainWindow.openFileDialogOpenMap.FileName;

                MessageBox.Show(StaticMembers.layer1Path);

                reader = new StreamReader(StaticMembers.layer1Path);
                string layer1txt = reader.ReadToEnd();//Copying whole txt to string

                reader.Close();

                InputAlgorithm(drawImage.Width, drawImage.Height, layer1txt, StaticMembers.layer1Array);

                MessageBox.Show("Layer1: \n" + layer1txt);
            }
        }

        public void InputLayer2()
        {
            if (mainWindow.openFileDialogOpenMap.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StaticMembers.layer2Path = mainWindow.openFileDialogOpenMap.FileName;

                MessageBox.Show(StaticMembers.layer2Path);

                reader = new StreamReader(StaticMembers.layer2Path);
                string layer2txt = reader.ReadToEnd();//Copying whole txt to string

                reader.Close();

                InputAlgorithm(drawImage.Width, drawImage.Height, layer2txt, StaticMembers.layer2Array);

                MessageBox.Show("Layer2: \n" + layer2txt);
            }
        }

        public void InputLayer3()
        {
            if (mainWindow.openFileDialogOpenMap.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StaticMembers.layer3Path = mainWindow.openFileDialogOpenMap.FileName;

                MessageBox.Show(StaticMembers.layer3Path);

                reader = new StreamReader(StaticMembers.layer3Path);
                string layer3txt = reader.ReadToEnd();//Copying whole txt to string

                reader.Close();

                InputAlgorithm(drawImage.Width, drawImage.Height, layer3txt, StaticMembers.layer3Array);

                MessageBox.Show("Layer3: \n" + layer3txt);
            }
        }

        public void InputCollision()
        {
            if (mainWindow.openFileDialogOpenMap.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StaticMembers.collisionPath = mainWindow.openFileDialogOpenMap.FileName;

                MessageBox.Show(StaticMembers.collisionPath);

                reader = new StreamReader(StaticMembers.collisionPath);
                string collisiontxt = reader.ReadToEnd();//Copying whole txt to string

                reader.Close();

                InputAlgorithm(drawImage.Width * 2, drawImage.Height * 2, collisiontxt, StaticMembers.collisionArray);

                MessageBox.Show("Collision: \n" + collisiontxt);
            }
        }
    }
}

