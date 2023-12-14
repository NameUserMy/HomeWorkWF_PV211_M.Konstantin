using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_HW_3
{
    /// <summary>
    /// Логика взаимодействия для ProductsList.xaml
    /// </summary>
    public partial class ProductsList : Window
    {
        
        List<Products> myProducts;
        AddProduct infoProduct;
        public ProductsList()
        {
            InitializeComponent();
            this.Loaded += LoadetApplication;
            myProducts = new List<Products>();
        }

        private void LoadetApplication(object sender, RoutedEventArgs e)
        {
            myProducts.Add(new Products("My first product", 750, "lskjdfksajlfkjlsakmfkljaslkdfm;laslkdfjlkasndfklmasmflkasjlfma;slmflkvjsmaflks"));
            products.Items.Add(new Expander()
            {
                Header = myProducts.ElementAt(0).GetTitle,
                Content = new TextBox() { Text = myProducts.ElementAt(0).ToString(), TextWrapping = TextWrapping.Wrap, Width = 350,Background=Brushes.BurlyWood, IsReadOnly = true },
            });
        }
        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProduct productIfo = new AddProduct();
            productIfo.ShowDialog();
           
            if (productIfo.DialogResult == true)
            {
                products.Items.Clear();

                myProducts.Add(new Products(productIfo.titleText.Text,Convert.ToDecimal(productIfo.price.Text), productIfo.description.Text));

                for (int i = 0; i < myProducts.Count; i++)
                {
                    products.Items.Add(new Expander()
                    {
                        Header = myProducts.ElementAt(i).GetTitle,
                        Content = new TextBox() { Text = myProducts.ElementAt(i).ToString(), TextWrapping = TextWrapping.Wrap, Width = 350, Background = Brushes.BurlyWood, IsReadOnly = true }
                    });
                }
            }
        }

        private void deleteProduct_Click(object sender, RoutedEventArgs e)
        {

            myProducts.RemoveAt(products.SelectedIndex);
            products.Items.Clear();
            for (int i = 0; i < myProducts.Count; i++)
            {
                products.Items.Add(new Expander()
                {
                    Header = myProducts.ElementAt(i).GetTitle,
                    Content = new TextBox() { Text = myProducts.ElementAt(i).ToString(), 
                    TextWrapping = TextWrapping.Wrap, Width = 350, Background = Brushes.BurlyWood, IsReadOnly = true },
                }); 
            };

        }

        
    }
}
