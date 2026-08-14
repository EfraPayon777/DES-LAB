using CC230396_Desafio01.BL.Interfaces;
using CC230396_Desafio01.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CC230396_Desafio01.API.Controllers
{
    public class CategoriaWebController(ICategoriaService categoriaService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categorias = await categoriaService.GetAllCategoriasAsync();
            return View(categorias);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoriaDto categoriaIngresada)
        {
            if (ModelState.IsValid)
            {
                var resultado = await categoriaService.InsertCategoriaAsync(categoriaIngresada);
                if (resultado > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(categoriaIngresada);
        }
    }
}