using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public class ReturnDAO
    {
        private DOOMshop2 doom = new DOOMshop2();

        public Purchase GetPurchase(int? id)
        {
            if (id != null)
                return (from p in doom.Purchase
                        where p.Id == id
                        select p).First();
            else
                throw new Exception(); //may be need to change
        }
        public bool addReturn(Return ret)
        {
            try
            {
                ret.status = "check_wait_1";
                Purchase p = GetPurchase(ret.PurchaseID);
                DateTime d = DateTime.Now;
                TimeSpan d1 = d.Subtract(DateTime.Parse(p.date));
                if (d1.Days < 100)
                {
                    ret.status = "check_wait_2";
                    doom.Return.Add(ret);
                    doom.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}