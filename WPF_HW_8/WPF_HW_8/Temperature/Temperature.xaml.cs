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
using System.Windows.Forms.DataVisualization;
using WPF_HW_8.Temperature.Model;

namespace WPF_HW_8.Temperature
{
    /// <summary>
    /// Interaction logic for Temperature.xaml
    /// </summary>
    public partial class Temperature : Window
    {
        Day monday;
        Day[] week;
        public Temperature()
        {
            
            
            
            InitializeComponent();
            week = new Day[7];
            monday = new Day();
           
            
           
            Loaded += LoadetTemperature;
           
        }

        private void LoadetTemperature(object sender, RoutedEventArgs e)
        {
            
            WeekComboBox.SelectionChanged += ChoiceDay;
            week[0]=  new Day("Mondey",new double[12] {10.25,22.3,33,25.5,10,15,22,8,6,28,33,5});
            week[1]=  new Day("Tuesday", new double[12] { 10, 22, 33, 25, 0, 15, 28, 8, 6, 28, 33, 5 });
            week[2]=  new Day("Wednesday", new double[12] { 10.8, 22, 33.2, 25.5, 10, 15, 22, 8, 6, -2, 33, 5 });
            week[3]=  new Day("Thursday", new double[12] { 10.8, 22, 0.1, 25.5, 10, 15, 22, 8, 6, -2, 33, 5 });
            week[4]=  new Day("Friday", new double[12] { 10.8, 22, 33.2, 25.5, 10, 15, 22, 8, 6, -2, 33, 5 });
            week[5]=  new Day("Saturday ", new double[12] { 10.8, 22, 33.2, 18, 10, 15, 22, 8, 6, -2, 33, 5 });
            week[6]=  new Day("Sunday", new double[12] { 10.8, 22, 33.2, 25.5, 10, 13, 22, 8, 6, -2, 33, 5 });
            
            WeekComboBox.ItemsSource = week;
            WeekComboBox.SelectedItem = true;
            WeekComboBox.SelectedIndex = 0;
        }

        private void ChoiceDay(object sender, SelectionChangedEventArgs e)
        {
            temperature.Series[0].Points.Clear();
            for (int i = 0; i < week[WeekComboBox.SelectedIndex].Temperature.Length; i++)
            {
                temperature.Series[0].Points.Add(week[WeekComboBox.SelectedIndex].Temperature[i]).AxisLabel = $"{week[WeekComboBox.SelectedIndex].DayOfWeek} temp ";
            }
            
        }
    }
}
