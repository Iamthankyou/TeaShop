using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeaMVC.Models;
using TeaMVC.ViewModels;

namespace TeaMVC.Controllers
{
   
        // GET: ShoppingCart
        public class ShoppingCartController : Controller
        {
            TeaEntities storeDB = new TeaEntities();
            //
            // GET: /ShoppingCart/
            public ActionResult Index()
            {
                var cart = ShoppingCart.GetCart(this.HttpContext);

                // Set up our ViewModel
                var viewModel = new ShoppingCartViewModel
                {
                    CartItems = cart.GetCartItems(),
                    CartTotal = cart.GetTotal()
                };
                // Return the view
                return View(viewModel);
            }
            //
            // GET: /Store/AddToCart/5
            public ActionResult AddToCart(int id)
            {
                // Retrieve the Tea from the database
                var addedTea = storeDB.Teas
                    .Single(Tea => Tea.TeaId == id);

                // Add it to the shopping cart
                var cart = ShoppingCart.GetCart(this.HttpContext);

                cart.AddToCart(addedTea);

                // Go back to the main store page for more shopping
                return RedirectToAction("Index");
            }
            //
            // AJAX: /ShoppingCart/RemoveFromCart/5
            [HttpPost]
            public ActionResult RemoveFromCart(int id)
            {
                // Remove the item from the cart
                var cart = ShoppingCart.GetCart(this.HttpContext);  
                // Truyền HttpContext thông qua context.Session[CartSessionKey]lấy một giỏ hàngcartId　

                // Get the name of the Tea to display confirmation
                string TeaName = storeDB.Carts
                    .Single(item => item.RecordId == id).Tea.Title;

                // Remove from cart
                int itemCount = cart.RemoveFromCart(id);

                // Display the confirmation message
                var results = new ShoppingCartRemoveViewModel
                {
                    Message = Server.HtmlEncode(TeaName) +
                        "Xóa khỏi giỏ hàng",
                    CartTotal = cart.GetTotal(),
                    CartCount = cart.GetCount(),
                    ItemCount = itemCount,
                    DeleteId = id
                };
                return Json(results);
            }
            //
            // GET: /ShoppingCart/CartSummary
            [ChildActionOnly]
            [AllowAnonymous]
            public ActionResult CartSummary()
            {
                var cart = ShoppingCart.GetCart(this.HttpContext);

                ViewData["CartCount"] = cart.GetCount();
                return PartialView("_CartSummary");
            }

            [HttpPost]
            public ActionResult UpdateCartCount(int id, int cartCount)
            {
                ShoppingCartRemoveViewModel results = null;
                try
                {
                    // Get the cart 
                    var cart = ShoppingCart.GetCart(this.HttpContext);

                    // Get the name of the Tea to display confirmation 
                    string TeaName = storeDB.Carts
                        .Single(item => item.RecordId == id).Tea.Title;

                    // Update the cart count 
                    int itemCount = cart.UpdateCartCount(id, cartCount);

                    //Prepare messages
                    string msg =  Server.HtmlEncode(TeaName) +
                            " Số tiền đã được cập nhật！ ";
                    if (itemCount == 0) msg = Server.HtmlEncode(TeaName) +
                            " Loại bỏ！ ";
                    //
                    // Display the confirmation message 
                    results = new ShoppingCartRemoveViewModel
                    {
                        Message = msg,
                        CartTotal = cart.GetTotal(),
                        CartCount = cart.GetCount(),
                        ItemCount = itemCount,
                        DeleteId = id
                    };
                }
                catch
                {
                    results = new ShoppingCartRemoveViewModel
                    {
                        Message = "Lỗi số lượng",
                        CartTotal = -1,
                        CartCount = -1,
                        ItemCount = -1,
                        DeleteId = id
                    };
                }
                return Json(results);
            }
        }
    }
