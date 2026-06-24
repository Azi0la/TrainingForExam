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
    /// Логика взаимодействия для SecondPage.xaml
    /// </summary>
    public partial class SecondPage : Page
    {
        public static List<Dishes> dishes = Core.Context.Dishes.ToList();
        public SecondPage()
        {
            InitializeComponent();
            SecondList.ItemsSource = dishes.Where(p => p.TypeID == 10);
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack) NavigationService.GoBack();
            MainWindow.second = null;
        }

        private void SkipBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SaladPage());
            MainWindow.second = null;
        }

        private void SecondList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainWindow.second = SecondList.SelectedItem as Dishes;
            NavigationService.Navigate(new SaladPage());
        }
    }
}
