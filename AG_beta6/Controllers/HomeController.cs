using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AG_beta6.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
             return View();
            /*if (User.Identity.IsAuthenticated)
            {
               
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }*/
            
        }

        [AllowAnonymous]
        public ActionResult Dashboard()
        {
            return View();
            /*if (User.Identity.IsAuthenticated)
            {
               
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }*/

        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

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