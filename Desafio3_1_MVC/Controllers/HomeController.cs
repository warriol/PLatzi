using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Desafio3_1_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Curso de C# Gratis. Platzi. Página de prueba, como ejercicio Desafío Nº 3.2, crear una aplicación MVC basada en el ejercicio Desafío Nº 3.1 (Aplicación API REST).";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "warriol@gmail.com";

            return View();
        }
    }
}