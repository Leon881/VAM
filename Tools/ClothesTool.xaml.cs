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
    
    public partial class ClothesTool : UserControl
    {
        public ClothesTool()
        {
            InitializeComponent();
        }
        public static bool man = false;
        public static bool woman = false;
        public static bool size = false;
        public static bool child = false;
        public static List<string> manList = new List<string>() { "Обувь", "Брюки и джинсы", "Футболки" };
        public static List<string> PantsListWorld = new List<string>() { "XXS", "XS", "S", "M", "L", "XL", "XXL", "XXXL", "XXXXL" };
        public static List<string> TShirtListWorld = new List<string>() { "XXS", "XS", "S", "M", "L", "XL", "XXL", "XXXL", "XXXL" };
        public static List<int> manBootsList = new List<int>() { 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50 };
        public static List<int> womanBootsList = new List<int>() { 35, 36, 37, 38, 39, 40, 41, 42, 43, 44 };
        public static List<int> childrenBootsList = new List<int>() { 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
        public static List<int> manTShirtsList = new List<int>() { 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60 };
        public static List<int> womanTShirtsList = new List<int>() { 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56 };
        public static List<int> manPantsList = new List<int>() { 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64 };
        public static List<int> womanPantsList = new List<int>() { 38, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54 };
        public static Dictionary<string, string[]> clothes = new Dictionary<string, string[]>
        {
            { "Обувь", new[] { "Российcкий размер", "Размер США", "Европейский размер" } },
            { "Брюки и джинсы", new[] { "Российcкий размер", "Размер США", "Международный размер" } },
            { "Футболки", new[] { "Российcкий размер", "Размер США", "Европейский размер", "Международный размер" } },
            { "Юбки", new[] { "Российcкий размер", "Размер США", "Международный размер" } },
        };
        public static Dictionary<int, string> ManPants = new Dictionary<int, string>
            {
            {40, "XXS"},{41, "XXS"},{42, "XXS"},{43, "XS"},{44, "XS"},{45, "XS"},{46, "S"},{47, "S"},{48, "M"},
            {49, "M"},{50, "L"},{51, "L"},{52, "L"},{53, "XL"},{54, "XL"},{55, "XL"},{56, "XXL"},{57, "XXL"},
            {58, "XXXL"},{59, "XXXL"},{60, "XXXL"},{61, "XXXL"},{62, "XXXL"},{63, "XXXXL"},{64, "XXXXL"}
            };
        public static Dictionary<int, string> WomanPants = new Dictionary<int, string>
            {
            {38, "XXS"},{39, "XXS"},{40, "XS"},{41, "XS"},{42, "S"},{43, "S"},{44, "M"},{45, "M"},{46, "L"},
            {47, "L"},{48, "XL"},{49, "XL"},{50, "XXL"},{51, "XXL"},{52, "XXXL"},{53, "XXXL"},{54, "XXXL"}, {55, "XXXXL"},
            };
        public static Dictionary<int, string> ManTShirt = new Dictionary<int, string>
            {
            {42, "XXS"},{43, "XXS"},{44, "XS"},{45, "XS"},{46, "S"},{47, "S"},{48, "M"},
            {49, "M"},{50, "L"},{51, "L"},{52, "L"},{53, "L"},{54, "XL"},{55, "XL"},{56, "XXL"},{57, "XXL"},
            {58, "XXXL"},{59, "XXXL"},{60, "XXXL"}
            };
        public static Dictionary<int, string> WomanTShirt = new Dictionary<int, string>
            {
           {40, "XXS"},{41, "XXS"}, {42, "XS"},{43, "XS"},{44, "S"},{45, "S"},{46, "M"},{47, "M"},{48, "L"},
            {49, "L"},{50, "XL"},{51, "XL"},{52, "XXL"},{53, "XXL"},{54, "XXL"},{55, "XXXL"},{56, "XXXL"}
            };
        public static Dictionary<string, int[,]> matrixClothes = new Dictionary<string, int[,]>
        {
            {
                 "ManShoes",
                 new int[3,3]
                 {
                    { 0,-32,1},
                    { 32,0,33 },
                    { -1,-33,0 },
                 }
            },
            {
                 "WomanShoes",
                 new int[3,3]
                 {
                    { 0,-30,1},
                    { 30,0,31 },
                    { -1,-31,0 },
                 }
            },
             {
                 "ChildShoes",
                 new int[3,3]
                 {
                    { 0,-14,1},
                    { 14,0,15 },
                    { -1,-15,0 },
                 }
            },
              {
                 "ManPants",
                 new int[2,2]
                 {
                    { 0,-10},
                    { 10,0},
                 }
              },
               {
                 "WomanPants",
                 new int[2,2]
                 {
                    { 0,-38},
                    { 38,0},
                 }
              },
               {
                 "ManTShirt",
                 new int[3,3]
                 {
                    { 0,-36,-2},
                    { 36,0,34},
                    { 2,-34,0}
                 }
              },
               {
                 "WomanTShirt",
                 new int[3,3]
                 {
                    { 0,-34,-6},
                    { 34,0,28},
                    { 6,-28,0}
                 }
              }
        };
        private void Man_Click(object sender, RoutedEventArgs e)
        {
            Man.BorderBrush= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2B75E0"));
            Woman.BorderBrush = null;
            Child.BorderBrush = null;
            Size.BorderBrush = null;
            man = true;
            woman = false;
            size = false;
            child = false;
            IndexMassu.Visibility = Visibility.Hidden;
            ShowElements();
            Combobox1.Items.Clear();
            foreach (var str in manList)
                Combobox1.Items.Add(str);
        }

        private void Woman_Click(object sender, RoutedEventArgs e)
        {
            Man.BorderBrush = null;
            Woman.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2B75E0"));
            Child.BorderBrush = null;
            Size.BorderBrush = null;
            man = false;
            woman = true;
            size = false;
            child = false;
            IndexMassu.Visibility = Visibility.Hidden;
            ShowElements();
            Combobox1.Items.Clear();
            foreach (var str in manList)
                Combobox1.Items.Add(str);
            Combobox1.Items.Add("Юбки");
        }

        private void Child_Click(object sender, RoutedEventArgs e)
        {
            Man.BorderBrush = null;
            Woman.BorderBrush = null;
            Child.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2B75E0"));
            Size.BorderBrush = null;
            man = false;
            woman = false;
            size = false;
            child = true;
            IndexMassu.Visibility = Visibility.Hidden;
            ShowElements();
            Combobox1.Items.Clear();
            Combobox1.Items.Add("Обувь");
        }

        private void Size_Click(object sender, RoutedEventArgs e)
        {
            Man.BorderBrush = null;
            Woman.BorderBrush = null;
            Child.BorderBrush = null;
            Size.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2B75E0"));
            man = false;
            woman = false;
            size = true;
            child = false;
            MWC.Visibility = Visibility.Hidden;
            IndexMassu.Visibility = Visibility.Visible;  
            
        }
        
        public void ShowElements()
        {
            MWC.Visibility = Visibility.Visible;            
        }
        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Combobox2.Items.Clear();
            Combobox3.Items.Clear();
            Number.Items.Clear();
            Combobox2.Text = "";
            Combobox3.Text = "";
            Answer.Text = string.Empty;
            var text = "";

            if (Combobox1.SelectedIndex == 0)
            {
                text = "Обувь";
            }
            else if (Combobox1.SelectedIndex == 1)
            {
                if (man == true || woman == true)
                    text = "Брюки и джинсы";
                if (child == true)
                    text = "Одежда";
            }
            else if (Combobox1.SelectedIndex == 2)
            {
                text = "Футболки";
            }
            else if (Combobox1.SelectedIndex == 3)
            {
                text = "Юбки";
            }
            if (text == "") return;
            foreach (var str in clothes[text])
            {
                Combobox2.Items.Add(str);
                Combobox3.Items.Add(str);
            }

        }
        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Number.Items.Clear();
            Answer.Text = string.Empty;
            if ((Combobox1.Text == "Брюки и джинсы" || Combobox1.Text == "Юбки") && (string)Combobox2.SelectedItem == "Международный размер")
            {
                foreach (var str in PantsListWorld)
                    Number.Items.Add(str);
            }
            else if (Combobox1.Text == "Футболки" && (string)Combobox2.SelectedItem == "Международный размер")
            {
                foreach (var str in TShirtListWorld)
                    Number.Items.Add(str);
            }
            else if (man == true && Combobox1.Text == "Обувь")
            {
                if ((string)Combobox2.SelectedItem == "Российcкий размер")
                {
                    foreach (var str in manBootsList)
                        Number.Items.Add(str);
                }
                else if ((string)Combobox2.SelectedItem == "Размер США")
                {
                    foreach (var str in manBootsList)
                        Number.Items.Add(str - 32);
                }
                else if ((string)Combobox2.SelectedItem == "Европейский размер")
                {
                    foreach (var str in manBootsList)
                        Number.Items.Add(str + 1);
                }
            }
            else if (woman == true && Combobox1.Text == "Обувь")
            {
                if ((string)Combobox2.SelectedItem == "Российcкий размер")
                {
                    foreach (var str in womanBootsList)
                        Number.Items.Add(str);
                }
                else if ((string)Combobox2.SelectedItem == "Размер США")
                {
                    foreach (var str in womanBootsList)
                        Number.Items.Add(str - 30);
                }
                else if ((string)Combobox2.SelectedItem == "Европейский размер")
                {
                    foreach (var str in womanBootsList)
                        Number.Items.Add(str + 1);
                }
            }
            else if (child == true && Combobox1.Text == "Обувь")
            {
                if ((string)Combobox2.SelectedItem == "Российcкий размер")
                {
                    foreach (var str in childrenBootsList)
                        Number.Items.Add(str);
                }
                else if ((string)Combobox2.SelectedItem == "Размер США")
                {
                    foreach (var str in childrenBootsList)
                        Number.Items.Add(str - 14);
                }
                else if ((string)Combobox2.SelectedItem == "Европейский размер")
                {
                    foreach (var str in childrenBootsList)
                        Number.Items.Add(str + 1);
                }
            }
            else if (man == true && Combobox1.Text == "Футболки")
            {
                if ((string)Combobox2.SelectedItem == "Российcкий размер")
                {
                    foreach (var str in manTShirtsList)
                        Number.Items.Add(str);
                }
                else if ((string)Combobox2.SelectedItem == "Размер США")
                {
                    foreach (var str in manTShirtsList)
                        Number.Items.Add(str - 36);
                }
                else if ((string)Combobox2.SelectedItem == "Европейский размер")
                {
                    foreach (var str in manTShirtsList)
                        Number.Items.Add(str - 2);
                }
            }
            else if (woman == true && Combobox1.Text == "Футболки")
            {
                if ((string)Combobox2.SelectedItem == "Российcкий размер")
                {
                    foreach (var str in womanTShirtsList)
                        Number.Items.Add(str);
                }
                else if ((string)Combobox2.SelectedItem == "Размер США")
                {
                    foreach (var str in womanTShirtsList)
                        Number.Items.Add(str - 34);
                }
                else if ((string)Combobox2.SelectedItem == "Европейский размер")
                {
                    foreach (var str in womanTShirtsList)
                        Number.Items.Add(str - 6);
                }

            }
            else if (man == true && Combobox1.Text == "Брюки и джинсы")
            {
                if ((string)Combobox2.SelectedItem == "Российcкий размер")
                {
                    foreach (var str in manPantsList)
                        Number.Items.Add(str);
                }
                else if ((string)Combobox2.SelectedItem == "Размер США")
                {
                    foreach (var str in manPantsList)
                        Number.Items.Add(str - 10);
                }
            }
            else if (woman == true && (Combobox1.Text == "Брюки и джинсы" || Combobox1.Text == "Юбки"))
            {
                if ((string)Combobox2.SelectedItem == "Российcкий размер")
                {
                    foreach (var str in womanPantsList)
                        Number.Items.Add(str);
                }
                else if ((string)Combobox2.SelectedItem == "Размер США")
                {
                    foreach (var str in womanPantsList)
                        Number.Items.Add(str - 38);
                }
            }
        }
       

        private void Solve_Click(object sender, RoutedEventArgs e)
        {
            var warnings = new Messages();
            if (Number.Text == "")
            {
                Answer.Text = warnings.Message5();
                Timer();
                return;
            }
            if (Combobox2.Text == "" || Combobox3.Text == "")
            {
                Answer.Text = warnings.Message6();
                Timer();
                return;
            }
            var info = new Information
            {
                box1 = (string)Combobox1.SelectedItem,
                box2 = (string)Combobox2.SelectedItem,
                box3 = (string)Combobox3.SelectedItem,
                sex = GetGender(man, woman, child)

            };
            var inbox2 = Combobox2.SelectedIndex;
            var inbox3 = Combobox3.SelectedIndex;
            switch (info.GetInfo())
            {
                case "ManShoes":
                    Answer.Text = (Convert.ToInt32(Number.Text) + matrixClothes[info.GetInfo()][inbox2, inbox3]).ToString();
                    break;
                case "WomanShoes":
                    Answer.Text = (Convert.ToInt32(Number.Text) + matrixClothes[info.GetInfo()][inbox2, inbox3]).ToString();
                    break;
                case "ChildShoes":
                    Answer.Text = (Convert.ToInt32(Number.Text) + matrixClothes[info.GetInfo()][inbox2, inbox3]).ToString();
                    break;
                case "ManPants":
                    Answer.Text = (Convert.ToInt32(Number.Text) + matrixClothes[info.GetInfo()][inbox2, inbox3]).ToString();
                    break;
                case "ManPants1":
                    if ((string)Combobox2.SelectedItem == "Российcкий размер")
                        Answer.Text = ManPants[Convert.ToInt32(Number.Text)];
                    else if ((string)Combobox2.SelectedItem == "Размер США")
                        Answer.Text = ManPants[Convert.ToInt32(Number.Text) + 10];
                    break;
                case "ManPants2":
                    if ((string)Combobox3.SelectedItem == "Российcкий размер")
                        Answer.Text = (ManPants.Where(x => x.Value == Number.Text).FirstOrDefault().Key).ToString();
                    else if ((string)Combobox3.SelectedItem == "Размер США")
                        Answer.Text = (ManPants.Where(x => x.Value == Number.Text).FirstOrDefault().Key - 10).ToString();
                    break;
                case "WomanPants":
                    Answer.Text = (Convert.ToInt32(Number.Text) + matrixClothes[info.GetInfo()][inbox2, inbox3]).ToString();
                    break;
                case "WomanPants1":
                    if ((string)Combobox2.SelectedItem == "Российcкий размер")
                        Answer.Text = WomanPants[Convert.ToInt32(Number.Text)];
                    else if ((string)Combobox2.SelectedItem == "Размер США")
                        Answer.Text = WomanPants[Convert.ToInt32(Number.Text) + 38];
                    break;
                case "WomanPants2":
                    if ((string)Combobox3.SelectedItem == "Российcкий размер")
                        Answer.Text = (WomanPants.Where(x => x.Value == Number.Text).FirstOrDefault().Key).ToString();
                    else if ((string)Combobox3.SelectedItem == "Размер США")
                        Answer.Text = (WomanPants.Where(x => x.Value == Number.Text).FirstOrDefault().Key - 38).ToString();
                    break;
                case "ManTShirt":
                    Answer.Text = (Convert.ToInt32(Number.Text) + matrixClothes[info.GetInfo()][inbox2, inbox3]).ToString();
                    break;
                case "ManTShirt1":
                    if ((string)Combobox2.SelectedItem == "Российcкий размер")
                        Answer.Text = ManTShirt[Convert.ToInt32(Number.Text)];
                    else if ((string)Combobox2.SelectedItem == "Размер США")
                        Answer.Text = ManTShirt[Convert.ToInt32(Number.Text) + 36];
                    else if ((string)Combobox2.SelectedItem == "Европейский размер")
                        Answer.Text = ManTShirt[Convert.ToInt32(Number.Text) + 2];
                    break;
                case "ManTShirt2":
                    if ((string)Combobox3.SelectedItem == "Российcкий размер")
                        Answer.Text = (ManTShirt.Where(x => x.Value == Number.Text).FirstOrDefault().Key).ToString();
                    else if ((string)Combobox3.SelectedItem == "Размер США")
                        Answer.Text = (ManTShirt.Where(x => x.Value == Number.Text).FirstOrDefault().Key - 36).ToString();
                    else if ((string)Combobox3.SelectedItem == "Европейский размер")
                        Answer.Text = (ManTShirt.Where(x => x.Value == Number.Text).FirstOrDefault().Key - 2).ToString();
                    break;
                case "WomanTShirt":
                    Answer.Text = (Convert.ToInt32(Number.Text) + matrixClothes[info.GetInfo()][inbox2, inbox3]).ToString();
                    break;
                case "WomanTShirt1":
                    if ((string)Combobox2.SelectedItem == "Российcкий размер")
                        Answer.Text = WomanTShirt[Convert.ToInt32(Number.Text)];
                    else if ((string)Combobox2.SelectedItem == "Размер США")
                        Answer.Text = WomanTShirt[Convert.ToInt32(Number.Text) + 34];
                    else if ((string)Combobox2.SelectedItem == "Европейский размер")
                        Answer.Text = WomanTShirt[Convert.ToInt32(Number.Text) + 6];
                    break;
                case "WomanTShirt2":
                    if ((string)Combobox3.SelectedItem == "Российcкий размер")
                        Answer.Text = (WomanTShirt.Where(x => x.Value == Number.Text).FirstOrDefault().Key).ToString();
                    else if ((string)Combobox3.SelectedItem == "Размер США")
                        Answer.Text = (WomanTShirt.Where(x => x.Value == Number.Text).FirstOrDefault().Key - 34).ToString();
                    else if ((string)Combobox3.SelectedItem == "Европейский размер")
                        Answer.Text = (WomanTShirt.Where(x => x.Value == Number.Text).FirstOrDefault().Key - 6).ToString();
                    break;
                case "Equality":
                    Answer.Text = Number.Text;
                    break;
                default: break;

            }
        }
        private string GetGender(bool man, bool woman, bool child)
        {
            if (man == true)
                return "man";
            else if (woman == true)
                return "woman";
            else return "child";
        }

        private void ex1_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void Timer()
        {
            DispatcherTimer tm = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 2)
            };
            tm.Tick += (s, ea) =>
            {
                Answer.Text = string.Empty;
                Answer1.Text = string.Empty;
                tm.Stop();

            };
            tm.Start();
        }
       
        private void Weight_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
                e.Handled = true;
        }

        private void Height_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
                e.Handled = true;
        }

        private void Weight_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void Height_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            var warning = new Messages();
            if (Weight.Text == "")
            {
                Answer1.Text = warning.Message8();
                Timer();
                return;
            }
            if (Height.Text == "")
            {
                Answer1.Text = warning.Message7();
                Timer();
                return;
            }
            for (var i = 0; i < Height.Text.Length; i++)
            {
                if (i == 0 && Height.Text[i] == '0') Height.Text.Remove(0, 1);
            }
            for (var i = 0; i < Weight.Text.Length; i++)
            {
                if (i == 0 && Weight.Text[i] == '0') Weight.Text.Remove(0, 1);
            }
            double weight = Convert.ToInt32(Weight.Text);
            double height = Convert.ToInt32(Height.Text);
            var answer = (weight / (height * height)) * 10000;
            var roundAnwer = (Math.Round(answer, 1));
            Answer1.Text = "Индекс массы вашего тела равен " + roundAnwer.ToString() + ".";
            var text = Answer1.Text;
            if (roundAnwer <= 16) Answer1.Text = text + "\nДанное значение ИМТ соответствует выраженному дефициту масcы тела.";
            else if (roundAnwer > 16 && roundAnwer < 18.5) Answer1.Text = text + "\nДанное значение ИМТ соответствует недостаточной массе тела.";
            else if (roundAnwer >= 18.5 && roundAnwer < 25) Answer1.Text = text + "\nДанное значение ИМТ соответствует нормальной массе тела.";
            else if (roundAnwer >= 25 && roundAnwer < 30) Answer1.Text = text + "\nДанное значение ИМТ соответствует избыточной массе тела.";
            else if (roundAnwer >= 30 && roundAnwer < 35) Answer1.Text = text + "\nДанное значение ИМТ соответствует ожирению первой степени.";
            else if (roundAnwer >= 35 && roundAnwer < 40) Answer1.Text = text + "\nДанное значение ИМТ соответствует ожирению второй степени.";
            else if (roundAnwer >= 40) Answer1.Text = text + "\nДанное значение ИМТ соответствует ожирению третьей степени.";
        }
    }
}
