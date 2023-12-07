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

namespace WPF_HW_8.Flat
{
    /// <summary>
    /// Interaction logic for Flat.xaml
    /// </summary>
    public partial class Flat : Window
    {
        public Flat()
        {
            InitializeComponent();
        }

        private void Path_MouseDown(object sender, MouseButtonEventArgs e)
        {

            var pathName = e.OriginalSource as Path;
            switch (pathName.Name)
            {
                case "kitchen":
                    {
                        MessageBox.Show(textBlockKitchen.Text);
                        break;
                    }
                case "corridor":
                    {
                        MessageBox.Show(textBlockCorridor.Text);
                        break;
                    }
                case "bedroom":
                    {
                        MessageBox.Show(textBlockBedroom.Text);
                        break;
                    }
                case "hall":
                    {
                        MessageBox.Show(textBlockHall.Text);
                        break;
                    }



            }



        }
    }
}
