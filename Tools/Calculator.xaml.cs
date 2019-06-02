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

namespace Multiplector.Tools
{
    class Messages
    {
        public string Message1()
        {
            return "Не все скобки парные";
        }
        public string Message2()
        {
            return "Делить на ноль нельзя";
        }
        public string Message3()
        {
            return "Выражение не может заканчиваться знаком";
        }
        public string Message4()
        {
            return "Выражение не может заканчиваться знаком";
        }
        public string EasterEgg()
        {
            return "Откуда у вас этот номер ?";
        }
    }
    public partial class CalculatorTool : UserControl
    {
        public CalculatorTool()
        {
            InitializeComponent();
            this.History.IsReadOnly = true;
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            if (Answer.Text.Contains("=")) Answer.Clear();
            Answer.Text = Answer.Text + "1";
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            if (Answer.Text.Contains("=")) Answer.Clear();
            Answer.Text = Answer.Text + "2";
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            if (Answer.Text.Contains("=")) Answer.Clear();
            Answer.Text = Answer.Text + "3";
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            if (Answer.Text.Contains("=")) Answer.Clear();
            Answer.Text = Answer.Text + "4";
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            if (Answer.Text.Contains("=")) Answer.Clear();
            Answer.Text = Answer.Text + "5";
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            if (Answer.Text.Contains("=")) Answer.Clear();
            Answer.Text = Answer.Text + "6";
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            if (Answer.Text.Contains("=")) Answer.Clear();
            Answer.Text = Answer.Text + "7";
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            if (Answer.Text.Contains("=")) Answer.Clear();
            Answer.Text = Answer.Text + "8";
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            if (Answer.Text.Contains("=")) Answer.Clear();
            Answer.Text = Answer.Text + "9";
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            if (Answer.Text.Contains("=")) Answer.Clear();
            Answer.Text = Answer.Text + "0";
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            Answer.Text = string.Empty;
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (Answer.Text != string.Empty)
                Answer.Text = Answer.Text.Remove(Answer.Text.Length - 1, 1);
        }

        private void Point_Click(object sender, RoutedEventArgs e)
        {
            Answer.Text = Answer.Text + ",";
        }

        private void Bracket1_Click(object sender, RoutedEventArgs e)
        {
            if (Answer.Text.Contains("=")) Answer.Clear();
            Answer.Text = Answer.Text + "(";
        }

        private void Bracket2_Click(object sender, RoutedEventArgs e)
        {
            if (Answer.Text.Contains("=")) Answer.Clear();
            Answer.Text = Answer.Text + ")";
        }

        private void Devision_Click(object sender, RoutedEventArgs e)
        {
            if (Answer.Text.Contains("="))
            {
                string[] arr = Answer.Text.Split('=');
                Answer.Text = arr[1];
            }
            Answer.Text = Answer.Text + "/";
        }

