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
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Threading;
using Autorization_form;
using Multiplector.Autorization;

namespace Multiplector
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int NowOpen = 0;
        ConverterTool view1 = new ConverterTool();
        CalculatorTool view2 = new CalculatorTool();
        CalendarTool view4 = new CalendarTool();
        PaintTool view5 = new PaintTool();
        ClothesTool view6 = new ClothesTool();

        public MainWindow()
        {
            InitializeComponent();
            StartClock();
        }

        private void ButtonPopUp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {

            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void Converter_Click(object sender, RoutedEventArgs e)
        {
            if (NowOpen == 1) return;            
            else
            {
                NowOpen = 1;
                WhiteLineChange();
                Startanimation();
            }
        }
     
        private void Calculator_Click(object sender, RoutedEventArgs e)
        {
            if (NowOpen == 2) return;         
            else
            {
                NowOpen = 2;
                WhiteLineChange();
                Startanimation();
            }
        }

        private void Calendar_Click(object sender, RoutedEventArgs e)
        {
            if (NowOpen == 4) return;
            else
            {
                NowOpen = 4;
                WhiteLineChange();
                Startanimation();
            }
        }

        private void Paint_Click(object sender, RoutedEventArgs e)
        {
            if (NowOpen == 5) return;
            else
            {
                NowOpen = 5;
                WhiteLineChange();
                Startanimation();
            }
        }

        private void Clothes_Click(object sender, RoutedEventArgs e)
        {
            if (NowOpen == 3) return;
            else
            {
                NowOpen = 3;
                WhiteLineChange();
                Startanimation();
            }
        }

        private void AboutProgramm_Click(object sender, RoutedEventArgs e)
        {
            var view = new AboutProgramm();
            this.OutputView.Content = view;
            NowOpen = 11;
        }

        private void Startanimation()
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 712;
            animation.To = 0;
            animation.Duration = TimeSpan.FromMilliseconds(200);
            animation.Completed += AnimationClosePresenter_Completed;
            ContentPresenter.BeginAnimation(Grid.WidthProperty, animation);
        }

        private void AnimationClosePresenter_Completed(object sender, EventArgs e)
        {           
            if (NowOpen == 1)
            {
                this.OutputView.Content = view1;
            }
            if (NowOpen == 2)
            {
                this.OutputView.Content = view2;
            }
            if (NowOpen == 4)
            {
                this.OutputView.Content = view4;
            }
            if (NowOpen == 5)
            {
                this.OutputView.Content = view5;
            }
            if (NowOpen == 3)
            {
                this.OutputView.Content = view6;
            }
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 712;
            animation.Duration = TimeSpan.FromMilliseconds(200);
            ContentPresenter.BeginAnimation(Grid.WidthProperty, animation);           
        }

        private void WhiteLineChange()
        {
            PaintSelect.Background = new SolidColorBrush(Colors.Firebrick);
            CalculatorSelect.Background = new SolidColorBrush(Colors.Firebrick);
            ConverterSelect.Background = new SolidColorBrush(Colors.Firebrick);
            CalendarSelect.Background = new SolidColorBrush(Colors.Firebrick);
            ClothesSelect.Background = new SolidColorBrush(Colors.Firebrick);
            if (NowOpen==1) ConverterSelect.Background = new SolidColorBrush(Colors.White);
            if (NowOpen == 2) CalculatorSelect.Background = new SolidColorBrush(Colors.White);
            if (NowOpen == 4) CalendarSelect.Background = new SolidColorBrush(Colors.White);
            if (NowOpen == 5) PaintSelect.Background = new SolidColorBrush(Colors.White);
            if (NowOpen == 3) ClothesSelect.Background = new SolidColorBrush(Colors.White);
        }

        private void StartClock()
        {
            DispatcherTimer tm = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            tm.Tick += (s, ea) =>
            {
                // На будущее оставил
                //if (Radio1.IsChecked == true)
                //{
                //    Clock.Text = DateTime.Now.ToString(@"HH\:mm\:ss  dd\.MM\.yyyy");
                //}
                //else if (Radio2.IsChecked == true)
                    Clock.Text = DateTime.Now.ToString(@"HH\:mm\:ss  dd MMMM yyyy");
            };
            tm.Start();
        }

        private void Autorization_Click(object sender, RoutedEventArgs e)
        {
            var atrz = new Autorization_form.MainWindow();
            atrz.Owner = this;
            atrz.Show();
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            UserLogin.SetValue(TextBlock.TextProperty, null);
            UserLogin.Visibility = Visibility.Hidden;
            SignOut.Visibility = Visibility.Hidden;
            Autorization.Visibility = Visibility.Visible;
            this.OutputView.Content = view1;
            PaintSelect.Background = new SolidColorBrush(Colors.Firebrick);
            CalculatorSelect.Background = new SolidColorBrush(Colors.Firebrick);
            CalendarSelect.Background = new SolidColorBrush(Colors.Firebrick);
            ClothesSelect.Background = new SolidColorBrush(Colors.Firebrick);
            ConverterSelect.Background = new SolidColorBrush(Colors.White);
            Calculator.IsEnabled = false;
            Calendar.IsEnabled = false;
            Clothes.IsEnabled = false;
            Paint.IsEnabled = false;
        }

        private void ExcelExport_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Пользователи экспортированы!");
            ExcelSaver.AddUsersToSheet();
        }
    }
}