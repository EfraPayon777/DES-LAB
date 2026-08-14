using CC230396_Desafio01.BL.Interfaces;
using CC230396_Desafio01.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; 

namespace CC230396_Desafio01.API.Controllers
{
    public class LibroWebController(ILibroService libroService, IAutorService autorService, ICategoriaService categoriaService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var libros = await libroService.GetAllLibrosAsync();
            return View(libros);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            
            ViewBag.Autores = new SelectList(await autorService.GetAllAutoresAsync(), "Codigo", "Nombre");
            ViewBag.Categorias = new SelectList(await categoriaService.GetAllCategoriasAsync(), "Codigo", "Nombre");

            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(LibroDto libroIngresado)
        {
            if (ModelState.IsValid)
            {

                var resultado = await libroService.InsertLibroAsync(libroIngresado);
                if (resultado > 0)
                {
                    return RedirectToAction("Index"); 
                }
            }


            ViewBag.Autores = new SelectList(await autorService.GetAllAutoresAsync(), "Codigo", "Nombre", libroIngresado.AutorId);
            ViewBag.Categorias = new SelectList(await categoriaService.GetAllCategoriasAsync(), "Codigo", "Nombre", libroIngresado.CategoriaId);

            return View(libroIngresado); 
        }
    }
}