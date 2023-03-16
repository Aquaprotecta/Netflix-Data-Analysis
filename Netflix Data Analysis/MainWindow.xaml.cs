using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Netflix_Data_Analysis.Core;

namespace Netflix_Data_Analysis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            api_Status();
        }
        private async void api_Status()
        {
            APIHandler apiHandler = new APIHandler();
            string apiUrl = "http://127.0.0.1:5000/status";
            string response = await apiHandler.GetApiResponseAsync(apiUrl);

            if (response != null) 
            {
                API_status.Text = response;
            } else
            {
                API_status.Text = "API is offline.";
            }
        }
       
    }
}
