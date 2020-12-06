using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DAO.interfaces
{
   public  interface IproductDAO
    {
        IEnumerable<Product> getAllProducts();
        IEnumerable<Product> getAllNotControlProducts();
        bool Control(Product product);
        bool NotControl(Product product);
        IEnumerable<Product> getProductsByType(string type);
        Product getProduct(int id);
        bool updateCount(Product product, int count);
        bool deleteProduct(Product product);

    }
}
