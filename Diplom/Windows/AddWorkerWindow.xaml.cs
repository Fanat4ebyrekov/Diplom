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
using System.IO;
using Microsoft.Win32;

namespace Diplom.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddWorkerWindow.xaml
    /// </summary>
    public partial class AddWorkerWindow : Window
    {
        string PhotoEmployee = null;
        public AddWorkerWindow()
        {
            InitializeComponent();
            cbGender.ItemsSource = context.Gender.ToList();
            cbGender.SelectedIndex = 0;
            cbGender.DisplayMemberPath = "NameGender";

            cbPost.ItemsSource = context.Role.ToList();
            cbPost.DisplayMemberPath = "NameRole";
            cbPost.SelectedIndex = 0;
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я') || ch == 'ё' || ch == 'Ё' || (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z')).ToArray()
                    );
            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            BD.Worker worker = new BD.Worker();
            

            worker.RoleID = cbPost.SelectedIndex + 1;

            worker.GenderID = cbGender.SelectedIndex + 1;

            if (!string.IsNullOrWhiteSpace(tbName.Text))
            {
                worker.FirstName = tbName.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели имя");
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbLName.Text))
            {
                worker.LastName = tbLName.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели фамилию");
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbPassSer.Text))
            {
                worker.PassSer = tbPassSer.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели серию");
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbPassNumber.Text))
            {
                worker.PassNum = tbPassNumber.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели номер паспорта");
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbAddress.Text))
            {
                worker.Address = tbAddress.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели адресс");
                return;
            }

            if (!string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                worker.Phone = tbPhone.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели номер телефона");
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbExp.Text))
            {
                worker.Experience = Convert.ToInt32(tbExp.Text);
            }
            else
            {
                MessageBox.Show("Вы не ввели опыт работы");
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                worker.Email = tbEmail.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели почту");
                return;
            }
            if (!string.IsNullOrWhiteSpace(tbPass.Text))
            {
                worker.Password = tbPass.Text;
            }
            else
            {
                MessageBox.Show("Вы не ввели пароль");
                return;
            }
            



            MessageBox.Show("Пользователь добавлен");
            context.Worker.Add(worker);
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

        private void ChoopePhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgEmployee.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                PhotoEmployee = openFileDialog.FileName;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbLName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я') || ch == 'ё' || ch == 'Ё' || (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z')).ToArray()
                    );
            }
        }

        private void tbPassSer_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void tbPassNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void tbAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= 'а' && ch <= 'я')
                         || (ch >= 'А' && ch <= 'Я')
                         || ch == 'ё' || ch == 'Ё'
                         || ch == '.' || ch == ','
                         || (ch >= 'a' && ch <= 'z')
                         || (ch >= 'A' && ch <= 'Z')
                         || (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void tbPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => ch == '+' || ch == '-' || ch == '(' || ch == ')' || (ch >= '0' && ch <= '9')).ToArray()
                    );
            }


        }

        private void tbPhone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void tbExp_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox.Text.Where(ch => (ch >= '0' && ch <= '9')).ToArray()
                    );
            }
        }

        private void tbExp_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }


        private void tbEmail_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
