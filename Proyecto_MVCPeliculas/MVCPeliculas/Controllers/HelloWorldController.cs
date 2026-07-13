using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MVCPeliculas.Controllers
{
    public class HelloWorldController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Welcome(string nombre, string apellido, int numVeces = 1)
        {
            ViewData["nombre"] = nombre;
            ViewData["apellido"] = apellido;
            ViewData["numVeces"] = numVeces;
            return View();
        }
        public string Greeting(string nombre, int id = 1)
        {
            return HtmlEncoder.Default.Encode($"Hola {nombre}, ID: {id}");
        }

    }
}
