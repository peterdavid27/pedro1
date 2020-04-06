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
    public class SALIDAEMPLEADOSController : Controller
    {
        private COURRIEREntities8 db = new COURRIEREntities8();

        // GET: SALIDAEMPLEADOS
        public ActionResult Index()
        {
            var sALIDAEMPLEADOS = db.SALIDAEMPLEADOS.Include(s => s.EMPLEADOS);
            return View(sALIDAEMPLEADOS.ToList());
        }

        // GET: SALIDAEMPLEADOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALIDAEMPLEADOS sALIDAEMPLEADOS = db.SALIDAEMPLEADOS.Find(id);
            if (sALIDAEMPLEADOS == null)
            {
                return HttpNotFound();
            }
            return View(sALIDAEMPLEADOS);
        }

        // GET: SALIDAEMPLEADOS/Create
        public ActionResult Create()
        {
            ViewBag.EMPLEADO = new SelectList(db.EMPLEADOS, "ID", "USERNAME");
            return View();
        }

        // POST: SALIDAEMPLEADOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EMPLEADO,MOTIVO,TIPO_SALIDA,FECHA_SALIDA")] SALIDAEMPLEADOS sALIDAEMPLEADOS)
        {
            if (ModelState.IsValid)
            {
                db.SALIDAEMPLEADOS.Add(sALIDAEMPLEADOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EMPLEADO = new SelectList(db.EMPLEADOS, "ID", "USERNAME", sALIDAEMPLEADOS.EMPLEADO);
            return View(sALIDAEMPLEADOS);
        }

        // GET: SALIDAEMPLEADOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALIDAEMPLEADOS sALIDAEMPLEADOS = db.SALIDAEMPLEADOS.Find(id);
            if (sALIDAEMPLEADOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMPLEADO = new SelectList(db.EMPLEADOS, "ID", "USERNAME", sALIDAEMPLEADOS.EMPLEADO);
            return View(sALIDAEMPLEADOS);
        }

        // POST: SALIDAEMPLEADOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EMPLEADO,MOTIVO,TIPO_SALIDA,FECHA_SALIDA")] SALIDAEMPLEADOS sALIDAEMPLEADOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sALIDAEMPLEADOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EMPLEADO = new SelectList(db.EMPLEADOS, "ID", "USERNAME", sALIDAEMPLEADOS.EMPLEADO);
            return View(sALIDAEMPLEADOS);
        }

        // GET: SALIDAEMPLEADOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALIDAEMPLEADOS sALIDAEMPLEADOS = db.SALIDAEMPLEADOS.Find(id);
            if (sALIDAEMPLEADOS == null)
            {
                return HttpNotFound();
            }
            return View(sALIDAEMPLEADOS);
        }

        // POST: SALIDAEMPLEADOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SALIDAEMPLEADOS sALIDAEMPLEADOS = db.SALIDAEMPLEADOS.Find(id);
            db.SALIDAEMPLEADOS.Remove(sALIDAEMPLEADOS);
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
