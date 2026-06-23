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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public List<Sessions> Sessions = Core.Context.Sessions.ToList();
        private Haircuts curHair;
        private Masters curMast;
        private String curDate;
        public OrderPage(Masters MastID, String Date, Haircuts HairID = null)
        {
            InitializeComponent();
            curHair = HairID;
            curMast = MastID;
            curDate = Date;
            if(curHair != null ) HairCutTB.Text = curHair.Name;
            MasterTB.Text = curMast.Name;
            TimeTB.Text = curDate;
            

        }

        private void OrderBTN_Click(object sender, RoutedEventArgs e)
        {
            Sessions S = Sessions.FirstOrDefault(p => p.Date == DateTime.Parse(TimeTB.Text) && p.ID_Master == curMast.ID);
            S.ID_Haircut = curHair.ID;
            S.Name = NameTB.Text;
            S.Phone = PhoneTB.Text;
            S.IsBooked = true;
            Core.Context.SaveChanges();
            MessageBox.Show("Регистрация прошла успешно!");
            NavigationService.Navigate(new MainPage());

        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if(NavigationService.CanGoBack) NavigationService.GoBack();
        }

        private void NameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrEmpty(NameTB.Text) && !string.IsNullOrEmpty(PhoneTB.Text)) OrderBTN.IsEnabled = true;
        }
    }
}
