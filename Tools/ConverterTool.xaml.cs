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
using System.Windows.Threading;
using Multiplector.Classes;

namespace Multiplector.Tools
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class ConverterTool : UserControl
    {
        public ConverterTool()
        {
            InitializeComponent();
            this.History.IsReadOnly = true;
            this.Answer.IsReadOnly = true;
        }

        public static Dictionary<string, string[]> quantities = new Dictionary<string, string[]>
        {
            { "Масса", new[] { "Граммы", "Килограммы", "Центнеры", "Тонны", "Унция","Фунты" } },
            { "Длина", new[] { "Миллиметры", "Сантиметры", "Метры", "Километры","Мили","Футы","Дюймы" } },
            { "Валюта", new[] { "Рубли", "Доллары", "Евро" } },
            { "Информация", new[] { "Биты", "Байты", "Килобайты", "Мегабайты", "Гигабайты", "Терабайты", "Петабайты" } },
            {"Температура", new[] {"градус Цельсия","градус Фаренгейта", "Кельвин"} },
            {"Время", new[] {"Секунды","Минуты", "Часы","Дни","Недели","Годы"} },
        };
        public static Dictionary<string, string> shortQuantitiesNames = new Dictionary<string, string>
        {
            { "Граммы", "г" }, { "Килограммы", "кг" }, { "Центнеры", "ц" }, { "Тонны", "т" }, {"Унция","ун."},{"Фунты","ф."},
            { "Миллиметры", "мм" }, { "Сантиметры", "см" }, { "Метры", "м" }, { "Километры", "км" },{ "Мили", "м." },{ "Футы", "ф." },{ "Дюймы", "д." },
            { "Рубли", "₽" }, { "Доллары", "$" }, { "Евро", "€" },
            { "Биты", "бит" }, {"Байты", "байт" }, {"Килобайты", "кб" }, {"Мегабайты", "мб" }, {"Гигабайты", "гб" }, {"Терабайты", "тб" }, {"Петабайты", "пб" },
            {"градус Цельсия","°C"},{"градус Фаренгейта","°F"},{"Кельвин","K"},
            {"Секунды","сек." }, {"Минуты","мин."},{"Часы","ч."},{"Дни","д."},{"Недели","нед."},{"Годы","г."},
        };
        public static Dictionary<string, double[,]> matrixDictionary = new Dictionary<string, double[,]>
        {
            {
                 "Масса",
                 new double[6,6]
                 {
                    { 1,0.001,0.00001,0.000001,0.0352739619, 0.00220462262},
                    { 1000,1,0.01,0.001, 35.2739619,2.20462262 },
                    { 100000,100,1,0.1,3527.39619,220.462262 },
                    { 1000000,1000,10,1,35273.9619,2204.62262 },
                    {28.3495231,0.0283495231,0.000283495232,0.0000283495231, 1,0.0625},
                    {453.59237,0.45359237,0.0045359237,0.00045359237,16,1 }
                 }
            },
            {
                 "Длина",
                 new double[7,7]
                 {
                    { 1,0.1,0.001,0.000001,0.000000621371192,0.0032808399,0.0393700787},
                    { 10,1,0.01,0.00001,0.00000621371192,0.032808399,0.393700787 },
                    { 1000,100,1,0.001,0000621371192,3.2808399,39.3700787},
                    { 1000000,100000,1000,1,621371192,3280.8399,39370.0787 },
                     {1609344,160934.4,1609.344,1.609344,1,5280,63360},
                     {304.8,30.48,0.3048,0.0003048,0.000189393939,1,12 },
                     {25.4,2.54,0.0254,0.0000254,0.0000157828283,0.083333333,1}
                 }
            },
            {
                 "Информация",
                 new double[7,7]
                 {
                    { 1,0.125,0.0001225,0.00000012005, 0.000000000117649,0.00000000000011529602,0.0000000000000001129901},
                    { 8,1,0.00098,0.000000954,0.000000000931,0.000000000000909,0.000000000000000888 },
                    { 8192,1024,1,0.0009765625,0.0000009604,0.0000000009604,0.00000000000092236816},
                    { 8388608,1048576,1024,1,0.0009765625,0.0000009604,0.0000000009604 },
                    { 8589934592,1073741824,1048576,1024,1,0.0009765625,0.0000009604},
                    { 8796092800000,1099511620000,1073741824,1048576,1024,1,0.0009765625},
                    { 9007199280000000,1125899910000000,1099511620000,1073741824,1048576,1024,1}
                 }
            },
            {
                "Валюта",
                new double[3,3]
                {
                    { 1, 0.016, 0.014 },
                    { 62.76, 1, 0.86 },
                    { 72.99 , 1.16, 1 }
                }
            },
            {
                "Температура",
                new double[3,3]
                {
                    { 1, 1.8, 1 },
                    { 0.5556, 1, 0.5556 },
                    { 1 , 1.8, 1 }
                }
            },
             {
                "Время",
                new double[6,6]
                {
                    { 1, 0.016666667, 0.000277777778,0.000016740741,0.00000165353915,0.000000031709792 },
                    {60, 1, 0.016666667,0.000694444444,0.0000992063492,0.00000190258752 },
                    { 3600 , 60, 1,0.0416666667,0.00595238095,0.000114155251 },
                    { 86400 , 1440, 24,1,0.142857143,0.00273972603 },
                    { 604800 , 10080, 168,7,1,0.0191780822 },
                     { 31536000 , 525600, 8760,365,52.1428571,1 },
                }
            }
        };


        private void TextBox1_PrevievTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ",")
               && (!TextBox1.Text.Contains(",")
               && TextBox1.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }
        private void TextBox1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text.Replace(" ", string.Empty);
            var error = new Messages();
            if ((ComboBox2.Text == "") || (ComboBox3.Text == "") || (TextBox1.Text == ""))
            {
                Answer.Text = error.Message4();
                DispatcherTimer tm = new DispatcherTimer
                {
                    Interval = new TimeSpan(0, 0, 3)
                };
                tm.Tick += (s, ea) =>
                {
                    Answer.Clear();
                    tm.Stop();
                };
                tm.Start();
                return;
            }
            else
            {
                string result;
                var cBox2 = ComboBox2.SelectedIndex;
                var cBox3 = ComboBox3.SelectedIndex;
                if (ComboBox1.Text == "Температура")
                {
                    result = GetConvertationTemperature(System.Convert.ToDouble(TextBox1.Text), matrixDictionary, ComboBox1.Text, cBox2, cBox3);
                }
                else result = GetConvertationResult(System.Convert.ToDouble(TextBox1.Text), matrixDictionary, ComboBox1.Text, cBox2, cBox3);
                Label4.Content = "Результат";
                Answer.Text = string.Format("{0} {1} = {2} {3}", TextBox1.Text, shortQuantitiesNames[ComboBox2.Text], result, shortQuantitiesNames[ComboBox3.Text]);
                History.Text = Answer.Text + "\n" + History.Text;
            }
        }
        public static string GetConvertationResult(double value, Dictionary<string, double[,]> matrixDictionary, string quantity, int from, int to)
        {
            return Math.Round(value * matrixDictionary[quantity][from, to], 6).ToString();
        }

        public static string GetConvertationTemperature(double value, Dictionary<string, double[,]> matrixDictionary, string quantity, int from, int to)
        {
            switch (to)
            {
                case 2:
                    if (from == 2) return (value).ToString();
                    else return (from == 0) ? ((value * matrixDictionary[quantity][from, to]) + 273.15).ToString() : (((value - 32) * matrixDictionary[quantity][from, to]) + 273.15).ToString();
                case 1:
                    if (from == 1) return (value).ToString();
                    else return (from == 0) ? ((value * matrixDictionary[quantity][from, to]) + 32).ToString() : (((value - 273.15) * matrixDictionary[quantity][from, to]) + 32).ToString();
                case 0:
                    if (from == 0) return (value).ToString();
                    else return (from == 1) ? ((value - 32) * matrixDictionary[quantity][from, to]).ToString() : ((value * matrixDictionary[quantity][from, to]) - 273.15).ToString();
                default:
                    return null;
            }

        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox2.Items.Clear();
            ComboBox3.Items.Clear();
            ComboBox2.Text = "";
            ComboBox3.Text = "";
            Answer.Text = string.Empty;
            var text = "";
            if (ComboBox1.SelectedIndex == 0)
            {
                text = "Масса";
            }
            else if (ComboBox1.SelectedIndex == 1)
            {
                text = "Валюта";
            }
            else if (ComboBox1.SelectedIndex == 2)
            {
                text = "Длина";
            }
            else if (ComboBox1.SelectedIndex == 3)
            {
                text = "Информация";
            }
            else if (ComboBox1.SelectedIndex == 4)
            {
                text = "Температура";
            }
            else if (ComboBox1.SelectedIndex == 5)
            {
                text = "Время";
            }
            if (text == "") return;
            foreach (var str in quantities[text])
            {
                ComboBox2.Items.Add(str);
                ComboBox3.Items.Add(str);
            }
            Label4.Content = string.Empty;
        }

        private void HistorySenttings_Click(object sender, RoutedEventArgs e)
        {
            History.Text = string.Empty;
        }
    }
}