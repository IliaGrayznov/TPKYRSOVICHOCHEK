using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DAO.interfaces;

namespace WebApplication1.DAO
{
    public class DAOfactory : IDAOfactory
    {
        public IorderDAO GetIorderDAO()
        {
            return new OrderDAO();
        }

        public IproductDAO GetIproductDAO()
        {
            return new ProductDAO();
        }

        public IpurchaseDAO GetIpurchaseDAO()
        {
            return new PurchaseDAO();
        }
        public IreturnDAO GetIreturnDAO()
        {
            return new ReturnDAO();
        }
    }
}