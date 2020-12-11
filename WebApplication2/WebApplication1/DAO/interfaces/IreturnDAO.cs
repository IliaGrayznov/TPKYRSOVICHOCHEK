using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DAO.interfaces
{
    public interface IreturnDAO
    {
        Purchase GetPurchase(int? id);
        Return getReturn(int id);
        IEnumerable<Return> getAllReturns();
        bool addReturn(Return ret);
        bool approveReturn(Return ret);
        bool deleteReturn(Return ret);

    }
}
