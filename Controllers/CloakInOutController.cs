using GS.DBoperations;
using GS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GS.Controllers
{
    public class CloakInOutController : Controller
    {
        // GET: CloakInOut
        public ActionResult Index()
        {
            return View(DBOperations1.Get<GetCloakinout>("GetCloakinout", null));
        }

        // GET: CloakInOut/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CloakInOut/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CloakInOut/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CloakInOut/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CloakInOut/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CloakInOut/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CloakInOut/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Reports()
        {
            getcloakinoutbystaffidbtwdates RC = new getcloakinoutbystaffidbtwdates();

            return View(RC);
        }
    }
}
