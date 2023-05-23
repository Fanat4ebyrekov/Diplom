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
    /// Логика взаимодействия для WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Page
    {
        public WorkerPage(Windows.MainWindow mainWindow)
        {
            InitializeComponent();
            AllWorker.ItemsSource = context.vw_Post.ToList();
        }

        private void btnMoreInfo_Click(object sender, RoutedEventArgs e)
        {
            MoreInfoWindow moreInfoWindow = new MoreInfoWindow();
            moreInfoWindow.Show();
        }
    }
}
