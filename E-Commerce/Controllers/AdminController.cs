using E_Commerce.Data;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Diagnostics;

namespace E_Commerce.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TaikiniImpexContext db;


        public AdminController(ILogger<HomeController> logger, TaikiniImpexContext db)
        {
            _logger = logger;
            this.db = db;
        }


        [HttpGet]
        public async Task <IActionResult> Fetech()
        {
            var obj = await Fetech();

            string mu = HttpContext.Session.GetString("Email");
            if (!string.IsNullOrEmpty(mu))
            {
                return View(db.Products.ToList());

            }


            return RedirectToAction("Login");

        }




        public IActionResult DashBoard()
        {
            return View();
        }


        public IActionResult Review()
        {
            return View();
        }

        public IActionResult Shipping()
        {
            return View();
        }

        public IActionResult OrderItem()
        {
            return View();
        }
        public IActionResult Payment
            ()
        {
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


                return RedirectToAction("Shpping");

            }
            //@ViewBag["Error"] = "Invalid";
            return View();
        }


        //[HttpGet]
        //public IActionResult Register()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Register(CustomerRegister user)
        //{
        //    db.CustomerRegisters.Add(user);
        //    db.SaveChanges();
        //    return RedirectToAction("Login");
        //}
        //[HttpGet]
        //public IActionResult order_Tracking()
        //{
        //    string mu = HttpContext.Session.GetString("Email");
        //    if (!string.IsNullOrEmpty(mu))
        //    {
        //        return View();
        //    }
        //    return RedirectToAction("Register");
        //}
        //[HttpPost]
        //public IActionResult order_Tracking(Order user)
        //{
        //    var obj = db.Orders.Where(data => data.OrderId == user.OrderId).SingleOrDefault();
        //    if (obj != null)
        //    {
        //        int intValue = 25;
        //        string stringValue = intValue.ToString();
        //        HttpContext.Session.SetString("myIntValue", stringValue);

        //        return RedirectToAction("Register");

        //    }
        //    @ViewData["Error"] = "Invalid";
        //    return View();

        //}

        [HttpGet]
        public async Task <IActionResult> Add_Category()
        {

            return View();
        }




        [HttpPost]
        public async Task <IActionResult> Add_Category(Category abc)
        {
            db.Categories.Add(abc);
            db.SaveChanges();
            return View();
        }








        [HttpGet]
        public async Task <IActionResult> Add_Pro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add_Pro(Product abc, IFormFile img)
        {
            var arr = new[] { "png", "jpg", "jpeg" };
            if (img != null && img.Length > 0)
            {
                var fe = System.IO.Path.GetExtension(img.FileName).Substring(1);
                if (!arr.Contains(fe))
                {
                    ViewBag.e = "Image File Only";
                    return View();
                }
                var rn = Path.GetFileName(img.FileName);
                var fn = Guid.NewGuid() + rn;
                string imgfolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/Images");
                if (!Directory.Exists(imgfolder))
                {
                    Directory.CreateDirectory(imgfolder);
                }
                string filepath = Path.Combine(imgfolder, fn);
                using (var s = new FileStream(filepath, FileMode.Create))
                {
                    img.CopyTo(s);
                }
                var dbadd = Path.Combine("Images", fn);
                //abc.ProductImage = dbadd;
                db.Products.Add(abc);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit_Img(int? ProductId)
        {
            Product user = db.Products.Find(ProductId);
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit_Img(Product user, IFormFile img)
        {
            if (img != null && img.Length > 0)
            {
                var fn = Path.GetFileName(img.FileName);
                string imgfolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/Images");
                if (!Directory.Exists(imgfolder))
                {
                    Directory.CreateDirectory(imgfolder);
                }
                string filepath = Path.Combine(imgfolder, fn);
                using (var s = new FileStream(filepath, FileMode.Create))
                {
                    img.CopyTo(s);
                }
                var dbadd = Path.Combine("Images", fn);
                //user.ProductImage = dbadd;
                db.Products.Update(user);
                db.SaveChanges();
                return RedirectToAction("Product_Detalis");

            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete_Img(int? ProductId)
        {
            Product user = db.Products.Find(ProductId);
            db.Products.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Product_Detalis");
        }
        [HttpGet]
        public IActionResult EditUser(int? ProductId)
        {
            Product user = db.Products.Find(ProductId);

            return View(user);
        }
        [HttpPost]
        public IActionResult EditUser(Product user)
        {

            db.Products.Update(user);
            db.SaveChanges();
            return RedirectToAction("AllUsers");



        }

        //[HttpGet]
        //public IActionResult Add_Category()
        //{

        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Add_Category(Category abc)
        //{
        //    db.Categories.Add(abc);
        //    db.SaveChanges();
        //    return View();
        //}
        //[HttpGet]
        //public IActionResult Fetech()
        //{
        //    string mu = HttpContext.Session.GetString("Email");
        //    if (!string.IsNullOrEmpty(mu))
        //    {
        //        return View(db.Products.ToList());

        //    }


        //    return RedirectToAction("Login");

        //}


        //public IActionResult My_Account()
        //{
        //    return View();
        //}
        //public IActionResult Shop()
        //{
        //    return View();
        //}
        //public IActionResult Wish_List()
        //{
        //    return View();
        //}
        //public IActionResult Contact()
        //{
        //    return View();
        //}
        //public IActionResult Compare()
        //{
        //    return View();
        //}
        //public IActionResult Checkout()
        //{
        //    return View();
        //}
        //public IActionResult Cart()
        //{
        //    return View();
        //}
        //public IActionResult Product_Detalis()
        //{
        //    return View();
        //}

        //public IActionResult Blog()
        //{
        //    return View();
        //}
        //public IActionResult Blog_Detalis()
        //{
        //    return View();
        //}
        //public IActionResult About_Us()
        //{
        //    return View();
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}