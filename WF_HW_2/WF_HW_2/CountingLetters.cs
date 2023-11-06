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
    public partial class CountingLetters : Form
    {
        int count;
        public CountingLetters()
        {
            InitializeComponent();
        }

        private void incommingString_TextChanged(object sender, EventArgs e)
        {
            var text=incommingString.Text.Select(x => x);
            foreach (var item in text)
            {
                if (item.Equals('a')||item.Equals('b'))
                {
                    count++;
                    countLetеer.Text = count.ToString();
                }
            }
            count = 0;
        }
    }
}
