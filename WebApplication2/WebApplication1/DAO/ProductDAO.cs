using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public class ProductDAO
    {
        private DOOMshop2 doom = new DOOMshop2();


        public IEnumerable<Product> getAllProducts()
        {
            return (from p in doom.Product
                    where p.qualitycontrol == 1
                    select p);
        }

        public IEnumerable<Product> getProductsByType(string type)
        {
            return (from p in doom.Product
                    where p.qualitycontrol == 1 && p.type == type
                    select p);
        }

        public Product getProduct(int id)
        {
            return (from p in doom.Product
                    where p.Id == id
                    select p).FirstOrDefault();
        }
    }
}
