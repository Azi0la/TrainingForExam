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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public static List<Seats> seats = Core.Context.Seats.ToList();
        public decimal wp = 0;
        public OrderPage()
        {
            InitializeComponent();


            if (MainWindow.combo != null) 
            {
                dcLB.Content = (MainWindow.combo.Name + " Цена: " + MainWindow.combo.Price);
                wp += MainWindow.combo.Price;
            }
            if (MainWindow.soup != null)
            {
                dcLB.Content = (MainWindow.soup.Name + " Цена: " + MainWindow.soup.Price);
                wp += MainWindow.soup.Price;
            }
            if (MainWindow.second != null)
            {
                secLB.Content = (MainWindow.second.Name + " Цена: " + MainWindow.second.Price);
                wp += MainWindow.second.Price;
            }
            if (MainWindow.salad != null)
            {
                salLB.Content = (MainWindow.salad.Name + " Цена: " + MainWindow.salad.Price);
                wp += MainWindow.salad.Price;
            }
            if (MainWindow.drink != null)
            {
                drinkLB.Content = (MainWindow.drink.Name + " Цена: " + MainWindow.drink.Price);
                wp += MainWindow.drink.Price;
            }
            PriceLB.Content = ("Общая стоимость: " + wp);
            SeatLB.Content = ("Выбранное место: " + MainWindow.seat.Name);

        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if(NavigationService.CanGoBack) { NavigationService.GoBack(); }
        }

        private void CardBTN_Click(object sender, RoutedEventArgs e)
        {
            Orders neword = new Orders
            {
                SeatsID = MainWindow.seat.ID,
                PaymentMethod = "Карта",
                Total = wp
            };
            Core.Context.Orders.Add(neword);
            Core.Context.SaveChanges();

            MessageBox.Show("Заказ оформлен!");
        }

        private void CashBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
