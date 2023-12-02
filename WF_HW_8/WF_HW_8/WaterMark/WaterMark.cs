using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_8
{
    public partial class WaterMark : Form
    {
        Bitmap newImage;
        string changeString;
        Font fontString;
        FontDialog fontDialog;
        SolidBrush stringBrush;
        Point position;
        ToolTip message;

        public WaterMark()
        {
            InitializeComponent();
            message = new ToolTip();
            fontString = new Font("Verdana",33);
            stringBrush = new SolidBrush(Color.FromArgb(100,Color.Red));
            ToolStripMenuItem file = new ToolStripMenuItem("Image");
            ToolStripMenuItem open = new ToolStripMenuItem("Open");
            ToolStripMenuItem save = new ToolStripMenuItem("Save");
            ToolStripButton color = new ToolStripButton("color") {
            BackColor = Color.Red,
                
            };
            ToolStripButton font = new ToolStripButton("color")
            {
                Font=new Font("Verdana",8, FontStyle.Bold),
                Text="Pic font"
                //Text=$" size - {Font.Size}, style - {Font.Style} "
            };
            ToolStripTextBox text = new ToolStripTextBox()
            {
                Text = "ENTER STRING",
            };
           
            file.DropDownItems.Add(open);
            file.DropDownItems.Add(save);
            mainMenu.Items.Add(file);
            mainMenu.Items.Add(text);
            mainMenu.Items.Add(color);
            mainMenu.Items.Add(font);
            pictureBox1.Paint += WaterPaint;
            pictureBox1.MouseMove += ChangeLocation;
            open.Click += OpenImage;
            save.Click += SaveImage;
            text.TextChanged += TextChangeValue;
            changeString = mainMenu.Items[1].Text;
            mainMenu.Items[2].Click+=ColorSetString;
            mainMenu.Items[3].Click += SettingsFont;
        }

        private void ChangeLocation(object sender, MouseEventArgs e)
        {
            
            if (e.Button== MouseButtons.Left)
            {
                position = e.Location;
                this.Refresh();
            }
            
        }
        private void SettingsFont(object sender, EventArgs e)
        {
            fontDialog = new FontDialog();
            fontDialog.ShowDialog();
            fontString = fontDialog.Font;
            this.Refresh();
        }
        private void ColorSetString(object sender, EventArgs e)
        {
            ColorDialog pickColor = new ColorDialog();
            pickColor.ShowDialog();
            mainMenu.Items[2].BackColor = pickColor.Color;
            stringBrush.Color = pickColor.Color;
            pictureBox1.Refresh();
        }
        private void TextChangeValue(object sender, EventArgs e)
        {
            changeString = mainMenu.Items[1].Text;
            pictureBox1.Refresh();
        }
        private void WaterPaint(object sender, PaintEventArgs e)
        {
            
            if (newImage != null)
            {
                Graphics grafic = e.Graphics;
                grafic.DrawString(changeString,fontString, stringBrush,position.X/2,position.Y);
               

            }

        }
        private void OpenImage(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "(*.jpg)|*.jpg|(*.png)|*.png|(*.bmp)|*.bmp|(*.gif)|*.gif|All files(*.*)|*.*";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                newImage = new Bitmap(openFile.FileName);
                pictureBox1.Image = newImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            pictureBox1.Refresh();
            message.SetToolTip(pictureBox1, "Для перетаскивания строки зажмите ЛКМ");
        }
         private void SaveImage(object sender, EventArgs e)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.ShowDialog();

                newImage.Save(saveFile.FileName);
            }
    }
}