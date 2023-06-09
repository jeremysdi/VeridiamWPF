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

namespace Veridiam
{
    /// <summary>
    /// Interaction logic for ServoControl.xaml
    /// </summary>
    public partial class ServoControl : UserControl
    {
        public ServoControl()
        {
            InitializeComponent();
        }

        private void BtnServoOn_Click(object sender, RoutedEventArgs e)
        {
            ScanSystem.ServoOn();
        }

        private void BtnServoOff_Click(object sender, RoutedEventArgs e)
        {
            ScanSystem.ServoOff();
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            ScanSystem.Reset();
        }
    }
}
