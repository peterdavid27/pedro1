using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Controllers;

namespace WebApplication1.Controllers
{
    public class RECEPCIONController : Controller
    {
        private COURRIEREntities8 db = new COURRIEREntities8();

        // GET: RECEPCION
        public ActionResult Index()
        {
            var rECEPCION2 = db.RECEPCION.Include(r =>r.SUCURSAL).Include(r=>r.CLIENTES);
            return View(rECEPCION2.ToList());



            string v = Session["valor"].ToString();


            var rECEPCION = db.RECEPCION.Where(r => r.CLIENTES.USUARIO==v);
            return View(rECEPCION.ToList());
        }

        // GET: RECEPCION/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEPCION rECEPCION = db.RECEPCION.Find(id);
            if (rECEPCION == null)
            {
                return HttpNotFound();
            }
            return View(rECEPCION);
        }

        // GET: RECEPCION/Create
        public ActionResult Create()
        {
            ViewBag.CLIENTE = new SelectList(db.CLIENTES, "ID_CLIENTE", "NOMBRES");
            ViewBag.DESTINO = new SelectList(db.SUCURSAL, "ID_SUCURSAL", "NOMBRE");
            return View();
        }

        // POST: RECEPCION/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRODUCTO,CLIENTE,PRODUCTO,ESTADO,FECHA_REGISTRO,ORIGEN,DESTINO,PESO,PRECIO")] RECEPCION rECEPCION)
        {
            if (ModelState.IsValid)

            {

           
                db.RECEPCION.Add(rECEPCION);
                db.SaveChanges();
                return RedirectToAction("Index");

              
            }

            ViewBag.CLIENTE = new SelectList(db.CLIENTES, "ID_CLIENTE", "NOMBRES", rECEPCION.CLIENTE);
            ViewBag.DESTINO = new SelectList(db.SUCURSAL, "ID_SUCURSAL", "NOMBRE", rECEPCION.DESTINO);
            return View(rECEPCION);
        }

        // GET: RECEPCION/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEPCION rECEPCION = db.RECEPCION.Find(id);
            if (rECEPCION == null)
            {
                return HttpNotFound();
            }
            ViewBag.CLIENTE = new SelectList(db.CLIENTES, "ID_CLIENTE", "NOMBRES", rECEPCION.CLIENTE);
            ViewBag.DESTINO = new SelectList(db.SUCURSAL, "ID_SUCURSAL", "NOMBRE", rECEPCION.DESTINO);
            return View(rECEPCION);
        }

        // POST: RECEPCION/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRODUCTO,CLIENTE,PRODUCTO,ESTADO,FECHA_REGISTRO,ORIGEN,DESTINO,PESO,PRECIO")] RECEPCION rECEPCION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rECEPCION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CLIENTE = new SelectList(db.CLIENTES, "ID_CLIENTE", "NOMBRES", rECEPCION.CLIENTE);
            ViewBag.DESTINO = new SelectList(db.SUCURSAL, "ID_SUCURSAL", "NOMBRE", rECEPCION.DESTINO);
            return View(rECEPCION);
        }

        // GET: RECEPCION/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEPCION rECEPCION = db.RECEPCION.Find(id);
            if (rECEPCION == null)
            {
                return HttpNotFound();
            }
            return View(rECEPCION);
        }

        // POST: RECEPCION/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RECEPCION rECEPCION = db.RECEPCION.Find(id);
            db.RECEPCION.Remove(rECEPCION);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public ActionResult busquedafilter(String producto_nombre)
        {
            
            Account user = new Models.Account();
            string v = Session["valor"].ToString();

            var busqueda = db.RECEPCION.Where(r => r.CLIENTES.USUARIO == v);
            if (!String.IsNullOrEmpty(producto_nombre))
            {
                busqueda = busqueda.Where(r => r.PRODUCTO.Contains(producto_nombre));
            }
            return View(busqueda.ToList());

        }


          
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
      
        
        }
        public ActionResult calucladora()
        {
         


            return View();
        }



    }


   
}
