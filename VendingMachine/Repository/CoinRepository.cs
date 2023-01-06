using System;
using System.Collections.Generic;
using VendingMachine.Interface;
using VendingMachine.Model;

namespace VendingMachine.Repository
{
    public class CoinRepository : ICoinRepository
    {

        private static List<Coins> _coins;

        public IEnumerable<Coins> getValidCoins()
        {
            return _coins ?? (_coins = new List<Coins>
            {
                new Coins() { coinName = "Nickles", coinValue = "0.05"},
                new Coins() { coinName = "Dimes", coinValue = "0.10"},
                new Coins() { coinName = "Quarters", coinValue = "0.25"},
            });
        }
    }
}
