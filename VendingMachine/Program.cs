using System;
using VendingMachine.Repository;
using VendingMachine.Service;

namespace VendingMachine
{
    class Program
    {
       
        static void Main(string[] args)
        {

            VendingMachineImplementation vendingMachine = new VendingMachineImplementation(new CoinService(new CoinRepository()), new ProductService(new ProductRepository()));
            vendingMachine.getMasterData();
            vendingMachine.processVendingMachine();
            Console.ReadLine();




        }
    }
}
