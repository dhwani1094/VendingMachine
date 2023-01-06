using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Interface;
using VendingMachine.Model;

namespace VendingMachine
{
    
    public class VendingMachineImplementation
    {
        private readonly IProductService _productService;
        private readonly ICoinService _coinService;
        List<Coins> allCoins;
        List<Product> allProducts;
        public decimal totalCoinsAmount = 0;
        public VendingMachineImplementation(ICoinService coinService, IProductService productService)
        {
            _coinService = coinService;
            _productService = productService;
        }


        public void getMasterData()
        {
            allCoins = getAllCoins();
            allProducts = getAllProducts();
        }
        public void processVendingMachine()
        {
            try
            {
                var selectedProduct = acceptProductCode();
                if (selectedProduct != null)
                {
                    acceptCoinsandProcess(selectedProduct);

                }
                else
                {
                    Console.WriteLine("\n Error: Invalid product selected. Please select correct product code");
                    processVendingMachine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while processing");
            }
        
           
        }

        public Product acceptProductCode()
        {
            Console.WriteLine("\n Enter the Product code from below list:");
            foreach (var i in allProducts)
            {

                Console.WriteLine( i.productName + "( $" + i.price + " )");
            }

            Console.Write("\n Product Code:");
            string inputProductCode = Console.ReadLine();
            return getProduct(inputProductCode);
        }

        public void acceptCoinsandProcess( Product selectedProduct)
        {
            
                var inputCoinType=acceptCoin();
                if (inputCoinType != null)
                {
                    Console.Write("\n Enter the Total Number of " + inputCoinType.coinName + " inserted : ");
                    var totalCoinsInserted = Console.ReadLine();
                    decimal totalCoinsValue = Convert.ToDecimal(totalCoinsInserted) * Convert.ToDecimal(inputCoinType.coinValue);
                    totalCoinsAmount = totalCoinsValue + totalCoinsAmount;
                    decimal totalProductAmount =  selectedProduct.price;
                    if (totalProductAmount > totalCoinsAmount)
                    {
                        Console.WriteLine("Entered amount is less than the required product amount");
                        Console.WriteLine("Product Amount : " + totalProductAmount + ", Entered Amount :" + totalCoinsAmount);
                        Console.Write("Do you wish to add more coins(Y/N) :");
                        string reEntercoinStatus = Console.ReadLine();
                        if (reEntercoinStatus != null && reEntercoinStatus.ToUpper() == "Y")
                        {
                            acceptCoinsandProcess(selectedProduct);
                        }
                        else
                        {
                            Console.WriteLine("\n Your Transaction got cancelled.");
                            Console.WriteLine("Thank You for using vending machine");
                        }

                    }
                    else
                    {
                       Console.WriteLine("Thank You for using vending machine");
                       totalCoinsAmount = 0;
                      
                    }
                }
                else
                {
                    Console.WriteLine("InValid Coin Type entered");
                    acceptCoinsandProcess(selectedProduct);
            }
           
            
        }

        public List<Coins> getAllCoins()
        {
            return _coinService.getValidCoins().ToList();
        }

        public Coins acceptCoin()
        {
            Console.Write("\nSelect the Coin type:");
            Console.WriteLine("");
            foreach (var i in allCoins)
            {

                Console.WriteLine(i.coinName);
            }
            Console.Write("\n Enter the Valid Coin Type : ");
            string inputCoin = Console.ReadLine();
            var coinType = getCoin(inputCoin);
            return coinType;
        }

        public List<Product> getAllProducts()
        {
            return _productService.GetAllProducts().ToList();
        }

        public Product getProduct(string inputProductCode)
        {
            return _productService.GetProduct(inputProductCode);
        }

        public Coins getCoin(string inputCoin)
        {
            return _coinService.getCoin(inputCoin);
        }

    }
}
