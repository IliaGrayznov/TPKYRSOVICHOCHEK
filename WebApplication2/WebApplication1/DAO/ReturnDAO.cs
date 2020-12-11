using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DAO.interfaces;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public class ReturnDAO : IreturnDAO
    {
        private DOOMshop2 doom = new DOOMshop2();
        private IpurchaseDAO purchaseDAO = new PurchaseDAO();

        public Purchase GetPurchase(int? id)
        {
            if (id != null)
                return (from p in doom.Purchase
                        where p.Id == id
                        select p).First();
            else
                throw new Exception(); //may be need to change
        }
        public Return getReturn(int id)
        {
            return (from p in doom.Return
                    where p.Id == id
                    select p).FirstOrDefault();
        }

        public IEnumerable<Return> getAllReturns()
        {
            return (from r in doom.Return
                    select r);
        }
        public bool addReturn(Return ret)
        {
            try
            {
                ret.status = "check_wait_1";
                Purchase p = GetPurchase(ret.PurchaseID);
                DateTime d = DateTime.Now;
                TimeSpan d1 = d.Subtract(DateTime.Parse(p.date));
                if (d1.Days < 100 && p.status.Equals("Finished            "))
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

        public bool approveReturn(Return ret)
        {
            try
            {
                Return origRet = getReturn(ret.Id);
                Purchase p = purchaseDAO.getPurchase(origRet.PurchaseID);
                purchaseDAO.updateStatus(p, "Returned");
                doom.Return.Remove(origRet);
                doom.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool deleteReturn(Return ret)
        {
            try
            {
                Return origRet = getReturn(ret.Id);
                doom.Return.Remove(origRet);
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