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
        PurchaseDAO purchaseDAO = new PurchaseDAO();

        [Authorize(Roles = "Seller, Buyer, Consultant")]
        public ActionResult Main()
        {
             return View();
        }

        [Authorize(Roles = "Seller, Buyer, Consultant")]
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

        [Authorize(Roles = "Seller, Buyer, Consultant")] // потом оставить только консультанта
        public ActionResult ControlIndex()
        {

            return View(prodactDAO.getAllNotControlProducts());
        }


        [Authorize(Roles = "Seller, Buyer, Consultant")] // потом оставить только консультанта
        public ActionResult Control(int id)
        {
            prodactDAO.Control(prodactDAO.getProduct(id));
            return View("ControlIndex", prodactDAO.getAllNotControlProducts());
        }

        [Authorize(Roles = "Seller, Buyer, Consultant")] // потом оставить только консультанта
        public ActionResult NotControl(int id)
        {
            prodactDAO.NotControl(prodactDAO.getProduct(id));
            return View("ControlIndex", prodactDAO.getAllNotControlProducts());
        }


        [Authorize(Roles = "Seller, Buyer, Consultant")] // потом оставить только продавца
        public ActionResult IndexPurchase()
        {
            try
            {
                return View(purchaseDAO.getAllPurhcase());
            }
            catch(Exception e)
            {
                return View("Error");
            }
        }



        [Authorize(Roles = "Seller, Buyer, Consultant")]
        public ActionResult Details(int id)
        {
            return View(prodactDAO.getProduct(id));
        }

       public ActionResult Create()
        {
            return View("Create");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = "Seller, Buyer, Consultant")]  // потом оставить только покупателя
        public ActionResult Create([Bind(Exclude = "Id")] int ProductId, Purchase purchase)
        {
            if (purchaseDAO.addPurchase(ProductId, purchase))
                return View("Purchase", purchase);
            else
                return View("Error");
        }

        [Authorize(Roles = "Seller, Buyer, Consultant")]  // потом оставить только продавца
        public ActionResult Buy(int id)
        {
            return View("Buy", purchaseDAO.getPurchase(id));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize(Roles = "Seller, Buyer, Consultant")]  // потом оставить только продавца
        public ActionResult Buy(int id, Purchase purchase)
        {
           if (purchaseDAO.updateStatus(purchase, "Finished"))
                return RedirectToAction("IndexPurchase");
            else
                return View("Error");
        }


        [Authorize(Roles = "Seller, Buyer, Consultant")]  // потом оставить только покупателя
        public ActionResult PurchaseStatus(int? id)
        {
            try
            {
                if (id==null)
                {
                    return View("PurchaseStatus");
                }
                else
                {
                    return View("Purchase", purchaseDAO.getPurchase((int)id));
                }

            }
            catch (Exception e)
            {
                return View("Error");
            }
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