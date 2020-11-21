using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public class PurchaseDAO
    {
        private DOOMshop2 doom = new DOOMshop2();
        public Purchase getPurchase(int? id)
        {
            return (from p in doom.Purchase
                    where p.Id == id
                    select p).FirstOrDefault();
        }
    }
}