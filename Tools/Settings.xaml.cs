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
using System.Windows.Threading;

namespace Multiplector.Tools
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Time1_Checked(object sender, RoutedEventArgs e)
        {
            var text =(TextBox)Owner.FindName("Clock");
            DispatcherTimer tm = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            tm.Tick += (s, ea) =>
            {
                text.Text = DateTime.Now.ToString(@"HH\:mm\:ss  dd\.MM\.yyyy");
            };
            tm.Start();
            Owner.Activate();
        }

        private void Time2_Checked(object sender, RoutedEventArgs e)
        {
            var text = (TextBox)Owner.FindName("Clock");
            DispatcherTimer tm = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            tm.Tick += (s, ea) =>
            {
                text.Text = DateTime.Now.ToString(@"HH\:mm\:ss  dd MMMM yyyy");
            };
            tm.Start();
            Owner.Activate();
        }
    }
}
