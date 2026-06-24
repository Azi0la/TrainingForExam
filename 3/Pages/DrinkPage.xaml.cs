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
    /// Логика взаимодействия для DrinkPage.xaml
    /// </summary>
    public partial class DrinkPage : Page
    {

        public static List<Dishes> dishes = Core.Context.Dishes.ToList();
        public DrinkPage()
        {
            InitializeComponent();
            DrinkList.ItemsSource = dishes.Where(p => p.TypeID == 12);
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if(NavigationService.CanGoBack) NavigationService.GoBack();
            MainWindow.drink = null;

        }

        private void SkipBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderPage());
            MainWindow.drink = null;

        }

        private void DrinkList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainWindow.drink = DrinkList.SelectedItem as Dishes;
            NavigationService.Navigate(new SeatPage());
        }
    }
}
