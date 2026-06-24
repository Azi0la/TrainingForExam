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
    /// Логика взаимодействия для SaladPage.xaml
    /// </summary>
    public partial class SaladPage : Page
    {

        public static List<Dishes> dishes = Core.Context.Dishes.ToList();
        public SaladPage()
        {
            InitializeComponent();

            SaladList.ItemsSource = dishes.Where(p => p.TypeID == 11);
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack) NavigationService.GoBack();
            MainWindow.salad = null;
        }

        private void SkipBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DrinkPage());
            MainWindow.salad = null;
        }

        private void SecondList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainWindow.salad = SaladList.SelectedItem as Dishes;
            NavigationService.Navigate(new DrinkPage());
        }
    }
}
