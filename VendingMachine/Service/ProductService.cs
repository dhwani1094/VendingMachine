using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Interface;
using VendingMachine.Model;

namespace VendingMachine.Service
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        
        public ProductService(IProductRepository productRepository)
        {
            if (productRepository == null) throw new ArgumentNullException("productRepository parameter is null");
            _productRepository = productRepository;
            
        }



        public Product GetProduct(string productName)
        {
            return GetAllProducts().FirstOrDefault(x => x.productName.ToLower() == productName.ToLower());
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.getProductList();
        }

        
    }
}
