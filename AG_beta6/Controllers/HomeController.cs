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
            Dictionary<string, int> resultConductor = db.Viaje.Where(r => r.FechaInicio.Day == DateTime.Now.Day && r.FechaInicio.Month == DateTime.Now.Month && r.FechaInicio.Year == DateTime.Now.Year).GroupBy(z => z.Conductor).ToDictionary(x => x.Key.Nombre, x => x.Key.Viaje.Count);
            Dictionary<string, int> resultReservas = db.Reserva.Where(r => r.Fecha_viaje.Value.Day == DateTime.Now.Day && r.Fecha_viaje.Value.Month == DateTime.Now.Month && r.Fecha_viaje.Value.Year == DateTime.Now.Year).GroupBy(z => z.Cliente).ToDictionary(x => x.Key.Nombre + "(" + x.Key.Empresa.Nombre + ")", x => x.Key.Reserva.Count);
            Dictionary<string, int> resultReservasPendientes = db.Reserva.Where(r => r.Pendiente == 1).GroupBy(z => z.Cliente).ToDictionary(x => x.Key.Nombre + "(" + x.Key.Empresa.Nombre + ")", x => x.Key.Reserva.Count);
            Dictionary<string, int> resultViajes = db.Viaje.Where(v => v.FechaInicio.Month == DateTime.Now.Month && v.IdEstado == 3).GroupBy(z => z.Cliente.Empresa).ToDictionary(x => x.Key.Nombre, x => x.Key.Cliente.First().Viaje.Count);
            Dictionary<string, int> resultViajesDia = db.Viaje.Where(r => r.FechaInicio.Day == DateTime.Now.Day && r.FechaInicio.Month == DateTime.Now.Month && r.FechaInicio.Year == DateTime.Now.Year && r.IdEstado == 2).GroupBy(z => z.Cliente).ToDictionary(x => x.Key.Nombre + "(" + x.Key.Empresa.Nombre + ")", x => x.Key.Reserva.Count);
            ViewBag.resultConductor = resultConductor;
            ViewBag.resultReservas = resultReservas;
            ViewBag.resultViajes = resultViajes;
            ViewBag.resultViajesDia = resultViajesDia;
            ViewBag.resultReservasPendientes = resultReservasPendientes;
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