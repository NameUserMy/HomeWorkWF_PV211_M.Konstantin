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

namespace WF_HW_2
{
    public partial class SaveText : Form
    {
        string nameFile;
        public SaveText()
        {
            InitializeComponent();
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            nameFile = fileName.Text;
            using (StreamWriter writer = new StreamWriter(nameFile+".txt", false))
            {
                writer.WriteLineAsync(incommingText.Text);
                this.Text = "Your file is save";
            }
        }
    }
}
