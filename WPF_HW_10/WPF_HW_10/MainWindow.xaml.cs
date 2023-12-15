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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_HW_10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += LoadAnimation;
        }

        private void LoadAnimation(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animationButton = new DoubleAnimation();

            animationButton.From = buttonAnimation.ActualWidth;
            animationButton.To = 300;
            animationButton.Duration = new Duration(TimeSpan.FromSeconds(3));
            animationButton.RepeatBehavior = RepeatBehavior.Forever;
            animationButton.AutoReverse = true;
            buttonAnimation.BeginAnimation(Button.WidthProperty, animationButton);

        }
    }
}
