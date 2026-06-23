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

namespace test2.Pages
{
    /// <summary>
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        public static List<Hotels> hotels = Core.Context.Hotels.ToList();
        public CatalogPage()
        {
            InitializeComponent();
            HotelList.ItemsSource = hotels;
        }

        private void SearchBTN_Click(object sender, RoutedEventArgs e)
        {
            if (SearchTB != null)
            {
                List<Hotels> nh = hotels.Where(p => p.Name.ToLower().Contains(SearchTB.Text.ToLower())).ToList();
                HotelList.ItemsSource = nh;
            }
            else
            {
                HotelList.ItemsSource = hotels;
            }
        }

        private void HotelList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new HotelPage(HotelList.SelectedItem as Hotels));
        }
    }
}
