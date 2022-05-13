using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    class Account
    {
        public string AccountNumber { get; set; }
        public int UserId { get; set; }
        public bool IsBlocked { get; set; }
        public double Balance { get; set; }
        public CurrencyEnum Currency { get; set; }
        public static List<Account> account;
    }
}
