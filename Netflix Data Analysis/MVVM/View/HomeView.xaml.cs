using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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


namespace Netflix_Data_Analysis.MVVM.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private async void SelectFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            openFileDlg.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

            if (openFileDlg.ShowDialog() == true)
            {
                string filePath = openFileDlg.FileName;
                string apiUrl = "http://127.0.0.1:5000/process_csv";

                try
                {
                    using (var client = new HttpClient())
                    {
                        var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath));
                        fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                        {
                            Name = "csv_file",
                            FileName = System.IO.Path.GetFileName(filePath),
                        };

                        var multipartContent = new MultipartFormDataContent();
                        multipartContent.Add(fileContent);

                        HttpResponseMessage response = await client.PostAsync(apiUrl, multipartContent);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("success");
                            string responseContent = await response.Content.ReadAsStringAsync();
                            MessageBox.Show(responseContent);
                        }
                        else
                        {
                            string responseContent = await response.Content.ReadAsStringAsync();
                            MessageBox.Show(responseContent);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
