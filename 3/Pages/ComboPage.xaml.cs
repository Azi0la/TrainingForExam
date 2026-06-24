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
    /// Логика взаимодействия для ComboPage.xaml
    /// </summary>
    public partial class ComboPage : Page
    {
        public static List<Combos> combos = Core.Context.Combos.ToList();
        public ComboPage()
        {
            InitializeComponent();
            ComboList.ItemsSource = combos;
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack) NavigationService.GoBack();
            MainWindow.combo = null;
        }

        private void ComboList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainWindow.combo = ComboList.SelectedItem as Combos;
            NavigationService.Navigate(new SeatPage());
        }
    }
}
