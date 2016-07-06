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
    public class ConductorController : Controller
    {
        private DBControlTaxi db = new DBControlTaxi();

        // GET: Conductor
        public async Task<ActionResult> Index()
        {
            return View(await db.Conductor.ToListAsync());
        }

        // GET: Conductor/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conductor conductor = await db.Conductor.FindAsync(id);
            if (conductor == null)
            {
                return HttpNotFound();
            }
            return View(conductor);
        }

        // GET: Conductor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conductor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Rut,Dig,Nombre,Apellidos,Telefono,Comision,Habilitado,Movil,Id_Cond")] Conductor conductor)
        {
            if (ModelState.IsValid)
            {
                db.Conductor.Add(conductor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(conductor);
        }

        // GET: Conductor/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conductor conductor = await db.Conductor.FindAsync(id);
            if (conductor == null)
            {
                return HttpNotFound();
            }
            return View(conductor);
        }

        // POST: Conductor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Rut,Dig,Nombre,Apellidos,Telefono,Comision,Habilitado,Movil,Id_Cond")] Conductor conductor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conductor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(conductor);
        }

        // GET: Conductor/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conductor conductor = await db.Conductor.FindAsync(id);
            if (conductor == null)
            {
                return HttpNotFound();
            }
            return View(conductor);
        }

        // POST: Conductor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Conductor conductor = await db.Conductor.FindAsync(id);
            db.Conductor.Remove(conductor);
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
