using Microsoft.AspNetCore.Mvc;
using PizzaOrderApp.Models;

namespace PizzaOrderApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Age >= 16)
                {
                    ViewBag.UserId = user.Id; 
                    return RedirectToAction("SelectProducts");
                }
                else
                {
                    ViewBag.ErrorMessage = "You must be 16 or older to order.";
                    return View(user);
                }
            }
            return View(user);
        }

        public IActionResult SelectProducts()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SelectProducts(int productCount)
        {
            ViewBag.ProductCount = productCount;
            return View("OrderForm");
        }

        public IActionResult OrderForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OrderForm(Product[] products)
        {
            if (ModelState.IsValid)
            {
                return View("OrderSummary", products);
            }
            return View();
        }

        public IActionResult OrderSummary()
        {
            return View();
        }
    }
}
