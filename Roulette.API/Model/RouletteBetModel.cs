using System.ComponentModel.DataAnnotations;
using Roulette.Service.Services;
using Roulette.Service.Shared;

namespace Roulette.API.Model
{
    public class RouletteBetModel
    {
        [Required(ErrorMessage = "Type Of Bet is required")]
        public TypeOfBet TypeOfBet { get; set; }

        public int[] Bets { get; set; }

        public Account Account { get; set; }
    }
}
