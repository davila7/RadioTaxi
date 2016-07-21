using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer6;
using System.Web.Mvc;
using System.Collections;

namespace AG_beta6.Controllers
{
    public class ViajesConductorModel
    {
        public IEnumerable<IDictionary> DataViajes { get; set; }
    }
    [Authorize]
    public class HomeController : Controller
    {
        private DBControlTaxi db = new DBControlTaxi();
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
            Dictionary<string, int> resultConductor = db.Viaje.GroupBy(z => z.Conductor).ToDictionary(x => x.Key.Nombre, x => x.Key.Viaje.Count);
            Dictionary<string, int> resultReservas = db.Reserva.GroupBy(z => z.Cliente).ToDictionary(x => x.Key.Nombre + "(" + x.Key.Empresa.Nombre +")" , x => x.Key.Reserva.Count);

            ViewBag.resultConductor = resultConductor;
            ViewBag.resultReservas = resultReservas;
            return View();
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