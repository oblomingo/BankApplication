using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightBanking
{
    public partial class OwnerDetailsEdit : ChildWindow
    {
        private Owner owner;
        public OwnerDetailsEdit(Owner owner)
        {
            this.owner = owner;
            InitializeComponent();
            OwnerDetailsGrid.DataContext = owner;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression be = this.FirstNameValueTextBlock.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();

            this.DialogResult = true;
        }

        private void OwnerDetailsGrid_BindingValidationError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                OwnerDetailsGrid.Background = new SolidColorBrush(Color.FromArgb(25, 255, 0, 0));

            if (e.Action == ValidationErrorEventAction.Removed)
                OwnerDetailsGrid.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        }

        private void ValidateButton_Click(object sender, RoutedEventArgs e)
        {
            owner.FireValidation();
        }
    }
}

