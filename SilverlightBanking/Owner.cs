using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Collections;

namespace SilverlightBanking
{
    public class BaseEntry : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        // Last name validation (advance)
        public BaseEntry()
        {
            FailedRules = new Dictionary<string, string>();
        }

        protected Dictionary<string, string> FailedRules { get; set; }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (FailedRules.ContainsKey(propertyName))
                return FailedRules[propertyName];
            else
                return FailedRules.Values;
        }

        public bool HasErrors
        {
            get { return FailedRules.Count > 0; }
        }

        protected void NotifyErrorChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        // First name validation (simple)
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Owner: BaseEntry
    {
        private int ownerId;
        public int OwnerId
        { 
            get
            {
                return ownerId;
            } 

            set
            {
                ownerId = value;
                OnPropertyChanged("OwnerId");
            }
        }

        private string firstName;
        [StringLength(20, ErrorMessage = "Length must be <= 20")]
        public string FirstName 
        { 
            get
            {
                return firstName;
            } 

            set
            {
                if (firstName != value)
                {
                    Validator.ValidateProperty(value,
                    new ValidationContext(this, null, null) { MemberName = "FirstName" });

                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        private double currentBalance;
        public double CurrentBalance
        {
            get
            {
                return currentBalance;
            }

            set
            {
                currentBalance = value;
                OnPropertyChanged("CurrentBalance");
            }
        }

        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string address;
        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        private string zipCode;
        public string ZipCode
        {
            get
            {
                return zipCode;
            }

            set
            {
                zipCode = value;
                OnPropertyChanged("ZipCode");
            }
        }

        private string city;
        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }

        private string state;
        public string State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
                OnPropertyChanged("State");
            }
        }

        private string country;
        public string Country
        {
            get
            {
                return country;
            }

            set
            {
                country = value;
                OnPropertyChanged("Country");
            }
        }

        private DateTime birthDate;
        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }

            set
            {
                birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        public DateTime customerSince;
        public DateTime CustomerSince
        {
            get
            {
                return customerSince;
            }

            set
            {
                customerSince = value;
                OnPropertyChanged("CustomerSince");
            }
        }

        private string imageName;
        public string ImageName
        {
            get
            {
                return imageName;
            }

            set
            {
                imageName = value;
                OnPropertyChanged("ImageName");
            }
        }

        private DateTime lastActivityDate;
        public DateTime LastActivityDate
        {
            get
            {
                return lastActivityDate;
            }

            set
            {
                lastActivityDate = value;
                OnPropertyChanged("LastActivityDate");
            }
        }

        private double lastActivityAmount;
        public double LastActivityAmount
        {
            get
            {
                return lastActivityAmount;
            }

            set
            {
                lastActivityAmount = value;
                OnPropertyChanged("LastActivityAmount");
            }
        }

        private DateTime? noMoreCustomerSince;
        public DateTime? NoMoreCustomerSince
        {
            get
            {
                return noMoreCustomerSince;
            }
            set
            {
                if (noMoreCustomerSince != value)
                {
                    noMoreCustomerSince = value;
                    OnPropertyChanged("NoMoreCustomerSince");
                }
            }
        }

        internal void FireValidation()
        {
            if (lastName.Length > 20)
            {
                if (!FailedRules.ContainsKey("LastName"))
                    FailedRules.Add("LastName", "Last name cannot have more than 20 characters");
            }
            else
            {
                if (FailedRules.ContainsKey("LastName"))
                    FailedRules.Remove("LastName");
            }
            NotifyErrorChanged("LastName");
        }
    }
}
