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
    /// Логика взаимодействия для AddTripWindow.xaml
    /// </summary>
    public partial class AddTripWindow : Window
    {
        public AddTripWindow()
        {
            InitializeComponent();

            cbWorkers.ItemsSource = context.Worker.ToList();
            cbWorkers.SelectedIndex = 0;
            cbWorkers.DisplayMemberPath = "FullName";
        }

        private void btnAddVac_Click(object sender, RoutedEventArgs e)
        {
            BD.BusinessTrip businessTrip = new BD.BusinessTrip();

            businessTrip.WorkerID = cbWorkers.SelectedIndex + 1;

            businessTrip.PlaceOfBusinessTrip = tbPBT.Text;
            businessTrip.NumberOrder = Convert.ToInt32(tbNumOrder.Text);
            businessTrip.DateStart = Convert.ToDateTime(dpDateStart.Text);
            businessTrip.DateEnd = Convert.ToDateTime(dpDateEnd.Text);
            businessTrip.GoalTrip = tbGoalTrip.Text;

            MessageBox.Show("Должность добавлена");
            context.BusinessTrip.Add(businessTrip);
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
