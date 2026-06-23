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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public static List<Users> users = Core.Context.Users.ToList();
        public AuthPage()
        {
            InitializeComponent();
        }

        private void AuthBTN_Click(object sender, RoutedEventArgs e)
        {
            if(users.FirstOrDefault(p => p.Username == LoginTB.Text && p.PasswordHash == PassTB.Text) != null)
            {
                MainWindow.user = users.FirstOrDefault(p => (p.Username == LoginTB.Text && p.PasswordHash == PassTB.Text));
                MessageBox.Show("Вход прошёл успешно");
                NavigationService.Navigate(new CatalogPage());
            }
            else
            {
                MessageBox.Show("Неправильно");
            }
        }

        private void RegBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }
    }
}
