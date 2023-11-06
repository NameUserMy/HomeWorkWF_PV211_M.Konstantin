using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_1
{
    public partial class Miner : Form
    {
        public Miner()
        {
            InitializeComponent();
            Random rand = new Random();
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                int mine = rand.Next(0, 9);
                tableLayoutPanel1.Controls[mine].Text="mine";
                tableLayoutPanel1.Controls[mine].ForeColor = SystemColors.Control;
                tableLayoutPanel1.Controls[i].Click+=new EventHandler(this.ButtonEvent);
            }
        }

        private void ButtonEvent(object sender,EventArgs e)
        {
            var button= sender as Button;
            if (button.Text.Equals("mine"))
            {
                MessageBox.Show($"explosion");
                this.BackColor = Color.Red;
            }
            else
            {
                int round = 0;
                int index = tableLayoutPanel1.Controls.GetChildIndex(button);

                for (int i = index; i < tableLayoutPanel1.Controls.Count; i++)
                {
                    if (tableLayoutPanel1.Controls[i].Text.Equals("mine"))
                    {
                        round++;

                    }
                }
                tableLayoutPanel1.Controls[index].Text = round.ToString();
            }
        }
    }
}
