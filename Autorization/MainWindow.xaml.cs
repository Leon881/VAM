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
using Multiplector;
using Multiplector.Autorization;

namespace Autorization_form
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LognIn_Click(object sender, RoutedEventArgs e)
        {
            if (Username.Text == "" || Password.Password == "")
                MessageBox.Show("Заполните все поля", "Ошибка ввода");
            else LogIn(new UserForm(Username.Text, Password.Password));
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            var regWindow = new Registration();
            regWindow.Owner = Owner;
            regWindow.Show();
            Close();
        }

        private void Username_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (Username.Text == "") MessageBox.Show("Введите логин!", "Ошибка");
                else if (Password.Password == "") Password.Focus();
                else LogIn(new UserForm(Username.Text, Password.Password));
            }
        }

        private void Password_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (Password.Password == "") MessageBox.Show("Введите пароль!", "Ошибка");
                else if (Username.Text == "") Username.Focus();
                else LogIn(new UserForm(Username.Text, Password.Password));
            }
        }

        private void LogIn(UserForm user)
        {
            string login;
            var res = SqlDataAccess.LogInUser(user, out login);
            switch(res)
            {
                case -1:
                    MessageBox.Show("Неверно введен логин", "Ошибка ввода логина");
                    Username.Clear();
                    Password.Clear();
                    break;
                case 0:
                    MessageBox.Show("Неверно введен пароль", "Ошибка ввода пароля");
                    Password.Clear();
                    break;
                default:
                    RegPrivileges.ChangeElementsForUser(login,
                     (TextBlock)Owner.FindName("UserLogin"),
                     (Button)Owner.FindName("Autorization"),
                     (Button)Owner.FindName("SignOut"),
                     (Button)Owner.FindName("ExcelExport"));
                    MessageBox.Show("Пользователь добавлен!");
                    Owner.Activate();
                    Close();
                    break;
            }
        }
    }
}
