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

namespace Diplom.Windows
{
    /// <summary>
    /// Логика взаимодействия для MoreInfoWindow.xaml
    /// </summary>
    public partial class MoreInfoWindow : Window
    {
        public MoreInfoWindow(BD.vw_Post vw_Post)
        {
            InitializeComponent();
            tbEmail.Text = vw_Post.Email;
            tbBirthday.Text = vw_Post.Birthday.ToString();
            tbDepartment.Text = vw_Post.Department;
            tbEducation.Text = vw_Post.Experience.ToString() + " " + "года/лет";
            tbPhone.Text = vw_Post.Phone;
            tbPost.Text = vw_Post.Post;
            tbFIO.Text = vw_Post.FIO;
            

            //if (vw_Post.Photo != null)
            //{
            //    using (MemoryStream stream = new MemoryStream(Convert.ToInt32(vw_Post.Photo)))
            //    {
            //        BitmapImage bitmapImage = new BitmapImage();
            //        bitmapImage.BeginInit();
            //        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            //        bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
            //        bitmapImage.StreamSource = stream;
            //        bitmapImage.EndInit();
            //        photoWorker.Source = bitmapImage;
            //    }

            //}


        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
