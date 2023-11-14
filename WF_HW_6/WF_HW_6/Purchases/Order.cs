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
    public partial class Order : Form
    {
        string ID;
        public Order(List<Product> order,string totlPrice)
        {
            InitializeComponent();
            totalOrder.Text = totlPrice;
            orderDG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            orderDG.ReadOnly = true;
            orderDG.DataSource = order;
            this.CenterToScreen();
            this.Width = orderDG.Width+40;
        }

        private void accept_Click(object sender, EventArgs e)
        {
            ID = Guid.NewGuid().ToString();
            var result=MessageBox.Show($"Номер вашего заказа  {ID}","some",MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void refusal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
