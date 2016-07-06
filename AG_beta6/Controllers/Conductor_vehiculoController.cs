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
    public class Conductor_vehiculoController : Controller
    {
        private DBControlTaxi db = new DBControlTaxi();

        // GET: Conductor_vehiculo
        public async Task<ActionResult> Index()
        {
            var conductor_vehiculo = db.Conductor_vehiculo.Include(c => c.Conductor).Include(c => c.Vehiculo);
            return View(await conductor_vehiculo.ToListAsync());
        }

        // GET: Conductor_vehiculo/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conductor_vehiculo conductor_vehiculo = await db.Conductor_vehiculo.FindAsync(id);
            if (conductor_vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(conductor_vehiculo);
        }

        // GET: Conductor_vehiculo/Create
        public ActionResult Create()
        {
            ViewBag.RutConductor = new SelectList(db.Conductor, "Rut", "Dig");
            ViewBag.PatenteVehiculo = new SelectList(db.Vehiculo, "Patente", "Dig");
            return View();
        }

        // POST: Conductor_vehiculo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RutConductor,PatenteVehiculo,Id_cond_vehi")] Conductor_vehiculo conductor_vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Conductor_vehiculo.Add(conductor_vehiculo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RutConductor = new SelectList(db.Conductor, "Rut", "Dig", conductor_vehiculo.RutConductor);
            ViewBag.PatenteVehiculo = new SelectList(db.Vehiculo, "Patente", "Dig", conductor_vehiculo.PatenteVehiculo);
            return View(conductor_vehiculo);
        }

        // GET: Conductor_vehiculo/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conductor_vehiculo conductor_vehiculo = await db.Conductor_vehiculo.FindAsync(id);
            if (conductor_vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.RutConductor = new SelectList(db.Conductor, "Rut", "Dig", conductor_vehiculo.RutConductor);
            ViewBag.PatenteVehiculo = new SelectList(db.Vehiculo, "Patente", "Dig", conductor_vehiculo.PatenteVehiculo);
            return View(conductor_vehiculo);
        }

        // POST: Conductor_vehiculo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RutConductor,PatenteVehiculo,Id_cond_vehi")] Conductor_vehiculo conductor_vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conductor_vehiculo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RutConductor = new SelectList(db.Conductor, "Rut", "Dig", conductor_vehiculo.RutConductor);
            ViewBag.PatenteVehiculo = new SelectList(db.Vehiculo, "Patente", "Dig", conductor_vehiculo.PatenteVehiculo);
            return View(conductor_vehiculo);
        }

        // GET: Conductor_vehiculo/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conductor_vehiculo conductor_vehiculo = await db.Conductor_vehiculo.FindAsync(id);
            if (conductor_vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(conductor_vehiculo);
        }

        // POST: Conductor_vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Conductor_vehiculo conductor_vehiculo = await db.Conductor_vehiculo.FindAsync(id);
            db.Conductor_vehiculo.Remove(conductor_vehiculo);
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
