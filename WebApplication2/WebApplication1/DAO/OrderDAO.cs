using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DAO.interfaces;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public class OrderDAO: IorderDAO
    {
        private DOOMshop2 doom = new DOOMshop2();
        public bool addOrder(Order ord)
        {
            try
            {
                doom.Order.Add(ord);
                doom.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}