﻿using System;
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
    public partial class AboutProgramm : UserControl
    {
        public AboutProgramm()
        {
            InitializeComponent();
            Logo.Source = new BitmapImage(new Uri( "/image/UrFULogo_Full_Russian.png", UriKind.Relative));

        }
    }
}
