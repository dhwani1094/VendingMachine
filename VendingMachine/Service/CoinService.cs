using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Interface;
using VendingMachine.Model;

namespace VendingMachine.Service
{
    public class CoinService : ICoinService
    {
        private readonly ICoinRepository _coinRepository;
        public CoinService(ICoinRepository coinRepository)
        {
            if (coinRepository == null) throw new ArgumentNullException("productRepository parameter is null");
            _coinRepository = coinRepository;

        }

        public IEnumerable<Coins> getValidCoins()
        {
            return _coinRepository.getValidCoins();
        }

        public Coins getCoin(string cointype)
        {
            return _coinRepository.getValidCoins().FirstOrDefault((i) =>   i.coinName.ToUpper().Equals(cointype.ToUpper()) );
        }

    }
}
