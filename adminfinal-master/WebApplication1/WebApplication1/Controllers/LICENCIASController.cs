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
    public class LICENCIASController : Controller
    {
        private COURRIEREntities8 db = new COURRIEREntities8();

        // GET: LICENCIAS
        public ActionResult Index()
        {
            var lICENCIAS = db.LICENCIAS.Include(l => l.EMPLEADOS);
            return View(lICENCIAS.ToList());
        }

        // GET: LICENCIAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LICENCIAS lICENCIAS = db.LICENCIAS.Find(id);
            if (lICENCIAS == null)
            {
                return HttpNotFound();
            }
            return View(lICENCIAS);
        }

        // GET: LICENCIAS/Create
        public ActionResult Create()
        {
            ViewBag.EMPLEADO = new SelectList(db.EMPLEADOS, "ID", "USERNAME");
            return View();
        }

        // POST: LICENCIAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EMPLEADO,DESDE,HASTA,COMENTARIO")] LICENCIAS lICENCIAS)
        {
            if (ModelState.IsValid)
            {
                db.LICENCIAS.Add(lICENCIAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EMPLEADO = new SelectList(db.EMPLEADOS, "ID", "USERNAME", lICENCIAS.EMPLEADO);
            return View(lICENCIAS);
        }

        // GET: LICENCIAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LICENCIAS lICENCIAS = db.LICENCIAS.Find(id);
            if (lICENCIAS == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMPLEADO = new SelectList(db.EMPLEADOS, "ID", "USERNAME", lICENCIAS.EMPLEADO);
            return View(lICENCIAS);
        }

        // POST: LICENCIAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EMPLEADO,DESDE,HASTA,COMENTARIO")] LICENCIAS lICENCIAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lICENCIAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EMPLEADO = new SelectList(db.EMPLEADOS, "ID", "USERNAME", lICENCIAS.EMPLEADO);
            return View(lICENCIAS);
        }

        // GET: LICENCIAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LICENCIAS lICENCIAS = db.LICENCIAS.Find(id);
            if (lICENCIAS == null)
            {
                return HttpNotFound();
            }
            return View(lICENCIAS);
        }

        // POST: LICENCIAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LICENCIAS lICENCIAS = db.LICENCIAS.Find(id);
            db.LICENCIAS.Remove(lICENCIAS);
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
