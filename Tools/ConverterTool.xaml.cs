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
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class ConverterTool : UserControl
    {
        public ConverterTool()
        {
            InitializeComponent();
        }

        public static Dictionary<string, string[]> quantities = new Dictionary<string, string[]>
        {
            { "Масса", new[] { "Граммы", "Килограммы", "Центнеры", "Тонны" } },
            { "Длина", new[] { "Миллиметры", "Сантиметры", "Метры", "Километры" } },
            { "Валюта", new[] { "Рубли", "Доллары", "Евро" } },
            { "Информация", new[] { "Биты", "Байты", "Килобайты", "Мегабайты", "Гигабайты", "Терабайты", "Петабайты" } },
            {"Температура", new[] {"градус Цельсия","градус Фаренгейта", "Кельвин"} }
        };
        public static Dictionary<string, string> shortQuantitiesNames = new Dictionary<string, string>
        {
            { "Граммы", "г" }, { "Килограммы", "кг" }, { "Центнеры", "ц" }, { "Тонны", "т" },
            { "Миллиметры", "мм" }, { "Сантиметры", "см" }, { "Метры", "м" }, { "Километры", "км" },
            { "Рубли", "₽" }, { "Доллары", "$" }, { "Евро", "€" },
            { "Биты", "бит" }, {"Байты", "байт" }, {"Килобайты", "кб" }, {"Мегабайты", "мб" }, {"Гигабайты", "гб" }, {"Терабайты", "тб" }, {"Петабайты", "пб" },
            {"градус Цельсия","°C"},{"градус Фаренгейта","°F"},{"Кельвин","K"}
        };
        public static Dictionary<string, double[,]> matrixDictionary = new Dictionary<string, double[,]>
        {
            {
                 "Масса",
                 new double[4,4]
                 {
                    { 1,0.001,0.00001,0.000001},
                    { 1000,1,0.01,0.001 },
                    { 100000,100,1,0.1 },
                    { 1000000,1000,10,1 }
                 }
            },
            {
                 "Длина",
                 new double[4,4]
                 {
                    { 1,0.1,0.001,0.000001},
                    { 10,1,0.01,0.00001 },
                    { 1000,100,1,0.001 },
                    { 1000000,100000,1000,1 }
                 }
            },
            {
                 "Информация",
                 new double[7,7]
                 {
                    { 1,0.125,0.0001225,0.00000012005, 0.000000000117649,0.00000000000011529602,0.0000000000000001129901},
                    { 8,1,0.00098,0.0000009604,0.0000000009604,0.00000000000092236816,0.000000000000000903920797 },
                    { 8192,1024,1,00098,0.0000009604,0.0000000009604,0.00000000000092236816},
                    { 8388608,1048576,1024,1,0.00098,0.0000009604,0.0000000009604 },
                    { 8589934592,1073741824,1048576,1024,1,0.00098,0.0000009604},
                    { 8796092800000,1099511620000,1073741824,1048576,1024,1,0.00098},
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
            }
        };

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(ComboBox1.Text))
            {
                ComboBox2.Items.Clear();
                ComboBox3.Items.Clear();
                ComboBox2.Text = "";
                ComboBox3.Text = "";
                Label5.Content = string.Empty;
                foreach (var str in quantities[ComboBox1.Text])
                {
                    ComboBox2.Items.Add(str);
                    ComboBox3.Items.Add(str);
                }
                Label4.Content = string.Empty;
            }
        }



        private void TextBox1_PrevievTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ",")
               && (!TextBox1.Text.Contains(",")
               && TextBox1.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if ((ComboBox2.Text == "") || (ComboBox3.Text == "") || (TextBox1.Text == ""))
                MessageBox.Show("Ошибка исходных данных. \n" + "Необходимо ввести данные во все поля. ", "Конвертер", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                string result;
                var cBox2 = ComboBox2.SelectedIndex;
                var cBox3 = ComboBox3.SelectedIndex;
                switch (ComboBox1.Text)
                {
                    case "Температура":
                        result = GetConvertationTemperature(System.Convert.ToDouble(TextBox1.Text), matrixDictionary, ComboBox1.Text, cBox2, cBox3);
                        break;
                    default:
                        result = GetConvertationResult(System.Convert.ToDouble(TextBox1.Text), matrixDictionary, ComboBox1.Text, cBox2, cBox3);
                        break;
                }
                Label4.Content = "Результат";
                Label5.Content = string.Format("{0} {1} = {2} {3}", TextBox1.Text, shortQuantitiesNames[ComboBox2.Text], result, shortQuantitiesNames[ComboBox3.Text]);
                History.Content = History.Content + "\n" + Label5.Content;
            }
        }
        public static string GetConvertationResult(double value, Dictionary<string, double[,]> matrixDictionary, string quantity, int from, int to)
        {
            return (value * matrixDictionary[quantity][from, to]).ToString();
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
    }
}
