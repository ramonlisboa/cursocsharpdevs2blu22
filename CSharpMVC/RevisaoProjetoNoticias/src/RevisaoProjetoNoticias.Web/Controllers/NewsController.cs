using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RevisaoProjetoNoticias.Domain.DTO;
using RevisaoProjetoNoticias.Domain.IServices;
using RevisaoProjetoNoticias.Web.Models;
using System.Diagnostics;

namespace RevisaoProjetoNoticias.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _service;

        public NewsController(INewsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            // To List all categories
            // Get of CategoryRepository through Dependecy Injection (CategoryService)
            return View(_service.FindAll());
        }

        public JsonResult ListJson()
        {
            return Json(_service.FindAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("id, title, description, categoryId, createdOn, published")]NewsDTO news)
        {
            if (ModelState.IsValid)
            {
                if(await _service.Save(news) > 0)                
                    return RedirectToAction(nameof(Index));
            }
            //ViewData["CategoriaId"] = new SelectList(_context.Categoria, "Id", "Nome", produto.CategoriaId);
            return View(news);
        }
    }
}