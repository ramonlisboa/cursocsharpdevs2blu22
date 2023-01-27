using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RevisaoProjetoNoticias.Domain.DTO;
using RevisaoProjetoNoticias.Domain.Entities;
using RevisaoProjetoNoticias.Domain.IServices;
using RevisaoProjetoNoticias.Web.Models;
using System.Diagnostics;

namespace RevisaoProjetoNoticias.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _service;
        private readonly ICategoryService _categoryService;

        public NewsController(INewsService service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
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
            ViewData["categoryId"] = new SelectList(_categoryService.FindAll(), "id", "name", "Select...");
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
            ViewData["categoryId"] = new SelectList(_categoryService.FindAll(), "id", "name", news.categoryId);
            return View(news);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int? id)
        {
            var retDel = new ReturnJsonDel
            {
                status = "Success",
                code = "200"
            };
            try
            {
                if (await _service.Delete(id ?? 0) <= 0)
                {
                    retDel = new ReturnJsonDel
                    {
                        status = "Error",
                        code = "400"
                    };
                }
            } catch (Exception ex)
            {
                retDel = new ReturnJsonDel
                {
                    status = ex.Message,
                    code = "500"
                };
            }
            return Json(retDel);
        }
    }
}