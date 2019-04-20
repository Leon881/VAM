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
    public partial class CalculatorTool : UserControl
    {
        public CalculatorTool()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Label.Content = Label.Content + "1";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Label.Content = Label.Content + "2";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Label.Content = Label.Content + "3";
        }
    }
}
