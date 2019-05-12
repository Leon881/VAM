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

namespace Multiplector.Tools
{
 
    public partial class CalendarTool : UserControl
    {
        private static bool flagForButton1 = false;
        private static bool flagForButton2 = false;
        private static bool checkForCanvas = false;
        public CalendarTool()
        {
            InitializeComponent();
        }

        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            if (flagForButton1==true)
            {
                SolveDate();
            }
            else if (flagForButton2==true)
            {
                SolveBirthday();
            }
        }
        private string Days(int result)
        {
            var dictionaryForDay = new Dictionary<double, string> {{ 1,"день"}, { 2, "дня" }, { 3, "дня" }, { 4, "дня" }, { 5, "дней" },
            { 6,"дней"},{ 7,"дней"},{ 8,"дней"},{ 9,"дней"},{ 0,"дней"}};
            if (result % 100 > 10 && result % 100 < 15)
                return "дней";
            else return dictionaryForDay[result % 10];
        }
        private string Months(int result)
        {
            var dictionaryForMonth = new Dictionary<double, string> {{ 1,"месяц"}, { 2, "месяца" }, { 3, "месяца" }, { 4, "месяца" }, { 5, "месяцев" },
            { 6,"месяцев"},{ 7,"месяцев"},{ 8,"месяцев"},{ 9,"месяцев"},{ 0,"месяцев"}};
            if (result % 100 > 10 && result % 100 < 15)
                return "месяцев";
            else return dictionaryForMonth[result % 10];
        }
        private string Years(int result)
        {
            var dictionaryForYear = new Dictionary<double, string> {{ 1,"год"}, { 2, "года" }, { 3, "года" }, { 4, "года" }, { 5, "лет" },
            { 6,"лет"},{ 7,"лет"},{ 8,"лет"},{ 9,"лет"},{ 0,"лет"}};
            if (result % 100 > 10 && result % 100 < 15)
                return "лет";
            else return dictionaryForYear[result % 10];
        }

        private void DateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Answer.Text != null)
            {
                Date1.Text = string.Empty;
                Date2.Text = string.Empty;
                Answer.Text = string.Empty;
            }
            if (checkForCanvas == true)
            {
                Canvas.SetLeft(Date1, 0.0);
                checkForCanvas = false;
            }
            Radio1.IsEnabled = true;
            Radio2.IsEnabled = true;
            Radio3.IsEnabled = true;
            flagForButton1 = true;
            flagForButton2 = false;
            Date1.Visibility = Visibility.Visible;
            Date2.Visibility = Visibility.Visible;
            SolveButton.Visibility = Visibility.Visible;
            Answer.Visibility = Visibility.Visible;
        }
        private void SolveDate()
        {
            var dictionaryForHour = new Dictionary<double, string> {{ 1,"час"}, { 2, "часа" }, { 3, "часа" }, { 4, "часа" }, { 5, "часов" },
            { 6,"часов"},{ 7,"часов"},{ 8,"часов"},{ 9,"часов"},{ 0,"часов"}};
            var a = DateTime.Parse(Date1.Text);
            var b = DateTime.Parse(Date2.Text);
            if (Radio1.IsChecked == true)
            {
                var result = (b.Subtract(a)).TotalDays;
                Answer.Text = string.Format("{0} {1}", result.ToString(), Days((int)result));
            }

            else if (Radio2.IsChecked == true)
            {
                var result = new DateTime((b.Subtract(a)).Ticks);

                Answer.Text = string.Format("{0} {1}, {2} {3}, {4} {5} ", (result.Year - 1).ToString(), Years((result.Year - 1)),
                    (result.Month - 1).ToString(), Months((result.Month - 1)), (result.Day - 1).ToString(), Days(result.Day - 1));
            }
            else if (Radio3.IsChecked == true)
            {
                var result = b.Subtract(a).TotalHours;
                if (result % 100 > 10 && result % 100 < 15)
                    Answer.Text = string.Format("{0} {1}", result.ToString(), "часов");
                else Answer.Text = string.Format("{0} {1}", result.ToString(), dictionaryForHour[result % 10]);
            }
           
        }
        private void SolveBirthday()
        {
            DateTime birthday = DateTime.MinValue;
            var c = DateTime.Parse(Date1.Text);
            if (c.Month > DateTime.Now.Month)
                birthday = new DateTime(DateTime.Now.Year, c.Month, c.Day);
            else
                birthday = new DateTime(DateTime.Now.Year + 1, c.Month, c.Day);
            var days = Math.Round(birthday.Subtract(DateTime.Now).TotalDays);
            Answer.Text = string.Format("Ваш день рождения будет через {0} {1}. День недели  - {2}", days.ToString(), Days((int)days), birthday.ToString("dddd"));
          
        }

        private void BirthdayButton_Click(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(Date1, 210.0);
            checkForCanvas = true;
            flagForButton2 = true;
            flagForButton1 = false;
            Radio1.IsChecked = true;
            Radio2.IsEnabled = false;
            Radio3.IsEnabled = false;
            if (Answer.Text != null)
            {
                Date1.Text = string.Empty;
                Date2.Text = string.Empty;
                Answer.Text = string.Empty;
            }
            Date1.Visibility = Visibility.Visible;
            Date2.Visibility=Visibility.Hidden;
            SolveButton.Visibility = Visibility.Visible;
            Answer.Visibility = Visibility.Visible;
        }

        private void Radio1_Checked(object sender, RoutedEventArgs e)
        {
            Answer.Text = string.Empty;
        }

        private void Radio2_Checked(object sender, RoutedEventArgs e)
        {
            Answer.Text = string.Empty;
        }

        private void Radio3_Checked(object sender, RoutedEventArgs e)
        {
            Answer.Text = string.Empty;
        }
        private void Radio4_Checked(object sender, RoutedEventArgs e)
        {
            Date1.SelectedDateFormat = DatePickerFormat.Long;
            Date2.SelectedDateFormat = DatePickerFormat.Long;
        }
        private void Radio5_Checked(object sender, RoutedEventArgs e)
        {
            Date1.SelectedDateFormat = DatePickerFormat.Short;
            Date2.SelectedDateFormat = DatePickerFormat.Short;
        }
        private void Date1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")))
                e.Handled = true;
        }
        private void Date2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")))
                e.Handled = true;
        }
       
    }
}
