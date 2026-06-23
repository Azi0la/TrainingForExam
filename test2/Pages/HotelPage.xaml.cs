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
    /// Логика взаимодействия для HotelPage.xaml
    /// </summary>
    public partial class HotelPage : Page
    {
        private Hotels h;
        public List<Reviews> reviews = Core.Context.Reviews.ToList();
        public HotelPage(Hotels _h)
        {
            InitializeComponent();
            DataContext = _h;
            h = _h;
            
            ReviewList.ItemsSource = reviews.Where(p => p.HotelId == h.HotelId).ToList();
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if(NavigationService.CanGoBack) NavigationService.GoBack();
        }

        private void ClearTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrEmpty(ClearTB.Text) && !string.IsNullOrEmpty(ServiceTB.Text) && !string.IsNullOrEmpty(PlaceTB.Text) 
                && !string.IsNullOrEmpty(PriceTB.Text) && !string.IsNullOrEmpty(FoodTB.Text))
            {
                SendBTN.IsEnabled = true;
            }
        }

        private void SendBTN_Click(object sender, RoutedEventArgs e)
        {
            float a = float.Parse(ClearTB.Text);
            float b = float.Parse(ServiceTB.Text);
            float c = float.Parse(PlaceTB.Text);
            float d = float.Parse(PriceTB.Text);
            float f = float.Parse(FoodTB.Text);
            Reviews rev = new Reviews
            {
                HotelId = h.HotelId,
                UserId = MainWindow.user.UserId,
                OverallRating = ((a + b + c + d + f) / 5)
            };
            Core.Context.Reviews.Add(rev);
            Core.Context.SaveChanges();
            MessageBox.Show("Комментарий отправлен!");
            NavigationService.Navigate(new CatalogPage());
        }
    }
}
