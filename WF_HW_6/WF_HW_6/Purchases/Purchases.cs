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
    public partial class Purchases : Form
    {




        ObservableCollection<Product> products;
        List<string> titleCategory;
        Total bill;
        public Purchases()
        {

            InitializeComponent();
            bill = new Total();
            titleCategory = new List<string> { "LepTop", "TepTop" };
            products = new ObservableCollection<Product> {new Product("Lenovo -SL01","Super Leptop","LepTop",30),
                                       new Product("Super -SL01", "Super", "LepTop", 100),
            new Product("Super -SL01", "Super", "TepTop", 25)};

            this.Load += LoadMy;
        }



        private void LoadMy(object sender, EventArgs e)
        {
            this.CenterToScreen();
            goots.SelectedIndexChanged += ItemChoice;
            CBcategories.SelectedIndexChanged += ChoiceCategory;
            CBcategories.DataSource = titleCategory;
            CBcategories.SelectedIndex = 0;

            details.ReadOnly = true;
            details.DataSource = SelectProducts();
            editProduct.Click += EditProductButton;
        }
        private void EditProductButton(object sender, EventArgs e)
        {
            if (details.Rows.Count > 0)
            {

                MessageBox.Show("Удалите товары");
            }
            else
            {
                EditProducts editProducts = new EditProducts(this);

                editProducts.Show();
            }
        }
        private void ItemChoice(object sender, EventArgs e)
        {
            details.DataSource = SelectProducts();
            total.Text = bill.test(SelectProducts()).ToString();
        }
        private void ChoiceCategory(object sender, EventArgs e)
        {
            
            goots.DataSource = products.Where(x => x.Category.Equals(CBcategories.SelectedItem)).ToArray();
        }
        private void сheckout_Click(object sender, EventArgs e)
        {
            Order windowOrder = new Order(SelectProducts(), bill.test(SelectProducts()).ToString());
            windowOrder.ShowDialog();
        }
        private List<Product> SelectProducts()
        {
            var selectedProduct = goots.CheckedItems.OfType<Product>().ToList();
            return selectedProduct;
        }
        public void AddProduc()
        {

            products.Add(new Product("Some Neme", "About", "Category", 0));
        }
        public void UppDateCategory()
        {
            var newCategory = GetProduct().Select(x => x.Category).Distinct();
            CBcategories.DataSource = newCategory.ToArray();
        }
        public List<Product> GetProduct(){
            return products.ToList();
        }
    }
}
