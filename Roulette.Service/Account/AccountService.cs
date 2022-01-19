using Roulette.API.Services;

namespace Roulette.Service.Account
{
    /// <summary>
    /// Auxiliary class that simulates player balance management
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly Core.Model.Account _account;

        public AccountService()
        {
            _account = new Core.Model.Account();
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
