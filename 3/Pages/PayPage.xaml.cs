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
    /// Логика взаимодействия для PayPage.xaml
    /// </summary>
    public partial class PayPage : Page
    {
        public decimal price;
        public PayPage(decimal _price)
        {
            price = _price;
            InitializeComponent();
            PriceLB.Content = ("Общая стоимость: " + _price);
        }

        private void MoneyTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (MoneyTB.Text != "") 
            {
                if (decimal.Parse(MoneyTB.Text) >= price)
                {
                    SendBTN.IsEnabled = true;
                    LeftLB.Content = ("Сдача: " + (decimal.Parse(MoneyTB.Text) - price));
                }
                else
                {
                    LeftLB.Content = "";
                    SendBTN.IsEnabled = false;
                }
            }
            
        }

        private void SendBTN_Click(object sender, RoutedEventArgs e)
        {
            Orders neword = new Orders
            {
                SeatsID = MainWindow.seat.ID,
                PaymentMethod = "Наличные",
                Total = price,
                WholeCash = decimal.Parse(MoneyTB.Text),
                LeftCash = (decimal.Parse(MoneyTB.Text) - price)
            };
            Core.Context.Orders.Add(neword);
            Core.Context.SaveChanges();
            if (MainWindow.combo != null)
            {
                OrderItems newio1 = new OrderItems
                {
                    OrderID = neword.ID,
                    ComboID = MainWindow.combo.ID
                };
                Core.Context.OrderItems.Add(newio1);
            }
            if (MainWindow.soup != null)
            {
                OrderItems newio2 = new OrderItems
                {
                    OrderID = neword.ID,
                    DishID = MainWindow.soup.ID
                };
                Core.Context.OrderItems.Add(newio2);

            }
            if (MainWindow.second != null)
            {
                OrderItems newio3 = new OrderItems
                {
                    OrderID = neword.ID,
                    DishID = MainWindow.second.ID
                };
                Core.Context.OrderItems.Add(newio3);

            }
            if (MainWindow.salad != null)
            {
                OrderItems newio4 = new OrderItems
                {
                    OrderID = neword.ID,
                    DishID = MainWindow.salad.ID
                };
                Core.Context.OrderItems.Add(newio4);

            }
            if (MainWindow.drink != null)
            {
                OrderItems newio5 = new OrderItems
                {
                    OrderID = neword.ID,
                    DishID = MainWindow.drink.ID
                };
                Core.Context.OrderItems.Add(newio5);

            }
            Core.Context.SaveChanges();
            MessageBox.Show("Заказ оформлен!");
            NavigationService.Navigate(new MainPage());
        }
    }
}
