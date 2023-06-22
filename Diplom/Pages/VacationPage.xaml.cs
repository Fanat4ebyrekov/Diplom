
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
    /// Логика взаимодействия для VacationPage.xaml
    /// </summary>
    public partial class VacationPage : Page
    {

        public VacationPage(Windows.MainWindow mainWindow)
        {
            InitializeComponent();
            AllWorker.ItemsSource = context.vw_WorkerVocation.ToList();

            
        }

        public VacationPage(Windows.MenegerWindow menegerWindow)
        {
            InitializeComponent();
            AllWorker.ItemsSource = context.vw_WorkerVocation.ToList();
            btnDelete.Visibility = Visibility.Hidden;
            btnEdit.Visibility = Visibility.Hidden;

        }

        private void btnAddVac_Click(object sender, RoutedEventArgs e)
        {
            AddVacationWindow addVacationWindow = new AddVacationWindow();
            addVacationWindow.Show();
            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            //if (AllWorker.SelectedItem is BD.Vacation vaccation)
            //{
            //    var resMass = MessageBox.Show($"Вы хотите изменить данные об отпуске {vaccation.FullName}", "Предупреждение", MessageBoxButton.YesNo);
            //    if (resMass == MessageBoxResult.Yes)
            //    {
            //        AddWorkerWindow addEmployee = new AddWorkerWindow(vaccation);
            //        addEmployee.IdWorker = employee.IdWorker;
            //        addEmployee.ShowDialog();
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show($"Вы не выбрали сотруднка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
