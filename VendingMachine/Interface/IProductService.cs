using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Model;

namespace VendingMachine.Interface
{
    public interface IProductService
    {
    
        Product GetProduct(string code);
        IEnumerable<Product> GetAllProducts();
        
    }
}
