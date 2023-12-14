using System;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WPF_HW_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }

        private async void DownLoad(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(uri.Text))
            {

                MessageBox.Show("Invalide URL");
                return;
            }
            try
            {
                 
                await DownLoadFile(new Uri(uri.Text));
            }
            catch (Exception)
            {

                throw;
            }

            startDownLoad.IsEnabled = true;
            MessageBox.Show("File is Down Load");
        }

        private async Task DownLoadFile( Uri url)
        {
            startDownLoad.IsEnabled = false;
            using (WebClient web=new WebClient()) {
                web.DownloadProgressChanged += (s, e) => { progressFile.Value = e.ProgressPercentage; };
                byte[] data = await web.DownloadDataTaskAsync(url);
                SeveDataFile(data,System.IO.Path.GetFileName(url.ToString()));
            }
            
        }

        private void  SeveDataFile(byte[] data,string fileName) 
        {
            string fileSave = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
           File.WriteAllBytes(fileSave,data);

        }
    }
}