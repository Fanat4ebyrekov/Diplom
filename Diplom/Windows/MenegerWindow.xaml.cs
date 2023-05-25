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
using System.Windows.Shapes;
using Diplom.Pages;
using static Diplom.Clases.ClassEntity;
using Diplom.BD;
using Diplom.Windows;

namespace Diplom.Windows
{
    /// <summary>
    /// Логика взаимодействия для MenegerWindow.xaml
    /// </summary>
    public partial class MenegerWindow : Window
    {
        public MenegerWindow()
        {
            InitializeComponent();
            AllInformation.Content = new WorkerPage(this);
        }

        private void btnWorker_Click(object sender, RoutedEventArgs e)
        {
            AllInformation.Content = new WorkerPage(this);
        }

        private void btnVacation_Click(object sender, RoutedEventArgs e)
        {
            AllInformation.Navigate(new VacationPage(this));
        }

        private void btnBusinessTrip_Click(object sender, RoutedEventArgs e)
        {
            AllInformation.Navigate(new BusinessTripPage(this));
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Close();
        }
    }
}
