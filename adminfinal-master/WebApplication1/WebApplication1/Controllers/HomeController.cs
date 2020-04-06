using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexCliente()
        {
            return View();
        }
            public ActionResult IndexAdmin()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        public ActionResult LoginAdmin()
        {

            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "data source=DESKTOP-FVTS8NC; database=COURRIER; integrated security = SSPI";

            
        }
        
        [HttpPost]
        public ActionResult verify(Account acc1, Account acc2)
        {
            
         
        connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT USUARIO,CLAVE FROM CLIENTES  WHERE USUARIO='" + acc1.USUARIO + "' AND CLAVE='" + acc2.CLAVE + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {



                Session["valor"] =acc1.USUARIO;

                con.Close();
                return View("IndexCliente");
                
            }
            else
            {

                return View("Error");
            }

            

        }
        public ActionResult verifyadmin(Account aca1, Account aca2)
        {


            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT USERNAME,CLAVE FROM ADMINISTRADOR  WHERE USERNAME='" + aca1.USUARIO + "' AND CLAVE='" + aca2.CLAVE + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {



                Session["val"] = aca1.USUARIO;

                con.Close();
                return View("IndexAdmin");

            }
            else
            {

                return View("Error");
            }



        }




    }
}