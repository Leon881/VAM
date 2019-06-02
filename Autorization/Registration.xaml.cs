using Multiplector.Autorization;
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

namespace Autorization_form
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registrate_Click(object sender, RoutedEventArgs e)
        {
            if (NewUsername.Text == "" || NewPassword.Password == "")
                MessageBox.Show("Заполните все поля", "Ошибка ввода");
            else SignIn();
        }

        private void NewUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (NewUsername.Text == "") MessageBox.Show("Введите логин!", "Ошибка");
                else if (NewPassword.Password == "") NewPassword.Focus();
                else SignIn();
            }
        }

        private void NewPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (NewPassword.Password == "") MessageBox.Show("Введите пароль!", "Ошибка");
                else if (NewUsername.Text == "") NewUsername.Focus();
                else SignIn();
            }
        }

        private void SignIn()
        {
            string login;
            var newUser = new UserForm(NewUsername.Text, NewPassword.Password);
            var res = SqlDataAccess.RegisterUser(newUser, out login);
            if (res == -1)
            {
                MessageBox.Show("Введенное имя пользователя уже существует", "Ошибка ввода логина");
                NewUsername.Clear();
                NewPassword.Clear();
            }
            else
            {
                RegPrivileges.ChangeElementsForUser(login,
                    (TextBlock)Owner.FindName("UserLogin"),
                    (Button)Owner.FindName("Autorization"),
                    (Button)Owner.FindName("SignOut"),
                    (Button)Owner.FindName("ExcelExport"),
                    (Button)Owner.FindName("Calculator"),
                    (Button)Owner.FindName("Clothes"),
                    (Button)Owner.FindName("Calendar"),
                    (Button)Owner.FindName("Paint"));

                MessageBox.Show("Пользователь добавлен!");
                Owner.Activate();
                Close();
            }
        }
    }
}
