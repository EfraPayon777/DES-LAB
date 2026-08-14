using CC230396_Desafio01.BL.Interfaces;
using CC230396_Desafio01.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CC230396_Desafio01.API.Controllers
{
    public class AutorWebController(IAutorService autorService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var autores = await autorService.GetAllAutoresAsync();
            return View(autores);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AutorDto autorIngresado)
        {
            if (ModelState.IsValid)
            {
                var resultado = await autorService.InsertAutorAsync(autorIngresado);
                if (resultado > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(autorIngresado);
        }
    }
}