using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_HW_1
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] titleButton;
        Button button;
        public MainWindow()
        {
            InitializeComponent();
            InitializedLibrary();
               this.Loaded += LoadApp;
            titleButton = new string[] 
            { "CE","C","<","/","7","8","9","*","4","5"
                ,"6","-","1","2","3","+",".","0","="};
            this.ResizeMode =ResizeMode.NoResize;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private async void InitializedLibrary()
        {
            await CSharpScript.EvaluateAsync("7+15", ScriptOptions.Default.WithImports("System.Math"));
        }
        private void LoadApp(object sender, RoutedEventArgs e)
        {
            resultTextBox.Text = "0";
            FillButton();
            EventSet();
        }
        private void FillButton()
        {
            int step = 0;
            for (int i = 0; i < UI.RowDefinitions.Count; i++)
            {
                 for (int j = 0; j <UI.ColumnDefinitions.Count; j++)
                    {
                    button = new Button()
                    {
                        Content = titleButton[step],
                        Margin = new Thickness(3, 3, 3, 3),
                        FontSize = 15,
                        FontWeight = FontWeights.Bold,
                        Background= new SolidColorBrush(Colors.DarkOrange),
                        Opacity = 0.65,

                    };
                        step++;
                        if (i == 4 && j == 3)
                        {
                           continue;
                        }
                        UI.Children.Add(button);
                        Grid.SetRow(button, i);
                        Grid.SetColumn(button, j);
                        if (i == 4 && j == 2)
                        {
                            step --;
                            Grid.SetColumnSpan(button, 2);

                        }
                    
                 }
            }

        }
        private void EventSet()
        {
           var buttons  = UI.Children;
            for (int i = 3; i < buttons.Count-1; i++)
            {
              var operationButton= buttons[i] as Button;
                operationButton.Click += OperationClickButton;
            }

              var buttonCE= buttons[0] as Button;
              var buttonC= buttons[1] as Button;
              var buttonBack= buttons[2] as Button;
              var buttonResult= buttons[18] as Button;
              buttonCE.Click += ClearResultClickButton;
              buttonC.Click += ClearAllClickButton;
              buttonBack.Click += BackSpaceClickButton;
              buttonResult.Click += ResultClicButton;
        }

        private async void ResultClicButton(object sender, RoutedEventArgs e)
        {
             var result= await CSharpScript.EvaluateAsync(arithmeticTextBox.Text, ScriptOptions.Default.WithImports("System.Math"));
             resultTextBox.Text = result.ToString();
        }
        private void BackSpaceClickButton(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(arithmeticTextBox.Text))
           arithmeticTextBox.Text=arithmeticTextBox.Text.Remove(arithmeticTextBox.Text.Length - 1,1);
            
        }
        private void ClearAllClickButton(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(arithmeticTextBox.Text))
            {
                arithmeticTextBox.Clear();
                resultTextBox.Text = "0";
            }
           
        }
        private void ClearResultClickButton(object sender, RoutedEventArgs e)
        {
            if (resultTextBox.Text != "0")
            {
                resultTextBox.Text ="0";
            }
           
           
        }
        private void OperationClickButton(object sender, RoutedEventArgs e)
        {
            var buttonContent = sender as Button;
            arithmeticTextBox.Text += buttonContent.Content.ToString();
        }
    }
}
