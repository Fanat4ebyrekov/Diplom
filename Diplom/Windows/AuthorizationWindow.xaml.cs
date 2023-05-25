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

namespace Diplom
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();

        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            var Emploer = context.Worker.ToList().
               Where(p => p.Email == this.txtLog.Text && p.Password == this.txtPass.Text).FirstOrDefault();
            if ((Emploer != null))
            {
                    switch (Emploer.RoleID)
                    {
                        case 1:

                            MainWindow adminWindow = new MainWindow();
                            adminWindow.Show();
                            this.Close();
                            break;

                        case 2:

                            MenegerWindow menegerWindow = new MenegerWindow();
                            menegerWindow.Show();
                            this.Close();
                            break;

                        default:
                            break;
                    }
            }
            else
            {
                MessageBox.Show("Вы ввели не правильно пароль или логин");
                txtLog.Clear();
                txtPass.Clear();
                return;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    
}
