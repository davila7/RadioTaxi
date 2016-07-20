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
    public class UsuarioController : Controller
    {
        private DBControlTaxi db = new DBControlTaxi();

        // GET: Usuario
        public async Task<ActionResult> Index()
        {
            var usuario = db.Usuario.Where(x => x.Flg_elim == false).Include(u => u.Perfil);
            return View(await usuario.ToListAsync());
        }

        // GET: Usuario Deleted
        public async Task<ActionResult> DeletedIndex()
        {
            var usuario = db.Usuario.Where(x=>x.Flg_elim == true).Include(u => u.Perfil);
            return View(await usuario.ToListAsync());
        }

        // GET: Usuario/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.Id_Pefil = new SelectList(db.Perfil, "Id_Perfil", "Dsc_Perfil");
            return View();
        }

        // POST: Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Rut,Dig,Nombre_usr, Email,Nombre,Ape_pat,Ape_mat,Fono1,Fono2,Flg_hab,Flg_elim,Contrasenha,Id_Pefil,Id_Usua")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Rut = usuario.Rut.Replace(".", "");
                db.Usuario.Add(usuario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Pefil = new SelectList(db.Perfil, "Id_Perfil", "Dsc_Perfil", usuario.Id_Pefil);
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Pefil = new SelectList(db.Perfil, "Id_Perfil", "Dsc_Perfil", usuario.Id_Pefil);
            return View(usuario);
        }

        // GET: Usuario/Restaurar/5
        public async Task<ActionResult> Restaurar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            usuario.Flg_elim = false;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // POST: Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Rut,Dig,Nombre_usr, Email, Nombre,Ape_pat,Ape_mat,Fono1,Fono2,Flg_hab,Flg_elim,Contrasenha,Id_Pefil,Id_Usua")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Rut = usuario.Rut.Replace(".", "");
                db.Entry(usuario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Pefil = new SelectList(db.Perfil, "Id_Perfil", "Dsc_Perfil", usuario.Id_Pefil);
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Usuario usuario = await db.Usuario.FindAsync(id);
            db.Usuario.Remove(usuario);
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
