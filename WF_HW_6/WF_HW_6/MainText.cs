using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_6
{
    public partial class MainText : Form
    {
        public MainText()
        {
            InitializeComponent();
            this.Load += LoadMain;
        }

        private void LoadMain(object sender, EventArgs e)
        {
            loadButton.Click += LoadFileButton;
            editButton.Click += EditFileButton;
        }

        private void LoadFileButton(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Only (*.txt)|*.txt";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                mainTextBox.Text = System.IO.File.ReadAllText(openFile.FileName);
                filePath.Text = openFile.FileName;
                editButton.Enabled = true;

            }
        }
        private void EditFileButton(object sender, EventArgs e)
        {
            EditFile editFileWindow = new EditFile(this);
            editFileWindow.Show();
        }

        public string MainTextEdit { get { return mainTextBox.Text; } set { mainTextBox.Text = value; } }
    }
}
