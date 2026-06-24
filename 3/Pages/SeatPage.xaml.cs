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

namespace _3.Pages
{
    /// <summary>
    /// Логика взаимодействия для SeatPage.xaml
    /// </summary>
    public partial class SeatPage : Page
    {
        public static List<Seats> seats = Core.Context.Seats.ToList();
        public SeatPage()
        {
            InitializeComponent();
            SeatList.ItemsSource = seats;
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack) NavigationService.GoBack();
        }

        private void SeatList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainWindow.seat = SeatList.SelectedItem as Seats;
            NavigationService.Navigate(new OrderPage());
        }
    }
}
