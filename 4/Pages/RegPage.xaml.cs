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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if(NavigationService.CanGoBack) NavigationService.GoBack();
        }

        private void RegBTN_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.user = new Users
            {
                Username = LoginTB.Text,
                PasswordHash = PassTB.Text,
                Email = EmailTB.Text
            };
            Core.Context.Users.Add(MainWindow.user);
            Core.Context.SaveChanges();
            NavigationService.Navigate(new MainPage());
        }

        private void LoginTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LoginTB.Text) && !string.IsNullOrEmpty(PassTB.Text) && !string.IsNullOrEmpty(EmailTB.Text))
            {
                RegBTN.IsEnabled = true;
            }
        }
    }
}
