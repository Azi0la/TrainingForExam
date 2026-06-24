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
    /// Логика взаимодействия для SoupPage.xaml
    /// </summary>
    public partial class SoupPage : Page
    {
        public static List<Dishes> dishes = Core.Context.Dishes.ToList();
        public SoupPage()
        {
            InitializeComponent();
            SoupList.ItemsSource = dishes.Where(p => p.TypeID == 9);
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if(NavigationService.CanGoBack) NavigationService.GoBack();
            MainWindow.soup = null;
        }

        private void SkipBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SecondPage());
            MainWindow.soup = null;
        }

        private void SoupList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new SecondPage());
            MainWindow.soup = SoupList.SelectedItem as Dishes;
        }
    }
}
