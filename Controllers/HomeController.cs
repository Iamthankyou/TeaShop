using System.Collections.Generic;
using System.Web.Mvc;
using TeaMVC.Models;
using System.Linq;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        string Baseurl = "https://localhost:44300/";
        TeaEntities storeDB = new TeaEntities();
        [AllowAnonymous]
        //[OutputCache(Duration = 3600*12, Location = System.Web.UI.OutputCacheLocation.Server, VaryByParam ="*")]
        public async Task<ActionResult> Index()
        {
            // Get most popular Teas
            var Teas = GetTopSellingTeas(5);

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Home");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    Teas = JsonConvert.DeserializeObject<List<Tea>>(EmpResponse);

                }
            }

                if (HttpContext.Application["Theme"] == null)
                HttpContext.Application["Theme"] = LoadTheme();
            ViewBag.Message = "Sửa đổi theme.";

            return View(Teas);
        }

        public string LoadTheme(string Theme = null)
        {
            string sLocation = "/Content/bootstrap_";
         
            if (Theme == null || Theme=="Default")
            {
                sLocation += "Default.css";
            }
            else 
            {
                sLocation +=  Theme+".css";
            }   


            HttpContext.Application["Theme"] = sLocation;
            return HttpContext.Application["Theme"] as string;
        }

        private List<Tea> GetTopSellingTeas(int count)
        {
            // Group the order details by Tea and return
            // the Teas with the highest count
            return storeDB.Teas
                .OrderByDescending(a => a.OrderDetails.Sum(o => o.Quantity))
                .Take(count)
                .ToList();
        }

        [Authorize]
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
