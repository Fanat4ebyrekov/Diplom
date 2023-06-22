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
using Diplom.Clases;
using Diplom.Pages;

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

            btnEdit.Visibility = Visibility.Hidden;
            btnEdit.IsEnabled = false;

            tbEditWorker.Visibility = Visibility.Hidden;

        }

        public AddWorkerWindow(Worker employee)
        {
            InitializeComponent();
            cbGender.ItemsSource = context.Gender.ToList();
            cbGender.SelectedIndex = 0;
            cbGender.DisplayMemberPath = "NameGender";

            cbPost.ItemsSource = context.Role.ToList();
            cbPost.DisplayMemberPath = "NameRole";
            cbPost.SelectedIndex = 0;

            btnReg.Visibility = Visibility.Hidden;
            btnReg.IsEnabled = false;

            tbAddWorker.Visibility = Visibility.Hidden;

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
                MessageBox.Show("Вы не ввели адрес");
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

            if (!string.IsNullOrWhiteSpace(dpBirt.Text))
            {
                worker.Birthday = Convert.ToDateTime(dpBirt.Text);
            }
            else
            {
                MessageBox.Show("Не введена дата рождения", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            worker.Photo = PhotoEmployee;


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

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var emp = context.Worker.Where(i => i.IdWorker == PersonalDate.IdWorker).FirstOrDefault();

            emp.FirstName = tbName.Text.Trim();
            emp.LastName = tbName.Text.Trim();
            emp.Birthday = Convert.ToDateTime(dpBirt.Text.Trim());
            emp.Phone = tbPhone.Text.Trim();
            emp.PassSer = tbPassSer.Text.Trim();
            emp.PassNum = tbPassNumber.Text.Trim();
            emp.Experience = Convert.ToInt32(tbExp.Text.Trim());
            emp.GenderID = cbGender.SelectedIndex + 1;
            //emp.Photo = File.ReadAllBytes(PhotoEmployee);
            emp.Email = tbEmail.Text.Trim();
            emp.Password = tbPass.Text.Trim();
            emp.RoleID = cbPost.SelectedIndex + 1;
            emp.Address = tbAddress.Text.Trim();

            BD.Worker worker = new BD.Worker();

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
                MessageBox.Show("Вы не ввели адрес");
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

            if (!string.IsNullOrWhiteSpace(dpBirt.Text))
            {
                worker.Birthday = Convert.ToDateTime(dpBirt.Text);
            }
            else
            {
                MessageBox.Show("Не введена дата рождения", "Ощибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var chek = MessageBox.Show($"Вы хотите изменить данные ", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (chek == MessageBoxResult.Yes)
            {
                context.SaveChanges();

                MessageBox.Show("Данные изменены");

                this.Close();
            }

        }
    }
}
