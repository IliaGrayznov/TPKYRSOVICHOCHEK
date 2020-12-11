using Microsoft.Owin.Security.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DAO.interfaces;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public class PurchaseDAO :IpurchaseDAO
    {
        private DOOMshop2 doom = new DOOMshop2();
        private IproductDAO pd = new ProductDAO();
        private IorderDAO od = new OrderDAO();
        public Purchase getPurchase(int id)
        {
            return (from p in doom.Purchase
                    where p.Id == id
                    select p).FirstOrDefault();
        }

        public IEnumerable<Purchase> getAllPurhcase()
        {
            return (from p in doom.Purchase
                    where p.status.Equals("Created")
                    select p);
        }

        public bool addPurchase(int ProductId, Purchase purchase)
        {
            try
            {
                Product p = pd.getProduct(ProductId);
                purchase.date = DateTime.Now.ToString();
                purchase.ProductID = ProductId;
                purchase.price = purchase.count * p.price;
                if (p.count<purchase.count)
                {
                    purchase.status = "Wait";
                    Order ord = new Order();
                    ord.count = purchase.count;
                    ord.price = p.price / 2;
                    ord.ProductID = p.Id;
                    od.addOrder(ord);
                }
                else
                {
                    purchase.status = "Created";
                }
                doom.Purchase.Add(purchase);
                doom.SaveChanges();
                pd.updateCount(p, purchase.count);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool updateStatus(Purchase purchase, String status)
        {
            Purchase origPur = getPurchase(purchase.Id);
            try
            {
                origPur.status = status;
                doom.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}