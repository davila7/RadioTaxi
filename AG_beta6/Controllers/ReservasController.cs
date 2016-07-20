using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer6;

namespace AG_beta6.Controllers
{
    [Authorize]
    public class ReservasController : Controller
    {
        private DBControlTaxi db = new DBControlTaxi();

        // GET: Reservas
        public async Task<ActionResult> Index(string message)
        {
            ViewBag.Message = message;
            var reserva = db.Reserva.Include(r => r.Cliente).Include(r => r.Conductor);
            return View(await reserva.ToListAsync() );
        }

        // GET: Reservas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = await db.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // GET: Reservas/Create
        public ActionResult Create()
        {
            ViewBag.Cliente_Id = new SelectList(db.Cliente, "Id_Clie", "Nombre");
            ViewBag.RutConductor = new SelectList(db.Conductor, "Rut", "Nombre");
            ViewBag.PatenteVehiculo = new SelectList(db.Vehiculo, "Patente", "Patente");
            return View();
        }

        // POST: Reservas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_Reserva,Cliente_Id,RutConductor,PatenteVehiculo,Fecha_trx,Fecha_viaje,Dir_origen,Dir_destino,Pendiente")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Reserva.Add(reserva);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { message = "success" });
            }

            ViewBag.Cliente_Id = new SelectList(db.Cliente, "Id_Clie", "Nombre", reserva.Cliente_Id);
            ViewBag.RutConductor = new SelectList(db.Conductor, "Rut", "Nombre", reserva.RutConductor);
            ViewBag.PatenteVehiculo = new SelectList(db.Vehiculo, "Patente", "Patente", reserva.PatenteVehiculo);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = await db.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente_Id = new SelectList(db.Cliente, "Id_Clie", "Nombre", reserva.Cliente_Id);
            ViewBag.RutConductor = new SelectList(db.Conductor, "Rut", "Nombre", reserva.RutConductor);
            ViewBag.PatenteVehiculo = new SelectList(db.Vehiculo, "Patente", "Patente", reserva.PatenteVehiculo);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_Reserva,Cliente_Id,RutConductor,PatenteVehiculo,Fecha_trx,Fecha_viaje,Dir_origen,Dir_destino,Pendiente")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { message = "success" });
            }
            ViewBag.Cliente_Id = new SelectList(db.Cliente, "Id_Clie", "Nombre", reserva.Cliente_Id);
            ViewBag.RutConductor = new SelectList(db.Conductor, "Rut", "Nombre", reserva.RutConductor);
            ViewBag.PatenteVehiculo = new SelectList(db.Vehiculo, "Patente", "Patente", reserva.PatenteVehiculo);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = await db.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Reserva reserva = await db.Reserva.FindAsync(id);
            db.Reserva.Remove(reserva);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
