using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_HW_6
{
    public partial class EditProducts : Form
    {
        Purchases name;
        public EditProducts(Purchases name)
        {
            this.name = name;
            InitializeComponent();
        }
        private void EditProducts_Load(object sender, EventArgs e)
        {
            editDG.DataSource = name.GetProduct();
            this.CenterToScreen();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            name.AddProduc();
            editDG.DataSource = name.GetProduct();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name.UppDateCategory();
            this.Close();
        }
    }
}
