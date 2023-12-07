using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_9.Diagram
{
    public partial class Diagram : Form
    {
        int width;
        int height;
        int positionX;
        Rectangle rect;
        Rectangle rect1;
        Rectangle rect2;
        Rectangle rect3;

        Timer timer;
        public Diagram()
        {
            InitializeComponent();
            width = 200;
            height = 0;
            positionX = pictureGrafic.Width / 2;
             rect = new Rectangle(positionX, pictureGrafic.Height - height, width, height);
             rect1 = new Rectangle(positionX +rect.Width-40, pictureGrafic.Height - height, width - 50, height);
             rect2 = new Rectangle(positionX - rect.Width+45, pictureGrafic.Height - height, width - 30, height);
             rect3 = new Rectangle(rect1.X-20, pictureGrafic.Height - height,60, height);




            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
            pictureGrafic.Paint += PaintGrafic;
            graficButton.Click += PaintGraficButtonClick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (rect.Y !=80)
            {
                rect.Height += timer.Interval;
                rect.Y -= timer.Interval;
                pictureGrafic.Invalidate();
            }
            if (rect1.Y != 150)
            {
                rect1.Height += timer.Interval;
                rect1.Y -= timer.Interval;
                pictureGrafic.Invalidate();

            }
            if (rect3.Y != 250)
            {
                rect3.Height += timer.Interval;
                rect3.Y -= timer.Interval;
                pictureGrafic.Invalidate();

            }
            if (rect2.Y != 300)
            {
                rect2.Height += timer.Interval;
                rect2.Y -= timer.Interval;
                pictureGrafic.Invalidate();

            }

        }

        private void PaintGraficButtonClick(object sender, EventArgs e)
        {
            
            timer.Start();
           

        }

        private void PaintGrafic(object sender, PaintEventArgs e)
        {
            Graphics graf = e.Graphics;
            graf.FillRectangle(Brushes.Azure, rect);
            
            graf.FillRectangle(Brushes.Chocolate, rect2);
            graf.FillRectangle(Brushes.Gray, rect1);
            graf.FillRectangle(Brushes.CadetBlue, rect3);
        }


    }
}
