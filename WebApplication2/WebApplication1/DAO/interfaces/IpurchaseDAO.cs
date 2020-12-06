using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DAO.interfaces
{
    public interface IpurchaseDAO
    {
        Purchase getPurchase(int id);
        IEnumerable<Purchase> getAllPurhcase();
        bool addPurchase(int ProductId, Purchase purchase);
        bool updateStatus(Purchase purchase, String status);
    }
}
