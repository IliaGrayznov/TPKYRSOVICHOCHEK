using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.DAO.interfaces
{
    interface IDAOfactory
    {
        IorderDAO GetIorderDAO();
        IproductDAO GetIproductDAO();
        IpurchaseDAO GetIpurchaseDAO();
        IreturnDAO GetIreturnDAO();
    }
}
