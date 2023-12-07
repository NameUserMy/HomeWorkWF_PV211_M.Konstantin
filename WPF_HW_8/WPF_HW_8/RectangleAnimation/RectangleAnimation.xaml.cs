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
using System.Windows.Shapes;

namespace WPF_HW_8.RectangleAnimation
{
    /// <summary>
    /// Interaction logic for RectangleAnimation.xaml
    /// </summary>
    public partial class RectangleAnimation : Window
    {
        public RectangleAnimation()
        {
            InitializeComponent();
            DoubleAnimation rectangleAnimation = new DoubleAnimation();
            rectangleAnimation.From = 0;
            rectangleAnimation.To = 800 - rect.Width;
            rectangleAnimation.Duration = TimeSpan.FromSeconds(3);
            rectangleAnimation.RepeatBehavior = new RepeatBehavior(3);
            rectangleAnimation.AutoReverse = true;
            forAnimationTranslate.BeginAnimation(TranslateTransform.XProperty, rectangleAnimation);
        }

        
    }
}
