namespace Roulette.API.Services
{
    public interface IAccountService
    {
        public void AddMoney(decimal quantity);

        public void RemoveMoney(decimal quantity);

        public decimal Balance();

    }
}
