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
    /// Interaction logic for ByNameWindow.xaml
    /// </summary>
    public partial class ByNameWindow : Window
    {
        private static readonly HttpClient client = new HttpClient();
        public ByNameWindow()
        {
            InitializeComponent();
        }

        private void InputName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = InputName.Text;
            string apiUrl = $"https://localhost:7267/ByName?name={Uri.EscapeDataString(name)}";
            try
            {
                var response = await client.GetAsync( apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var complaintResult = JsonSerializer.Deserialize<List<Models.ComplaintForm>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    DataGridComplaints.ItemsSource = complaintResult;
                    MessageBox.Show("Search completed.");
                    Window.GetWindow((Button)sender).Close();
                }
                else
                {
                    MessageBox.Show("Error.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred");
            }

        }
    }
}
