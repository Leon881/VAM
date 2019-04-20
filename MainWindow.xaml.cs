using Multiplector.Tools;
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

namespace Multiplector
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


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var view = new CalculatorTool();
            this.OutputView.Content = view;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Привет я с вами!!!
            //Саня, делай интерфейс
            var view = new ConverterTool();
            this.OutputView.Content = view;
        }

    }
}
