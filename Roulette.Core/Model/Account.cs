using System.Collections.Generic;
using System.Linq;

namespace Roulette.Core.Model
{
    /// <summary>
    /// Auxiliary class that simulates player balance management
    /// </summary>
    public class Account
    {
        public static List<decimal> DbBalance = new List<decimal>();


        public void AddMoney(decimal quantity)
        {
            DbBalance.Add(quantity);
        }

        public void RemoveMoney(decimal quantity)
        {
            DbBalance.Add(-quantity);
        }

        public decimal Balance()
        {
            return DbBalance.Sum();
        }
    }
}