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

namespace NeigbourhoodManagementWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void New_Complaint_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow newComplaint = new SecondWindow();
            newComplaint.Show();
        }

        private void By_Name_Click(object sender, RoutedEventArgs e)
        {
            ByNameWindow byName = new ByNameWindow();
            byName.Show();
       
        }

        private void By_Date_Click(object sender, RoutedEventArgs e)
        {
            ByDateWindow byDate = new ByDateWindow();
            byDate.Show();

        }

        private void Status_Click(object sender, RoutedEventArgs e)
        {
            UpdateWindow updateWindow = new UpdateWindow();
            updateWindow.Show();

        }
    }
}