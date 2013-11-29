using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightBanking
{
    public partial class LoanCalculation : ChildWindow
    {
        private double percentage = 0.0345;
        public LoanCalculation()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            double amount = AmountSlider.Value;
            int number = (int)MounthsNumberSlider.Value;

            for (int i = 0; i < number; i++)
            {
                amount += amount * percentage;
            }

            double mounthlyPayback = amount / (number * 12);
            ResultTextBlock.Text = "$" + Math.Round(mounthlyPayback, 2);
        }
    }
}

