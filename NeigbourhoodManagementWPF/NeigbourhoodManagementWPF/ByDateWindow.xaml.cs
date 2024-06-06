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
    /// Interaction logic for ByDateWindow.xaml
    /// </summary>
    public partial class ByDateWindow : Window
    {
        private static readonly HttpClient client = new HttpClient();
        public ByDateWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string year = InputYear.Text;
            string month = InputMonth.Text;
            string day = InputDay.Text;
            string apiUrl = $"https://localhost:7267/ByDate?date={Uri.EscapeDataString(year)}-{Uri.EscapeDataString(month)}-{Uri.EscapeDataString(day)}";
            try
            {
                var response = await client.GetAsync(apiUrl);
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
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error or invalid date");
            }

        }
    }
}
