using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_2
{
    public partial class NotIdenticalLetters : Form
    {
        public NotIdenticalLetters()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var test=incomminTextBox.Text;

            for (int i = 1; i < test.Length; i++)
            {
                if (test[i] == test[i - 1])
                {
                  MessageBox.Show("Only different letters");
                    incomminTextBox.ReadOnly = true;
                }
                else
                {
                    continue;
                }
            }
               

            
        }

        private void clear_Click(object sender, EventArgs e)
        {
            incomminTextBox.ReadOnly = false;
            incomminTextBox.Clear();
        }
    }
}
