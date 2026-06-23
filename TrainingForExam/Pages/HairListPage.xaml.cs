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

namespace TrainingForExam.Pages
{
    /// <summary>
    /// Логика взаимодействия для HairListPage.xaml
    /// </summary>
    public partial class HairListPage : Page
    {
        public static List<Haircuts> Hairs = Core.Context.Haircuts.ToList();
        public Masters curMast;
        public string curDate;
        public HairListPage(Masters MastID, String Date)
        {
            InitializeComponent();
            HairList.ItemsSource = Hairs;
            curMast = MastID;
            curDate = Date;
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if(NavigationService.CanGoBack) NavigationService.GoBack();
        }

        private void HairList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            NavigationService.Navigate(new OrderPage(curMast, curDate, HairList.SelectedItem as Haircuts));
        }

        private void SkipBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderPage(curMast, curDate));
        }
    }
}
