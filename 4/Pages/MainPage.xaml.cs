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

namespace _4.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public static List<Parts> parts = Core.Context.Parts.ToList();
        public MainPage()
        {
            InitializeComponent();
            //kLB.ItemsSource = parts.Where(p => p.CategoryId == 1).ToList();
            //dLB.ItemsSource = parts.Where(p => p.CategoryId == 2).ToList();
            //kpLB.ItemsSource = parts.Where(p => p.CategoryId == 3).ToList();
            //klLB.ItemsSource = parts.Where(p => p.CategoryId == 4).ToList();
            //sLB.ItemsSource = parts.Where(p => p.CategoryId == 5).ToList();
            //eLB.ItemsSource = parts.Where(p => p.CategoryId == 6).ToList();
        }

        private void CompatBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SavedBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Butt1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is TabControl tc && tc.SelectedItem is TabItem tab && tab.Tag != null) 
            {
                int CategoryID = int.Parse(tab.Tag.ToString());
                PartsLB.ItemsSource = parts.Where(p => p.CategoryId == CategoryID).ToList();

            }
        }

        private void PartsLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if()
        }
    }
}
