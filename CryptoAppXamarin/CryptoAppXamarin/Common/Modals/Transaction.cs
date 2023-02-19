using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoAppXamarin.Common.Modals
{
   public class Transaction
    {
        public string Symbol { get; set; }
        public decimal Amount { get; set; }
        public decimal DollarValue { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
        public string StatusImageSource { get; set; }
    }
}
