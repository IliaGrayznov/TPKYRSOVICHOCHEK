using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        ProductDAO prodactDAO = new ProductDAO();
        ReturnDAO returnDAO = new ReturnDAO();
        [Authorize(Roles = "Admin,Visitor")]
        public ActionResult Index(string type)
        {
            if (type.IsNullOrWhiteSpace())
            {
                return View(prodactDAO.getAllProducts());
            }
            else
            {
                return View(prodactDAO.getProductsByType(type));
            }
        }

        [Authorize(Roles = "Admin, Visitor")]
        public ActionResult Return()
        {
            return View("Return");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = "Admin, Visitor")]
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

        [Authorize(Roles = "Admin,Visitor")]
        public ActionResult Details(int id)
        {
            return View(prodactDAO.getProduct(id));
        }

        /*[Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Exclude = "ID")] Records records)
        {
            try
            {
                if (recordsDAO.AddRecord(records))
                    return RedirectToAction("Index");
                else
                    return View("Create");
            }
            catch
            {
                return View("Create");
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id, [Bind(Exclude = "ID")] Records records)
        {
            try
            {
                if (recordsDAO.EditRecord(id, records))
                {
                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                if (recordsDAO.DeleteRecord(id))
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }*/

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}