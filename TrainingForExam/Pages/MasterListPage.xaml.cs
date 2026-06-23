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
    /// Логика взаимодействия для MasterListPage.xaml
    /// </summary>
    public partial class MasterListPage : Page
    {
        public static List<Masters> masters = Core.Context.Masters.ToList();
        public static List<Sessions> sessions = Core.Context.Sessions.ToList();
        public MasterListPage()
        {
            InitializeComponent();
            SessionList.ItemsSource = masters;
            
            
            
        }

        private void DateList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBox d && d.SelectedItem is string selectedDate) 
                NavigationService.Navigate(new HairListPage(d.DataContext as Masters, selectedDate));
        }
    }
}
