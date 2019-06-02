using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Autorization_form;

namespace Multiplector.Autorization
{
    public class RegPrivileges: MainWindow
    {
        public static void AddButtons(params FrameworkElement[] buttons)
        {
                foreach (var b in buttons)
                    b.Visibility = Visibility.Visible;                            
        }

        public static void ChangeElementsForUser(string login, TextBlock userLogin, Button Autorization, 
            Button signOut, Button excelExport, Button Calculator, Button Clothes, Button Calendar, Button Paint)
        {
            RegPrivileges.AddButtons(userLogin, signOut);
            userLogin.SetValue(TextBlock.TextProperty, login);
            Autorization.Visibility = Visibility.Hidden;
            Calculator.IsEnabled = true;
            Clothes.IsEnabled = true;
            Calendar.IsEnabled = true;
            Paint.IsEnabled = true;
            if (login == "Admin") RegPrivileges.AddButtons(excelExport);
        }
    }
}
