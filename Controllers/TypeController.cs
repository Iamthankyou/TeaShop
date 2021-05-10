using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TeaMVC.Models;
using Type = TeaMVC.Models.Type;

namespace TeaMVC.Controllers
{
    public class TypeController : Controller
    {
        string Baseurl = "https://localhost:44300/";
        TeaEntities storeDB = new TeaEntities();

        private TeaEntities db = new TeaEntities();

        // GET: Type
        public async Task<ActionResult> Index()
        {
            var Teas = storeDB.Types.ToList();

            using (var client = new System.Net.Http.HttpClient())
            {


                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Types");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    Teas = JsonConvert.DeserializeObject<List<Type>>(EmpResponse); 

                }
            }

            return View(Teas);
        }

        // GET: Type/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Type/Create
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

        // GET: Type/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Type/Edit/5
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

        // GET: Type/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Type/Delete/5
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
