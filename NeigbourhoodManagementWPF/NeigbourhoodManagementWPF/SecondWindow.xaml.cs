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
using NeigbourhoodManagementAPI;


namespace NeigbourhoodManagementWPF
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        private static readonly HttpClient client = new HttpClient();

        public SecondWindow()
        {
            InitializeComponent();
            List<string> complaintCategories = new List<string>();

            foreach (Models.ComplaintForm.Category category in Enum.GetValues(typeof(Models.ComplaintForm.Category)))
            {
                complaintCategories.Add(category.ToString());
            }
            ComplaintCategory.ItemsSource = complaintCategories;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var complaint = new Models.ComplaintForm
            {
                NameOfAuthor = Name.Text,
                BuildingNumberOfAuthor = int.Parse(BuildingNumber.Text),
                ApartmentNumberOfAuthor = int.Parse(ApartmentNumber.Text),
                Description = Description.Text,
                BuildingNumberOfComplaint = int.Parse(ComplaintBuildingNumber.Text),
                ApartmentNumberOfComplaint = int.Parse(ComplaintApartmentNumber.Text),
                ComplaintCategory = (Models.ComplaintForm.Category)Enum.Parse(typeof(Models.ComplaintForm.Category), ComplaintCategory.SelectedItem.ToString()),
            };

            string apiUrl = "https://localhost:7267/NewComplaint";
            var json = JsonSerializer.Serialize(complaint);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(apiUrl, data);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Complaint submitted successfully.");
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComplaintCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
