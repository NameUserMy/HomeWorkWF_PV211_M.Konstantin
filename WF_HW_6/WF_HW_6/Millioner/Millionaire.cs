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
    public partial class Millionaire : Form
    {
        public Millionaire()
        {
            InitializeComponent();
            playButton.Click += StartGameButton;
        }

        private void StartGameButton(object sender, EventArgs e)
        {
            Questions startGameWindow = new Questions();
            startGameWindow.ShowDialog();
        }
    }
}
