using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_9.Labirinte
{
    public partial class Labirinte : Form
    {
        
        Field field;
        int PlayerCordY;
        int PlayerCordX;
        public Labirinte()
        {
            InitializeComponent();
            field = new Field();
            this.Load += LaodLabirinte;
            pictureBox1.Paint += PaintLabirinte;
            loadMap.Click += LoadMapButtonClick;
        }
        private void LaodLabirinte(object sender, EventArgs e)
        {

            field.LoadMap(@"Map.txt");
            this.KeyPreview = true;
            this.KeyDown += PlayerMove;
            StartPositionPlayer();
        }
        private void PaintLabirinte(object sender, PaintEventArgs e)
        {
            Player(e.Graphics);
            CreateField(e.Graphics);
        }
        private void Wall(Graphics wall,int i,int j)
        {
          wall.FillRectangle(Brushes.Black,new Rectangle(j* field.SizeTile, i* field.SizeTile, field.SizeTile,field.SizeTile));
        }
        private void Player(Graphics player)
        {
            player.FillRectangle(Brushes.Red, new Rectangle(PlayerCordY * field.SizeTile, PlayerCordX * field.SizeTile, 19, 19));
        }
        private void CreateField(Graphics graphics)
        {
            for (int i = 0; i < field.MyField.GetLength(0); i++)
            {
                for (int j = 0; j < field.MyField.GetLength(1); j++)
                {
                    if (field.MyField[i,j]==1)
                    {
                        Wall(graphics,i,j);
                    }
                }
            }
        }
        private void StartPositionPlayer()
        {
            for (int i = 0; i < field.MyField.GetLength(0); i++)
            {
                for (int j = 0; j < field.MyField.GetLength(1); j++)
                {
                    if (field.MyField[i, j] == 2)
                    {
                        PlayerCordX = i;
                        PlayerCordY = j;

                    }
               }
            }
        }
        private void PlayerMove(object sender, KeyEventArgs e)
        {
            int stepX=0;
            int stepY=0;
            switch (e.KeyCode)
            {
                
                case Keys.W:
                    {

                        stepX--;
                        break;
                    }
                case Keys.S:
                    {
                        stepX++;
                        
                        break;
                    }
                case Keys.A:
                    {
                        stepY--;
                        break;
                    }
                    case Keys.D:
                    {
                        stepY++;
                        break;
                    }
                  
            }
            if (field.MyField[PlayerCordX+stepX, PlayerCordY+stepY] != 1)
            {
                PlayerCordX += stepX;
                PlayerCordY += stepY;
                pictureBox1.Invalidate();
            }
            if (field.MyField[PlayerCordX, PlayerCordY] == 4)
            {
                
                
                MessageBox.Show("Victory");
                StartPositionPlayer();
                pictureBox1.Invalidate();
            }
            


        }
        private void LoadMapButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog loadMap = new OpenFileDialog();
            loadMap.Filter = "txt files (*.txt)|*.txt";
            if (loadMap.ShowDialog() == DialogResult.OK)
            {
                field.LoadMap(loadMap.FileName);
                StartPositionPlayer();
                pictureBox1.Refresh();
                path.Text = loadMap.FileName;
               

            };

        }

    }
}
