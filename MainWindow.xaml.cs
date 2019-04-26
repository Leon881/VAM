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

namespace Multiplector
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int NowOpen=0;
        public MainWindow()
        {
            InitializeComponent();
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
                ConverterSelect.Background = new SolidColorBrush(Colors.White);
                CalculatorSelect.Background = new SolidColorBrush(Colors.Firebrick);
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = 712;
                animation.To = 0;
                animation.Duration = TimeSpan.FromMilliseconds(200);
                animation.Completed += AnimationClosePresenter_Completed;
                ContentPresenter.BeginAnimation(Grid.WidthProperty, animation);
            }
        }

        private void AnimationClosePresenter_Completed(object sender, EventArgs e)
        {
            var view = new ConverterTool();
            this.OutputView.Content = view;
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 712;
            animation.Duration = TimeSpan.FromMilliseconds(200);
            ContentPresenter.BeginAnimation(Grid.WidthProperty, animation);
            NowOpen = 1;
        }


        private void AboutProgramm_Click(object sender, RoutedEventArgs e)
        {
            var view = new AboutProgramm();
            this.OutputView.Content = view;
            NowOpen = 11;
        }

        private void Calculator_Click(object sender, RoutedEventArgs e)
        {
            if (NowOpen == 2) return;
            else
            {
                ConverterSelect.Background = new SolidColorBrush(Colors.Firebrick);
                CalculatorSelect.Background = new SolidColorBrush(Colors.White);
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = 712;
                animation.To = 0;
                animation.Duration = TimeSpan.FromMilliseconds(200);
                animation.Completed += AnimationClosePresenter_Completed2;
                ContentPresenter.BeginAnimation(Grid.WidthProperty, animation);
            }
        }
        private void AnimationClosePresenter_Completed2(object sender, EventArgs e)
        {
            var view = new CalculatorTool();
            this.OutputView.Content = view;
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 712;
            animation.Duration = TimeSpan.FromMilliseconds(200);
            ContentPresenter.BeginAnimation(Grid.WidthProperty, animation);
            NowOpen = 2;
        }

    }
}
