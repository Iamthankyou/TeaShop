using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeaMVC.Models;
using TeaMVC.ViewModels;
using PagedList;
using PagedList.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Type = TeaMVC.Models.Type;

namespace TeaMVC.Controllers
{


    public class StoreController : Controller
    {
        string Baseurl = "https://localhost:44300/";

        //
        TeaEntities storeDB = new TeaEntities();
        // GET: /Store/
        public ActionResult Index()
        {
            var Types = storeDB.Types.ToList();            
            return View(Types);
           
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

        //
        // url: "store/{Type}"
        public ActionResult Browse(int? page, string Type = "Hot")
        {
           // Retrieve Type and its Associated Teas from database
            var TypeModel = storeDB.Types.Include("Teas")
                .Single(g => g.Name == Type).Teas;


            return View(TypeModel.ToList().ToPagedList(page?? 1, 6));
        }

        // GET: /Store/Details/5
        public async  Task<ActionResult> Details(int id)
        {
            var Teas = storeDB.Teas.Find(id);

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Tea/"+ id.ToString());

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    Teas = JsonConvert.DeserializeObject<List<Tea>>(EmpResponse).Single();

                }
            }

            return View(Teas);

        }


        [ChildActionOnly]
        public async Task<ActionResult> TypeMenu()   
        {                        
            var Types = storeDB.Types.Include("Teas").OrderBy(g => g.Name);
            var model = Types.ToList();

            Task.Run(async () =>
            {

                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync("api/TypeMenu");

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        model = JsonConvert.DeserializeObject<List<Type>>(EmpResponse);

                    }
                }

            });

            return PartialView("_TypeMenu", model);

            
        }
    }
}