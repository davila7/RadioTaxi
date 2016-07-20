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
    public class TarifasController : Controller
    {
        private DBControlTaxi db = new DBControlTaxi();

        // GET: Tarifas
        public async Task<ActionResult> Index(string message)
        {
            ViewBag.Message = message;
            return View(await db.Tarifa.ToListAsync());
        }

        // GET: Tarifas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarifa tarifa = await db.Tarifa.FindAsync(id);
            if (tarifa == null)
            {
                return HttpNotFound();
            }
            return View(tarifa);
        }

        // GET: Tarifas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tarifas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_Tarifa,Desc_Tarifa,Valor_bndra,Valor_mts")] Tarifa tarifa)
        {
            if (ModelState.IsValid)
            {
                db.Tarifa.Add(tarifa);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { message = "success" });
            }

            return View(tarifa);
        }

        // GET: Tarifas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarifa tarifa = await db.Tarifa.FindAsync(id);
            if (tarifa == null)
            {
                return HttpNotFound();
            }
            return View(tarifa);
        }

        // POST: Tarifas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_Tarifa,Desc_Tarifa,Valor_bndra,Valor_mts")] Tarifa tarifa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarifa).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { message = "success" });
            }
            return View(tarifa);
        }

        // GET: Tarifas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarifa tarifa = await db.Tarifa.FindAsync(id);
            if (tarifa == null)
            {
                return HttpNotFound();
            }
            return View(tarifa);
        }

        // POST: Tarifas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tarifa tarifa = await db.Tarifa.FindAsync(id);
            db.Tarifa.Remove(tarifa);
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
