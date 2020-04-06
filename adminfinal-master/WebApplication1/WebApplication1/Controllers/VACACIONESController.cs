using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class VACACIONESController : Controller
    {
        private COURRIEREntities8 db = new COURRIEREntities8();

        // GET: VACACIONES
        public ActionResult Index()
        {
            var vACACIONES = db.VACACIONES.Include(v => v.EMPLEADOS);
            return View(vACACIONES.ToList());
        }

        // GET: VACACIONES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VACACIONES vACACIONES = db.VACACIONES.Find(id);
            if (vACACIONES == null)
            {
                return HttpNotFound();
            }
            return View(vACACIONES);
        }

        // GET: VACACIONES/Create
        public ActionResult Create()
        {
            ViewBag.EMPLEADO = new SelectList(db.EMPLEADOS, "ID", "USERNAME");
            return View();
        }

        // POST: VACACIONES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EMPLEADO,DESDE,HASTA,AÑO_CORRESPONDIENTE,COMENTARIO")] VACACIONES vACACIONES)
        {
            if (ModelState.IsValid)
            {
                db.VACACIONES.Add(vACACIONES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EMPLEADO = new SelectList(db.EMPLEADOS, "ID", "USERNAME", vACACIONES.EMPLEADO);
            return View(vACACIONES);
        }

        // GET: VACACIONES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VACACIONES vACACIONES = db.VACACIONES.Find(id);
            if (vACACIONES == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMPLEADO = new SelectList(db.EMPLEADOS, "ID", "USERNAME", vACACIONES.EMPLEADO);
            return View(vACACIONES);
        }

        // POST: VACACIONES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EMPLEADO,DESDE,HASTA,AÑO_CORRESPONDIENTE,COMENTARIO")] VACACIONES vACACIONES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vACACIONES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EMPLEADO = new SelectList(db.EMPLEADOS, "ID", "USERNAME", vACACIONES.EMPLEADO);
            return View(vACACIONES);
        }

        // GET: VACACIONES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VACACIONES vACACIONES = db.VACACIONES.Find(id);
            if (vACACIONES == null)
            {
                return HttpNotFound();
            }
            return View(vACACIONES);
        }

        // POST: VACACIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VACACIONES vACACIONES = db.VACACIONES.Find(id);
            db.VACACIONES.Remove(vACACIONES);
            db.SaveChanges();
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
