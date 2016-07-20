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
    public class PerfilController : Controller
    {
        private DBControlTaxi db = new DBControlTaxi();

        // GET: Perfil
        public async Task<ActionResult> Index(string message)
        {
            ViewBag.Message = message;
            return View(await db.Perfil.ToListAsync());
        }

        // GET: Perfil/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = await db.Perfil.FindAsync(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // GET: Perfil/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Perfil/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_Perfil,Dsc_Perfil")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                db.Perfil.Add(perfil);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { message = "success" });
            }

            return View(perfil);
        }

        // GET: Perfil/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = await db.Perfil.FindAsync(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // POST: Perfil/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_Perfil,Dsc_Perfil")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfil).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { message = "success" });
            }
            return View(perfil);
        }

        // GET: Perfil/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = await db.Perfil.FindAsync(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // POST: Perfil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Perfil perfil = await db.Perfil.FindAsync(id);
            db.Perfil.Remove(perfil);
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
