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

namespace Veridiam
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void BtnJogBack_Click(object sender, RoutedEventArgs e)
        {
            ScanSystem.JogBack();
        }

        private void BtnJog_Click(object sender, RoutedEventArgs e)
        {
            ScanSystem.Jog();
        }

        private void BtnFullStepBack_Click(object sender, RoutedEventArgs e)
        {
            ScanSystem.FullStepBack();
        }

        private void BtnFullStep_Click(object sender, RoutedEventArgs e)
        {
            ScanSystem.FullStep();
        }

        private void BtnTenStep_Click(object sender, RoutedEventArgs e)
        {
            ScanSystem.TenStep();
        }

        private void BtnTenStepBack_Click(object sender, RoutedEventArgs e)
        {
            ScanSystem.TenStepBack();
        }

        private void BtnHundoStep_Click(object sender, RoutedEventArgs e)
        {
            ScanSystem.HundoStep();
        }

        private void BtnHundoStepBack_Click(object sender, RoutedEventArgs e)
        {
            ScanSystem.HundoStepBack();
        }

        private void BtnThouStep_Click(object sender, RoutedEventArgs e)
        {
            ScanSystem.ThouStep();
        }

        private void BtnThouStepBack_Click(object sender, RoutedEventArgs e)
        {
            ScanSystem.ThouStepBack();
        }
    }
}
