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
    public class EmpresaController : Controller
    {
        private DBControlTaxi db = new DBControlTaxi();

        // GET: Empresa
        public async Task<ActionResult> Index()
        {
            var empresa = db.Empresa.Include(e => e.Direccion).Include(t => t.Tarifa);
            return View(await empresa.ToListAsync());
        }

        // GET: Empresa/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = await db.Empresa.FindAsync(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // GET: Empresa/Create
        public ActionResult Create()
        {
            ViewBag.IdDireccion = new SelectList(db.Direccion, "Id", "Nombre");
            ViewBag.IdTarifa = new SelectList(db.Tarifa, "Id_Tarifa", "Desc_tarifa");
            return View();
        }

        // POST: Empresa/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_empr,Rut,Dig,Nombre,Telefono,Descuento,FormaDePago,IdDireccion,Tarifa_id")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Empresa.Add(empresa);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdDireccion = new SelectList(db.Direccion, "Id", "Nombre", empresa.IdDireccion);
            ViewBag.IdTarifa = new SelectList(db.Tarifa, "Id_Tarifa", "Desc_tarifa", empresa.Tarifa_id);
            return View(empresa);
        }

        // GET: Empresa/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = await db.Empresa.FindAsync(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDireccion = new SelectList(db.Direccion, "Id", "Nombre", empresa.IdDireccion);
            ViewBag.IdTarifa = new SelectList(db.Tarifa, "Id_Tarifa", "Desc_tarifa", empresa.Tarifa_id);
            return View(empresa);
        }

        // POST: Empresa/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_empr,Rut,Dig,Nombre,Telefono,Descuento,FormaDePago,IdDireccion,Tarifa_id")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empresa).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdDireccion = new SelectList(db.Direccion, "Id", "Nombre", empresa.IdDireccion);
            ViewBag.IdTarifa = new SelectList(db.Tarifa, "Id_Tarifa", "Desc_tarifa", empresa.Tarifa_id);
            return View(empresa);
        }

        // GET: Empresa/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = await db.Empresa.FindAsync(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Empresa empresa = await db.Empresa.FindAsync(id);
            db.Empresa.Remove(empresa);
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
