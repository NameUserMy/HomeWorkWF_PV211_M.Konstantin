using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_8.RandomElips
{
    public partial class RandomElips : Form
    {
        Random rand;
        int width;
        public RandomElips()
        {
            InitializeComponent();
           this.MouseClick += RandomElipsDraw;
            rand = new Random();
        }

        private void RandomElipsDraw(object sender, MouseEventArgs e)
        {
            width = rand.Next(120);
            
            DrawElips(e.X,e.Y);

        }
        void DrawElips(int x,int y)
        {
            Graphics graf = this.CreateGraphics();
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255,rand.Next(255),rand.Next(255),rand.Next(255)));
          graf.FillEllipse(solidBrush,new Rectangle(x-(width/2),y- (width / 2), width,width));
        }


    }
}
