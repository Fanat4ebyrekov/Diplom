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
using static Diplom.Clases.ClassEntity;
using Diplom.BD;
using Diplom.Windows;

namespace Diplom.Pages
{
    /// <summary>   
    /// Логика взаимодействия для BusinessTripPage.xaml
    /// </summary>
    public partial class BusinessTripPage : Page
    {
        public BusinessTripPage(Windows.MainWindow mainWindow)
        {
            InitializeComponent();
            AllWorker.ItemsSource = context.vm_WorkerBusinessTrip.ToList();
        }

        public BusinessTripPage(Windows.MenegerWindow menegerWindow)
        {
            InitializeComponent();
            AllWorker.ItemsSource = context.vm_WorkerBusinessTrip.ToList();
            btnDelete.Visibility = Visibility.Hidden;
            btnEdit.Visibility = Visibility.Hidden;
        }

        private void btnAddTrip_Click(object sender, RoutedEventArgs e)
        {
            AddTripWindow addTripWindow = new AddTripWindow();
            addTripWindow.Show();
        }
    }
}
