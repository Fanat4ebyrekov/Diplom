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
    /// Логика взаимодействия для AddVacationWindow.xaml
    /// </summary>
    public partial class AddVacationWindow : Window
    {
        public AddVacationWindow()
        {
            InitializeComponent();

            cbWorkers.ItemsSource = context.Worker.ToList();
            cbWorkers.SelectedIndex = 0;
            cbWorkers.DisplayMemberPath = "FullName";

            cbFooting.ItemsSource = context.TypeFooting.ToList();
            cbFooting.DisplayMemberPath = "NameFooting";
            cbFooting.SelectedIndex = 0;

            btnEditVac.Visibility = Visibility.Hidden;
            btnEditVac.IsEnabled = false;

            tbEditVac.Visibility = Visibility.Hidden;
            tbEditVac.IsEnabled = false;
        }

        //public AddVacationWindow()
        //{
        //    InitializeComponent();

        //    cbWorkers.ItemsSource = context.Worker.ToList();
        //    cbWorkers.SelectedIndex = 0;
        //    cbWorkers.DisplayMemberPath = "FullName";

        //    cbFooting.ItemsSource = context.TypeFooting.ToList();
        //    cbFooting.DisplayMemberPath = "NameFooting";
        //    cbFooting.SelectedIndex = 0;

        //    btnEditVac.Visibility = Visibility.Hidden;
        //    btnEditVac.IsEnabled = false;

        //    tbEditVac.Visibility = Visibility.Hidden;
        //    tbEditVac.IsEnabled = false;
        //}

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEditVac_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddVac_Click(object sender, RoutedEventArgs e)
        {
            BD.Vacation vacation = new BD.Vacation();

            vacation.WorkerID = cbWorkers.SelectedIndex + 1;
            vacation.FootingID = cbFooting.SelectedIndex + 1;

            if (!string.IsNullOrWhiteSpace(dpStartVac.Text))
            {
                vacation.DateStart = Convert.ToDateTime(dpStartVac.Text);
            }
            else
            {
                MessageBox.Show("Не выбрана дата начало отпуска", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!string.IsNullOrWhiteSpace(dpStartVac.Text))
            {
                vacation.DateEnd = Convert.ToDateTime(dpEndVoc.Text);
            }
            else
            {
                MessageBox.Show("Не выбрана дата начало отпуска", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Должность добавлена");
            context.Vacation.Add(vacation);
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
    }
}
