using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    public class BananaService : IBananaService
    {
        public event Action OnChange;

        void BananaChanged() => OnChange.Invoke();
        public int Bananas { get; set; }

        public void EatBananas(int amount)
        {
            Bananas -= amount;
            BananaChanged();
        }

        public void AddBananas(int amount)
        {
            Bananas += amount;
            BananaChanged();
        }
    }
}
