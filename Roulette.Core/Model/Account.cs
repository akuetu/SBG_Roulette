using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Core.Model
{
    public class Account
    {
        private decimal _balance = 0;
        public UserAccount UserAccount { get; set; }

        public Account(decimal balance)
        {
            _balance = balance;
        }

        public decimal AddPrizeValue(decimal prizeValue)
        {
            return _balance += prizeValue;
        }

        public decimal Balance()
        {
            return _balance;
        }
    }
}
