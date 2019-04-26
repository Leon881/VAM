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
    public partial class CalculatorTool : UserControl
    {
        public CalculatorTool()
        {
            InitializeComponent();
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            Answer.Text = Answer.Text + "1";
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            Answer.Text = Answer.Text + "2";
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            Answer.Text = Answer.Text + "3";
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            Answer.Text = Answer.Text + "4";
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            Answer.Text = Answer.Text + "5";
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            Answer.Text = Answer.Text + "6";
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            Answer.Text = Answer.Text + "7";
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            Answer.Text = Answer.Text + "8";
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            Answer.Text = Answer.Text + "9";
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            Answer.Text = Answer.Text + "0";
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            Answer.Text = string.Empty;
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            Answer.Text = Answer.Text.Remove(Answer.Text.Length - 1, 1);
        }

        private void Point_Click(object sender, RoutedEventArgs e)
        {
            Answer.Text = Answer.Text + ",";
        }

        private void Bracket1_Click(object sender, RoutedEventArgs e)
        {
            Answer.Text = Answer.Text + "(";
        }

        private void Bracket2_Click(object sender, RoutedEventArgs e)
        {
            Answer.Text = Answer.Text + ")";
        }

        private void Devision_Click(object sender, RoutedEventArgs e)
        {
            Answer.Text = Answer.Text + "/";
        }

        private void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            Answer.Text = Answer.Text + "*";
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            Answer.Text = Answer.Text + "-";
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
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

        private void Equality_Click(object sender, RoutedEventArgs e)
        {
            string str = null;
            string str1 = null;
            char op = char.MinValue;
            var number = 0.0;
            var check = 0;
            Stack<double> stack1 = new Stack<double>();
            Stack<char> stack2 = new Stack<char>();
            foreach (var element in Answer.Text)
            {
                if (element == '(' || element == ')')
                    check++;
            }
            if (check % 2 != 0)
            {
                MessageBox.Show("Ошибка исходных данных. \n" + "Не у всех скобок есть пары. ", "Калькулятор", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Answer.Text = Answer.Text + "=";
            str = Answer.Text;
            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] == '=') break;
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
        }
        public static void getSolution(Stack<double> stack1, Stack<char> stack2, char op)
        {
            var x = 0.0;
            var y = 0.0;
            var result = 0.0;
            x = stack1.Peek();
            stack1.Pop();
            y = stack1.Peek();
            stack1.Pop();
            switch (op)
            {
                case '+':
                    result = x + y;
                    break;
                case '-':
                    result = y - x;
                    break;
                case '*':
                    result = x * y;
                    break;
                case '/':
                    result = y / x;
                    break;
                default: break;
            }
            stack1.Push(result);
        }
    }
}
