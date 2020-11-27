using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ReturnController : Controller
    {
        private DOOMshop2 db = new DOOMshop2();
        private ReturnDAO returnDAO = new ReturnDAO();


        [Authorize(Roles = "Seller, Buyer, Consultant")]  // потом оставить только покупателя и продавца
        public ActionResult Return()
        {
            return View("Return");
        }

        [Authorize(Roles = "Seller, Buyer, Consultant")]   // потом оставить только продавца
        public ActionResult Index()
        {
             return View(returnDAO.getAllReturns());
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = "Seller, Buyer, Consultant")]  // потом оставить только покупателя
        public ActionResult Return([Bind(Exclude = "ID")] Return ret)
        {
            try
            {
                if (returnDAO.addReturn(ret))
                    return View("suckcessReturn");
                else
                {
                    return View("badReturn");
                }
            }
            catch
            {
                return View("Return");
            }
        }

        [Authorize(Roles = "Seller, Buyer, Consultant")]  // потом оставить только продавца
        public ActionResult Approve(int id)
        {
            return View("Approve", returnDAO.getReturn(id));
        }

        [HttpPost]
        [Authorize(Roles = "Seller, Buyer, Consultant")]  // потом оставить только продавца
        public ActionResult Approve(int id, Return ret)
        {
            try
            {
                if (returnDAO.approveReturn(ret))
                    return RedirectToAction("Index");
                else
                    return View("Error");
            }
            catch
            {
                return View("Error");
            }
        }

        [Authorize(Roles = "Seller, Buyer, Consultant")]  // потом оставить только продавца
        public ActionResult Delete(int id)
        {
            return View("Delete", returnDAO.getReturn(id));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = "Seller, Buyer, Consultant")]  // потом оставить только продавца
        public ActionResult Delete(int id, Return ret)
        {
            if (returnDAO.deleteReturn(ret))
                return RedirectToAction("Index");
            else
                return View("Error");
        }
    }
}
