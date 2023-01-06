using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Interface;
using VendingMachine.Model;

namespace VendingMachine.Repository
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products;
        public IEnumerable<Product> getProductList()
        {
            return _products ?? (_products = new List<Product>
            {
                new Product() { productName = "Coke", price = 1.00m},
                new Product() { productName = "Chips", price = 0.50m},
                new Product() { productName = "Candy", price = 0.65m},
               
            });
        }
    }
}
