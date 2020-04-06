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
    public class NOMINAsController : Controller
    {
        private COURRIEREntities8 db = new COURRIEREntities8();

        // GET: NOMINAs
        public ActionResult Index()
        {
            return View(db.NOMINA.ToList());
        }

        // GET: NOMINAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOMINA nOMINA = db.NOMINA.Find(id);
            if (nOMINA == null)
            {
                return HttpNotFound();
            }
            return View(nOMINA);
        }

        // GET: NOMINAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NOMINAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AÑO,MES,MONTO_TOTAL")] NOMINA nOMINA)
        {
            if (ModelState.IsValid)
            {
                db.NOMINA.Add(nOMINA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nOMINA);
        }

        // GET: NOMINAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOMINA nOMINA = db.NOMINA.Find(id);
            if (nOMINA == null)
            {
                return HttpNotFound();
            }
            return View(nOMINA);
        }

        // POST: NOMINAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AÑO,MES,MONTO_TOTAL")] NOMINA nOMINA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nOMINA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nOMINA);
        }

        // GET: NOMINAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOMINA nOMINA = db.NOMINA.Find(id);
            if (nOMINA == null)
            {
                return HttpNotFound();
            }
            return View(nOMINA);
        }

        // POST: NOMINAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NOMINA nOMINA = db.NOMINA.Find(id);
            db.NOMINA.Remove(nOMINA);
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
