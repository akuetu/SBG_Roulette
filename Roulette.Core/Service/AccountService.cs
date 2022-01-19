using Roulette.Core.Model;

namespace Roulette.API.Services
{
    /// <summary>
    /// Auxiliary class that simulates player balance management
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly Account _account;

        public AccountService()
        {
            _account = new Account();
        }

        
        public void AddMoney(decimal quantity)
        {
            _account.AddMoney(quantity);
        }

        public void RemoveMoney(decimal quantity)
        {
            _account.RemoveMoney(quantity);
        }

        public decimal Balance()
        {
            return _account.Balance();
        }
    }
}
