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

namespace TeaMVC.Controllers
{
    public class AnaController : Controller
    {

        string Baseurl = "https://localhost:44300/";
        TeaEntities storeDB = new TeaEntities();



        // GET: Ana
        public async Task<ActionResult> Index()
        {
            var Teas = storeDB.Orders.ToList();

            using (var client = new System.Net.Http.HttpClient())
            {
                

                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Orders");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    Teas = JsonConvert.DeserializeObject<List<Order>>(EmpResponse);

                }
            }

            return View(Teas);
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
