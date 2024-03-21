using E_Commerce.Data;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TaikiniImpexContext db;


        public HomeController(ILogger<HomeController> logger, TaikiniImpexContext db)
        {
            _logger = logger;
            this.db = db;
        }

       


        public IActionResult Index()
        {
            //string va= HttpContext.Session.GetString("Email");
            //if (!string.IsNullOrEmpty(va))
            //{
            //    return View();
            //}
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Register user)

        {
            
            var obj = db.Registers.Where(data => data.Email == user.Email && data.PasswordHash == user.PasswordHash).SingleOrDefault();
            if (obj != null)
            {
                //HttpContext.Session.SetString("Email",obj.ToString());

               
                return RedirectToAction("Index");

            }
            @ViewBag["Error"] = "Invalid";
            return View();
        }


        [HttpGet]
        public async Task <IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public /*IActionResult Register(CustomerRegister user)*/

             async Task<IActionResult> Register(Register user)
        {
             db.Registers.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public async Task <IActionResult> order_Tracking()
        {
            string mu = HttpContext.Session.GetString("Email");
            if (!string.IsNullOrEmpty(mu))
            {
                return View();
            }
            return RedirectToAction("Register");
        }
        [HttpPost]
        public async Task<IActionResult> order_Tracking(Order user
            )
        {
            var obj = await order_Tracking();
            var ob = db.Orders.Where(data => data.OrderId == user.OrderId).SingleOrDefault();
            if (obj != null)
            {
                int intValue = 25;
                string stringValue = intValue.ToString();
                HttpContext.Session.SetString("myIntValue", stringValue);

                return RedirectToAction("Register");

            }
            @ViewData["Error"] = "Invalid";
            return View();

        }
        public IActionResult My_Account()
        {
            return View();
        }
        public IActionResult Shop()
        {
            return View();
        }
        public IActionResult Wish_List()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Compare()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Product_Detalis()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Blog_Detalis()
        {
            return View();
        }
        public IActionResult About_Us()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}