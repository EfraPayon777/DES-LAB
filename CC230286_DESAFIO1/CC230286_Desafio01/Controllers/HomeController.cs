using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CC230396_Desafio01.API.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View(); 
        }
    }
}