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
using Diplom.Clases;
using Diplom.BD;
using Diplom.Windows;

namespace Diplom.Pages
{
    /// <summary>
    /// Логика взаимодействия для WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Page
    {
        public WorkerPage(Windows.MainWindow mainWindow)
        {
            InitializeComponent();
            AllWorker.ItemsSource = context.vw_Post.ToList();
            
        }

        public WorkerPage(Windows.MenegerWindow menegerWindow)
        {
            InitializeComponent();
            AllWorker.ItemsSource = context.vw_Post.ToList();
            

            var worker = context.Worker.ToList();

        }

        private void btnMoreInfo_Click(object sender , RoutedEventArgs e)
        {
            BD.vw_Post vw_Post = (sender as Button).DataContext as vw_Post;


            MoreInfoWindow moreInfoWindow = new MoreInfoWindow(vw_Post);
            moreInfoWindow.Show();
        }

        private void btnAddEmp_Click(object sender, RoutedEventArgs e)
        {
            
            AddWorkerWindow addWorkerWindow = new AddWorkerWindow();
            addWorkerWindow.Show();
            MenegerWindow menegerWindow = new MenegerWindow();
            menegerWindow.Close();
        }

        private void btnAddPost_Click(object sender, RoutedEventArgs e)
        {
            AddWorkerPostWindow addWorkerPostWindow = new AddWorkerPostWindow();
            addWorkerPostWindow.Show();
        }

        private void btnYvol_Click(object sender, RoutedEventArgs e)
        {
            if (AllWorker.SelectedItem is BD.Worker worker)
            {
                var resMass = MessageBox.Show($"Вы хотите изменить сотрудника {worker.FullName}", "Предупреждение", MessageBoxButton.YesNo);
                if (resMass == MessageBoxResult.Yes)
                {
                    AddWorkerPostWindow addEmployee = new AddWorkerPostWindow(worker);
                    PersonalDate.WorkerId = worker.IdWorker;
                    addEmployee.ShowDialog();
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show($"Вы не выбрали сотруднка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            AddWorkerPostWindow addWorkerPostWindow = new AddWorkerPostWindow();
            addWorkerPostWindow.Show();
        }
    }
}
