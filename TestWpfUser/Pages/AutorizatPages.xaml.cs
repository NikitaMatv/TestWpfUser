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

namespace TestWpfUser.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorizatPages.xaml
    /// </summary>
    public partial class AutorizatPages : Page
    {
        public AutorizatPages()
        {
            InitializeComponent();
        }
        private void AutorBt_Click(object sender, RoutedEventArgs e)
        {
            var users = App.DB.User.FirstOrDefault(emp => emp.Login == LoginTb.Text);
            if (users == null)
            {
                MessageBox.Show("Логин неверный");
                return;
            }
            if (users.Password != PasswordTb.Password)
            {
                MessageBox.Show("Пароль неверный");
                return;
            }
            App.LoggedUser = users;

            MessageBox.Show($"Успешная авторизация под пользователем {users.Name}");
            LoginTb.Clear();
            PasswordTb.Clear();
        }
    }
}
