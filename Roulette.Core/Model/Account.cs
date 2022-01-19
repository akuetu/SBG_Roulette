using System;
using System.Collections.Generic;
using System.Linq;

namespace Roulette.Service.Model
{
    /// <summary>
    /// Auxiliary class that simulates player balance management
    /// </summary>
    public class Account
    {
        private static Object thisLock = new Object();
        private static List<decimal> DbBalance = new List<decimal>();


        public void AddMoney(decimal quantity)
        {
            lock (thisLock)
            {
                DbBalance.Add(quantity);
            }
        }

        public void RemoveMoney(decimal quantity)
        {
            lock (thisLock)
            {
                DbBalance.Add(-quantity);
            }
        }

        public decimal Balance()
        {
            lock (thisLock)
            {
                return DbBalance.Sum();
            }
        }
    }
}