        private void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            if (Answer.Text.Contains("="))
            {
                string[] arr = Answer.Text.Split('=');
                Answer.Text = arr[1];
            }
            Answer.Text = Answer.Text + "*";
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if (Answer.Text.Contains("="))
            {
                string[] arr = Answer.Text.Split('=');
                Answer.Text = arr[1];
            }
            Answer.Text = Answer.Text + "-";
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            if (Answer.Text.Contains("="))
            {
                string[] arr = Answer.Text.Split('=');
                Answer.Text = arr[1];
            }
            Answer.Text = Answer.Text + "+";
        }
        private void Answer_PrevievTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ",") || (e.Text == "+") || (e.Text == "-")
                || (e.Text == "/") || (e.Text == "*") || (e.Text == "(") || (e.Text == ")")
               && (!Answer.Text.Contains(",")
               && Answer.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }
        private void Answer_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void Equality_Click(object sender, RoutedEventArgs e)
        {
            var checkForBracket = 0;
            foreach (var el in Answer.Text)
            {
                if (Char.IsDigit(el))
                    checkForBracket++;
            }
            if (Answer.Text.Contains("=")) return;
            if (checkForBracket == 0 && Answer.Text.Contains("(") && Answer.Text.Contains(")"))
            {
                Answer.Text = Answer.Text + "=" + "0";
                return;
            }
            var error = new Messages();
            if (Answer.Text == "89026057747" || Answer.Text == "89193743013" || Answer.Text == "89514772745")
            {
                Answer.Text = error.EasterEgg();
                DispatcherTimer tm = new DispatcherTimer
                {
                    Interval = new TimeSpan(0, 0, 2)
                };
                tm.Tick += (s, ea) =>
                {
                    Answer.Text = string.Empty;
                    e.Handled = false;
                    tm.Stop();
                };
                tm.Start();
                return;
            }
            string str = null;
            string str1 = null;
            string text = null;
            var op = char.MinValue;
            var number = 0.0;
            var checkForZero = false;
            var check = 0;
            var endCheck = false;
            var checkForMinus = false;
            Stack<double> stack1 = new Stack<double>();
            Stack<char> stack2 = new Stack<char>();
            for (var i = 0; i < Answer.Text.Length; i++)
            {
                if (Answer.Text[i] == '(' || Answer.Text[i] == ')')
                    check++;
                if (Answer.Text[i] == '0' && i != 0 && Answer.Text[i - 1] == '/')
                    checkForZero = true;
                if (!Char.IsDigit(Answer.Text[Answer.Text.Length - 1]) && Answer.Text[Answer.Text.Length - 1] != '(' && Answer.Text[Answer.Text.Length - 1] != ')')
                    endCheck = true;
            }
            if (check % 2 != 0 || checkForZero == true || endCheck == true)
            {
                Buttons1.IsEnabled = false;
                Buttons2.IsEnabled = false;
                Buttons3.IsEnabled = false;
                Buttons4.IsEnabled = false;
                text = Answer.Text;
                Answer.Clear();
                e.Handled = true;
                if (check % 2 != 0)
                    Answer.Text = error.Message1();
                else if (checkForZero == true)
                    Answer.Text = error.Message2();
                else if (endCheck == true)
                    Answer.Text = error.Message3();
                DispatcherTimer tm = new DispatcherTimer
                {
                    Interval = new TimeSpan(0, 0, 2)
                };
                tm.Tick += (s, ea) =>
                {
                    Answer.Text = text;
                    e.Handled = false;
                    Buttons1.IsEnabled = true;
                    Buttons2.IsEnabled = true;
                    Buttons3.IsEnabled = true;
                    Buttons4.IsEnabled = true;
                    tm.Stop();
                };
                tm.Start();
                return;
            }
            Answer.Text = Answer.Text + "=";
            str = Answer.Text;
            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] == '=') break;
                if (i == 0 && str[i] == '-' && str[i + 1] == '-')
                {
                    checkForMinus = true;
                    continue;
                }
                if (checkForMinus == true)
                {
                    checkForMinus = false;
                    continue;
                }
                if ((i == 0 && str[i] == '-') || ((str[i] == '-') && (str[i - 1] != ')') && !Char.IsDigit(str[i - 1])))
                {
                    str1 += str[i];
                    continue;
                }
                if (Char.IsDigit(str[i]) || str[i] == ',')
                {
                    str1 += str[i];
                    if ((i == str.Length - 1) || ((str[i + 1] != ',') && (!Char.IsDigit(str[i + 1]))))
                    {
                        number = Convert.ToDouble(str1);
                        stack1.Push(number);
                        str1 = string.Empty;
                    }
                }
                else if (str[i] == '(')
                {
                    stack2.Push(str[i]);
                    op = stack2.Peek();
                    continue;
                }
                else if (str[i] == ')')
                {
                    while (stack2.Peek() != '(')
                    {
                        op = stack2.Peek();
                        stack2.Pop();
                        getSolution(stack1, stack2, op);
                    }
                    stack2.Pop();
                    continue;
                }
                else
                {
                    if (stack2.Count() != 0)
                    {
                        op = stack2.Peek();
                        if ((str[i] == '*' || str[i] == '/') && (op == '+' || op == '-'))
                        {
                            stack2.Push(str[i]);
                            continue;
                        }
                        while (true)
                        {
                            if (stack2.Peek() != '(')
                            {
                                getSolution(stack1, stack2, op);
                                stack2.Pop();
                            }
                            else break;
                            if (stack2.Count() != 0)
                                op = stack2.Peek();
                            else break;
                            if ((str[i] == '*' || str[i] == '/') && (op == '+' || op == '-'))
                                break;
                        }
                    }
                    stack2.Push(str[i]);
                }
            }
            while (stack2.Count() != 0)
            {
                op = stack2.Peek();
                stack2.Pop();
                getSolution(stack1, stack2, op);
            }
            Answer.Text = Answer.Text + stack1.Peek();
            History.Text = Answer.Text + "\n" + History.Text;
        }
        public static void getSolution(Stack<double> stack1, Stack<char> stack2, char op)
        {
            var x = 0.0;
            var y = 0.0;
            var result = 0.0;
            x = stack1.Peek();
            stack1.Pop();
            if (stack1.Count == 0)
            {
                y = x;
                x = op == '+' || op == '-' ? 0 : 1;
            }
            else
            {
                y = stack1.Peek();
                stack1.Pop();
            }
            switch (op)
            {
                case '+':
                    result = y + x;
                    break;
                case '-':
                    result = y - x;
                    break;
                case '*':
                    result = y * x;
                    break;
                case '/':
                    result = y / x;
                    break;
                default: break;
            }
            stack1.Push(result);
        }

        private void HistorySenttings_Click(object sender, RoutedEventArgs e)
        {
            History.Text = string.Empty;
        }
    }
}

