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
    public partial class Deposit : Form
    {
        decimal profit;
        public Deposit()
        {
            InitializeComponent();
        }
        private void calculate_Click(object sender, EventArgs e)
        {
            decimal periods = Convert.ToDecimal(period.Controls.OfType<RadioButton>().FirstOrDefault(x => x.Checked).Tag);
            profit = Math.Round(sum.Value * ((rate.Value/100)/12)*periods);
            result.Text = Convert.ToString(profit+sum.Value);
        }
    }
}
