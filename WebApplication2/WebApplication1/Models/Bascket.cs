using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Bascket
    {
        public string BasketID { get; set; }

        public List<BascketItem> listBascketItems { get; set; }
}
}