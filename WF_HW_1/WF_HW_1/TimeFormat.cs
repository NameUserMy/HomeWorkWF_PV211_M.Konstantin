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
    public partial class TimeFormat : Form
    {
        public TimeFormat()
        {
            InitializeComponent();
            _timer.Interval=Convert.ToInt32(_setPeriodicity.Value)*1000;
            _timer.Tick +=renderTime;
            _timer.Start();
        }
        private void renderTime(object sender, EventArgs e)
        {
            _=(_format12.Checked)? _time.Text = DateTime.Now.ToString("hh:mm:ss")
                : _time.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void _setPeriodicity_ValueChanged(object sender, EventArgs e)
        {
            _timer.Interval = Convert.ToInt32(_setPeriodicity.Value) * 1000;
            _timer.Start();
        }
    }
}
