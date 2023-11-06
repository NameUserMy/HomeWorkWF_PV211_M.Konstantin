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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
            
        }

        private void AddUserB(object sender,EventArgs e)
        {
            _userListBox.Items.Add(new User(_nameTextBox.Text, _countryTextBox.Text,
           Convert.ToInt32(_ageNumUPDown.Value), Convert.ToInt32(_weightNumUPDown.Value)));
        }
    }
}
