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
using System.Windows.Shapes;

namespace M120Projekt.B1
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : UserControl
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateOverview createView = new CreateOverview();
            this.Overview.Content = createView;
        }
    }
}
