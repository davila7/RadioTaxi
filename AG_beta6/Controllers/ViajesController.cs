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
    public class ViajesController : Controller
    {
        private DBControlTaxi db = new DBControlTaxi();

        // GET: Viajes
        public async Task<ActionResult> Index()
        {
            var viaje = db.Viaje.Include(v => v.Cliente).Include(v => v.Conductor).Include(v => v.estado);
            return View(await viaje.ToListAsync());
        }

        // GET: Viajes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viaje viaje = await db.Viaje.FindAsync(id);
            if (viaje == null)
            {
                return HttpNotFound();
            }
            return View(viaje);
        }

        // GET: Viajes/Create
        public ActionResult Create()
        {
            ViewBag.IdPasajero = new SelectList(db.Cliente, "Id_Clie", "Rut");
            ViewBag.RutConductor = new SelectList(db.Conductor, "Rut", "Dig");
            ViewBag.IdEstado = new SelectList(db.estado, "Id_Estado", "Nombre");
            return View();
        }

        // POST: Viajes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_viaje,Origen,Destino,Km,Valor,HoraInicio,HoraTermino,IdPasajero,RutConductor,IdEstado,Latitud_des,Longitud_des,Latitud_ori,Longitud_ori")] Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                db.Viaje.Add(viaje);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdPasajero = new SelectList(db.Cliente, "Id_Clie", "Rut", viaje.IdPasajero);
            ViewBag.RutConductor = new SelectList(db.Conductor, "Rut", "Dig", viaje.RutConductor);
            ViewBag.IdEstado = new SelectList(db.estado, "Id_Estado", "Nombre", viaje.IdEstado);
            return View(viaje);
        }

        // GET: Viajes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viaje viaje = await db.Viaje.FindAsync(id);
            if (viaje == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPasajero = new SelectList(db.Cliente, "Id_Clie", "Rut", viaje.IdPasajero);
            ViewBag.RutConductor = new SelectList(db.Conductor, "Rut", "Dig", viaje.RutConductor);
            ViewBag.IdEstado = new SelectList(db.estado, "Id_Estado", "Nombre", viaje.IdEstado);
            return View(viaje);
        }

        // POST: Viajes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_viaje,Origen,Destino,Km,Valor,HoraInicio,HoraTermino,IdPasajero,RutConductor,IdEstado,Latitud_des,Longitud_des,Latitud_ori,Longitud_ori")] Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viaje).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdPasajero = new SelectList(db.Cliente, "Id_Clie", "Rut", viaje.IdPasajero);
            ViewBag.RutConductor = new SelectList(db.Conductor, "Rut", "Dig", viaje.RutConductor);
            ViewBag.IdEstado = new SelectList(db.estado, "Id_Estado", "Nombre", viaje.IdEstado);
            return View(viaje);
        }

        // GET: Viajes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viaje viaje = await db.Viaje.FindAsync(id);
            if (viaje == null)
            {
                return HttpNotFound();
            }
            return View(viaje);
        }

        // POST: Viajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Viaje viaje = await db.Viaje.FindAsync(id);
            db.Viaje.Remove(viaje);
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
