using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeaMVC.Models;
using TeaMVC.ViewModels;
using PagedList;
using PagedList.Mvc;


namespace TeaMVC.Controllers
{
    public class StoreController : Controller
    {
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
        public ActionResult Details(int id)
        {
            var Tea = storeDB.Teas.Find(id);

            return View(Tea);
        }

        [ChildActionOnly]
        public ActionResult TypeMenu()   
        {                        
            var Types = storeDB.Types.Include("Teas").OrderBy(g => g.Name);
            var model = Types.ToList();         
            return PartialView("_TypeMenu", model);
        }
    }
}