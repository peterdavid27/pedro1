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

namespace WebApplication1.Controllers
{
    public class CLIENTESController : Controller
    {
        private COURRIEREntities8 db = new COURRIEREntities8();

        // GET: CLIENTES
        public ActionResult Index()
        {
            var cLIENTES = db.CLIENTES.Include(c => c.SUCURSAL1);
            return View(cLIENTES.ToList());
        }

        // GET: CLIENTES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTES cLIENTES = db.CLIENTES.Find(id);
            if (cLIENTES == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTES);
        }

        // GET: CLIENTES/Create
        public ActionResult Create()
        {
            ViewBag.SUCURSAL = new SelectList(db.SUCURSAL, "ID_SUCURSAL", "NOMBRE");
            return View();
        }

        // POST: CLIENTES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CLIENTE,NOMBRES,APELLIDOS,CEDULA,GENERO,TELEFONO,SUCURSAL,CORREO,USUARIO,CLAVE")] CLIENTES cLIENTES)
        {
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                db.CLIENTES.Add(cLIENTES);
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("clienteaduservice@gmail.com");
                Session["email"] = cLIENTES.CORREO.ToString();
                var e = Session["email"].ToString();
                msg.To.Add(e);
                msg.Subject = "Bienvenido a la familia de ADUservice";
                msg.Body = "Aduservice";
                MailAddress ms = new MailAddress(e);
                msg.CC.Add(ms);
                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                sc.Port = 587;
                sc.Credentials = new NetworkCredential("clienteaduservice@gmail.com", "aduservice123");
                sc.EnableSsl = true;
                sc.Send(msg);
                db.SaveChanges();
                db.CLIENTES.Add(cLIENTES);
               

                return RedirectToAction("Index");
               
            }

            ViewBag.SUCURSAL = new SelectList(db.SUCURSAL, "ID_SUCURSAL", "NOMBRE", cLIENTES.SUCURSAL);
            return View(cLIENTES);
        }

        // GET: CLIENTES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTES cLIENTES = db.CLIENTES.Find(id);
            if (cLIENTES == null)
            {
                return HttpNotFound();
            }
            ViewBag.SUCURSAL = new SelectList(db.SUCURSAL, "ID_SUCURSAL", "NOMBRE", cLIENTES.SUCURSAL);
            return View(cLIENTES);
        }

        // POST: CLIENTES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CLIENTE,NOMBRES,APELLIDOS,CEDULA,GENERO,TELEFONO,SUCURSAL,CORREO,USUARIO,CLAVE")] CLIENTES cLIENTES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLIENTES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SUCURSAL = new SelectList(db.SUCURSAL, "ID_SUCURSAL", "NOMBRE", cLIENTES.SUCURSAL);
            return View(cLIENTES);
        }

        // GET: CLIENTES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTES cLIENTES = db.CLIENTES.Find(id);
            if (cLIENTES == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTES);
        }

        // POST: CLIENTES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLIENTES cLIENTES = db.CLIENTES.Find(id);
            db.CLIENTES.Remove(cLIENTES);
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
