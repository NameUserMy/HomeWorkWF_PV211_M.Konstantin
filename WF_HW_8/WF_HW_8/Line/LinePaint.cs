using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_8.Line
{
    public partial class LinePaint : Form
    {
        private Point startPosition;
        private Point endPosition;
        public LinePaint()
        {
            InitializeComponent();
            this.MouseMove += ForDrawLine;
            this.MouseDown += StarPoint;
           
           
        }

        private void DStarPoint(object sender, MouseEventArgs e)
        {
            DrawLine(startPosition, endPosition);
        }
        private void StarPoint(object sender, MouseEventArgs e)
        {
            startPosition = e.Location;
        }
        private void ForDrawLine(object sender, MouseEventArgs e)
        {
           
            if (e.Button == MouseButtons.Left)
            {
                endPosition = e.Location;
                this.Refresh();
                DrawLine(startPosition, endPosition);

            }
            

            
        }
        void DrawLine(Point startPositionX=new Point(), Point endPositionY = new Point())
        {
           
            Graphics graf = this.CreateGraphics();
            graf.DrawLine(Pens.Black,startPositionX, endPosition);
        }

    }
}
