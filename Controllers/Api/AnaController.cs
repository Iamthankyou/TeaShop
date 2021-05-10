using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeaMVC.Models;

namespace TeaMVC.Controllers.Api
{
    public class AnaController : Controller
    {

        private TeaEntities db = new TeaEntities();

        // GET: Ana
        public ActionResult Index()
        {
            return null;
        }

        // GET: Ana/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ana/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ana/Create
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

        // GET: Ana/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ana/Edit/5
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

        // GET: Ana/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ana/Delete/5
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
    }
}
