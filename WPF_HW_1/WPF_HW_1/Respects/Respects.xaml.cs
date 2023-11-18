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

namespace WPF_HW_1.Respects
{
    /// <summary>
    /// Interaction logic for Respects.xaml
    /// </summary>
    public partial class Respects : Window
    {
        public Respects()
        {
            InitializeComponent();
            choiceRespects = new List<string>();
        }

        private void ShowClickButton(object sender, EventArgs e)
        {
            string gameChoice =  game.Children.OfType<RadioButton>().FirstOrDefault(x => x.IsChecked == true)?.Content.ToString();
            string bookChoice =  book.Children.OfType<RadioButton>().FirstOrDefault(x => x.IsChecked == true)?.Content.ToString();
            string cofeChoice =  cofe.Children.OfType<RadioButton>().FirstOrDefault(x => x.IsChecked == true)?.Content.ToString();
            choiceRespects.Add(gameChoice);
            choiceRespects.Add(bookChoice);
            choiceRespects.Add(cofeChoice);
            showRespectsListBox.ItemsSource = choiceRespects;
        }

        private void ResetButtonClick(object sender, EventArgs e)
        {
             cofe.Children.OfType<RadioButton>().FirstOrDefault(x=>x.IsChecked==true).IsChecked=false;
             cofe.Children.OfType<RadioButton>().FirstOrDefault().IsChecked=true;
            book.Children.OfType<RadioButton>().FirstOrDefault(x => x.IsChecked == true).IsChecked = false;
            book.Children.OfType<RadioButton>().FirstOrDefault().IsChecked = true;
            game.Children.OfType<RadioButton>().FirstOrDefault(x => x.IsChecked == true).IsChecked = false;
            game.Children.OfType<RadioButton>().FirstOrDefault().IsChecked = true;
            choiceRespects.Clear();
            showRespectsListBox.ItemsSource = "";
        }
        List<string> choiceRespects;
       
    }
}
