using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Records
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int ID_country { get; set; }
        public int year { get; set; }
        public int averange_rating { get; set; }
        public int ID_winner { get; set; }
        public int pool_prize { get; set; }
        public bool tie_break { get; set; }
    }
}