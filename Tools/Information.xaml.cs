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

    public partial class Informations : UserControl
    {
        public Informations()
        {
            InitializeComponent();
            Logo.Source = new BitmapImage(new Uri("/image/Logo.jpg", UriKind.Relative));
        }
    }
}
