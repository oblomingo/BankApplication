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
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Threading;

namespace SilverlightBanking
{
    public partial class MainPage : UserControl
    {
        private DispatcherTimer timer;
        private Owner owner;
        private ObservableCollection<AccountActivity> accountActivitiesCollection;
        private int currentActivityId = 11;

        public MainPage()
        {
            InitializeComponent();
            InitializeOwner();
            InitializeActivitiesCollection();
            OwnerDetailGrid.DataContext = owner;
            AccountActivitiesListBox.ItemsSource = accountActivitiesCollection;

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            currentActivityId++;
            double amount = 0 - new Random().Next(100);
            AccountActivity newActivity = new AccountActivity();
            newActivity.ActivityId = currentActivityId;
            newActivity.Amount = amount;
            newActivity.Beneficiary = "Money withdrawal";
            newActivity.ActivityDescription = "ATM In Some Dark Alley";
            newActivity.ActivityDate = new DateTime(2009, 9, 18);
            owner.CurrentBalance += amount;
            owner.LastActivityDate = DateTime.Now;
            owner.LastActivityAmount = amount;

            accountActivitiesCollection.Add(newActivity);
        }

        private void InitializeOwner()
        {
            owner = new Owner() 
            { 
                OwnerId = 666,
                FirstName = "John",
                LastName = "Malkovich",
                Address = "Lenin street 17",
                ZipCode = "1917",
                City = "Rio",
                Country = "Brasil",
                State = "NA",
                ImageName = "man.jpg",
                LastActivityAmount = 5000,
                LastActivityDate = DateTime.Today,
                CurrentBalance = 15460.23,
                BirthDate = new DateTime(1901, 10, 15),
                CustomerSince = new DateTime(1960, 1, 1)
            }; 
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            LoanCalculation loanCalculation = new LoanCalculation();
            loanCalculation.Show();
        }

        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            ActivityDetailView detailView = new ActivityDetailView((AccountActivity)((TextBlock)sender).DataContext);
            detailView.Show();
        }

        private void InitializeActivitiesCollection()
        {
            accountActivitiesCollection = new ObservableCollection<AccountActivity>();
            
            AccountActivity accountActivity1 = new AccountActivity();
            accountActivity1.ActivityId = 1;
            accountActivity1.Amount = -33;
            accountActivity1.Beneficiary = "Smith Woodworking Shop London";
            accountActivity1.ActivityDescription = "Paid by credit card";
            accountActivity1.ActivityDate = new DateTime(2009, 9, 1);
            accountActivitiesCollection.Add(accountActivity1);

            AccountActivity accountActivity2 = new AccountActivity();
            accountActivity2.ActivityId = 2;
            accountActivity2.Amount = 1000;
            accountActivity2.Beneficiary = "ABC Infrastructure";
            accountActivity2.ActivityDescription = "Paycheck September 2009";
            accountActivity2.ActivityDate = new DateTime(2009, 9, 1);
            accountActivitiesCollection.Add(accountActivity2);

            RecurringAccountActivity recurringAccountActivity = new RecurringAccountActivity();
            recurringAccountActivity.ActivityId = 101;
            recurringAccountActivity.Amount = -120;
            recurringAccountActivity.Beneficiary = "Silverlight Bank";
            recurringAccountActivity.ActivityDescription = "Loan payment";
            recurringAccountActivity.ActivityDate = new DateTime(2009, 9, 1);
            recurringAccountActivity.RecurringActivityDescription = "Month September";
            accountActivitiesCollection.Add(recurringAccountActivity);
        }

        private void EditDetailsButtonTitle_Click(object sender, RoutedEventArgs e)
        {
            OwnerDetailsEdit details = new OwnerDetailsEdit(owner);
            details.Show();
        }
    }
}
