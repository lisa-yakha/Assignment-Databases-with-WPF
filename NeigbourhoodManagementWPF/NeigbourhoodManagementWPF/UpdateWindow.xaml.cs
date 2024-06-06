using Microsoft.AspNetCore.Components.Forms;
using NeigbourhoodManagementAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NeigbourhoodManagementWPF
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        private static readonly HttpClient client = new HttpClient();
        public UpdateWindow()
        {
            InitializeComponent();
            List<string> complaintStatus = new List<string>();

            foreach (Models.ComplaintForm.Status status in Enum.GetValues(typeof(Models.ComplaintForm.Status)))
            {
                complaintStatus.Add(status.ToString());
            }
            ComplaintStatus.ItemsSource = complaintStatus;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string id = InputID.Text;
            if (ComplaintStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a status.");
                return;
            }
            string status = ComplaintStatus.SelectedIndex.ToString();
            string apiUrl = $"https://localhost:7267/NewStatus?id={Uri.EscapeDataString(id)}&status={Uri.EscapeDataString(status)}";
            try
            {
                var response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var responseMessage = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(responseMessage);
                    Window.GetWindow((Button)sender).Close();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error");
            }

        }

        private void ComplaintCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
