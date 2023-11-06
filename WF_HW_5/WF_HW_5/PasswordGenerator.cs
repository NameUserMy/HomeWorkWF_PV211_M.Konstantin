using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_5
{
    public partial class PasswordGenerator : Form
    {
        Generator gen;
        List<int> sendCheck;
        bool noRepeat;
        int[] length;
        string[] message;
        public PasswordGenerator()
        {
            length = new int[]{ 9, 24, 24, 14 };
            message = new string[] {"Max len 9","max len 24", "max len 24", "max len 14" };
            InitializeComponent();
            noRepeat = false;
            sendCheck = new List<int>();
            gen = new Generator();
        }

        private void generation_Click(object sender, EventArgs e)
        {
            var send= setings.Controls.OfType<CheckBox>().Select(x => x).ToList();
            sendCheck.Clear();
            forGeneration(send);
            if (sendCheck.Count==0)
            {
                if (selfGeneration.Text.Length >= 4)
                {
                    password.Items.Clear();
                    for (int i = 0; i < 10; i++)
                    {
                        password.Items.Add(gen.DerParolForSelf(selfGeneration.Text));
                    }
                }
                else { MessageBox.Show("Min 4 simbols focus");}
                
            }
            else 
            {
                if (sendCheck.Count == 1)
                {
                    selfGeneration.Clear();
                    CheckLength(sendCheck[0]);
                }
                if (sendCheck.Count > 0 && countSimbol.Value <= countSimbol.Maximum)
                {
                    noRepeat = send[0].Checked ? true : false;
                    password.Items.Clear();
                    for (int i = 0; i < 10; i++)
                    {
                        password.Items.Add(gen.DerParol(Convert.ToInt32(countSimbol.Value), sendCheck, noRepeat));
                    }
                }
                else { MessageBox.Show("No parameters selected!"); }

            }
             
           
            
        }
        List<int>  forGeneration(List<CheckBox> send)
        {
            foreach (var item in send)
            {
                if (item.Checked && Convert.ToInt32(item.Tag) != 4)
                    sendCheck.Add(Convert.ToInt32(item.Tag));
            }
            return sendCheck;
        }
        void CheckLength(int tag)
        {
            if (countSimbol.Value > length[tag])
            {
                countSimbol.Value = length[tag];
                MessageBox.Show(message[tag]);
            }
        }
        void LockUnlock(bool access)
        {
            foreach (var item in setings.Controls.OfType<CheckBox>().Select(x => x))
            {
              item.Checked = access;
            };
            countSimbol.Enabled = access;
        }
        private void selfGenerationEnter(object sender, EventArgs e)
        {
            LockUnlock(false);
        }

        private void numbers_CheckedChanged(object sender, EventArgs e)
        {
            selfGeneration.Clear();
            countSimbol.Enabled = true;
        }
    }
}
