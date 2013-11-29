using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightBanking
{
    public class AccountActivity
    {
        public int ActivityId { get; set; }
        public double Amount { get; set; }
        public string Beneficiary { get; set; }
        public DateTime ActivityDate { get; set; }
        public string ActivityDescription { get; set; }
    }

    public class RecurringAccountActivity : AccountActivity
    {
        public string RecurringActivityDescription { get; set; }
    }
}
