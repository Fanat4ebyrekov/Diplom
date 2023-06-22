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
using static Diplom.Clases.ClassEntity;
using Diplom.BD;
using Diplom.Windows;

namespace Diplom.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddWorkerPostWindow.xaml
    /// </summary>
    public partial class AddWorkerPostWindow : Window
    {
        public AddWorkerPostWindow()
        {
            InitializeComponent();

            cbWorker.ItemsSource = context.Worker.ToList();
            cbWorker.SelectedIndex = 0;
            cbWorker.DisplayMemberPath = "FullName";

            cbWorkerPost.ItemsSource = context.Post.ToList();
            cbWorkerPost.DisplayMemberPath = "NamePost";
            cbWorkerPost.SelectedIndex = 0;

            btnRemovePost.Visibility = Visibility.Hidden;
            tbEndWork.Visibility = Visibility.Hidden;
            dpEndDateWork.Visibility = Visibility.Hidden;
            tbExample.Visibility = Visibility.Hidden;
            tbExmpl.Visibility = Visibility.Hidden;

            btnRemovePost.IsEnabled = false;
            tbEndWork.IsEnabled = false;
            dpEndDateWork.IsEnabled = false;
            tbExample.IsEnabled = false;
            tbExmpl.IsEnabled = false;
        }

        public AddWorkerPostWindow(Worker worker)
        {
            InitializeComponent();

            cbWorker.ItemsSource = context.Worker.ToList();
            cbWorker.SelectedIndex = 0;
            cbWorker.DisplayMemberPath = "FullName";

            cbWorkerPost.ItemsSource = context.Post.ToList();
            cbWorkerPost.DisplayMemberPath = "NamePost";
            cbWorkerPost.SelectedIndex = 0;

            btnAddPost.Visibility = Visibility.Hidden;
            btnAddPost.IsEnabled = false;

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddPost_Click(object sender, RoutedEventArgs e)
        {
            BD.WorkerPost workerpost = new BD.WorkerPost();

            workerpost.WorkerID = cbWorker.SelectedIndex + 1;
            workerpost.PostID = cbWorkerPost.SelectedIndex + 1;

            //if (!string.IsNullOrWhiteSpace(dpStartWork.Text))
            //{
            //    workerpost.DateStartPost = Convert.ToDateTime(dpStartWork.Text);
            //}
            //else
            //{
            //    MessageBox.Show("Не введена дата начало работы", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}

            MessageBox.Show("Должность добавлена");
            context.WorkerPost.Add(workerpost);
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Close();
        }

        private void btnRemovePost_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
