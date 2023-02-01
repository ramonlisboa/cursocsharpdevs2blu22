using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RevisaoProjetoNoticias.Domain.DTO;
using RevisaoProjetoNoticias.Domain.Entities;
using RevisaoProjetoNoticias.Domain.IServices;
using RevisaoProjetoNoticias.Web.Models;
using RevisaoProjetoNoticias.Web.Models.DTO;
using System.IO;


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
            var list = _service.FindAll();
            return View(list);
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
        public IActionResult ImagePost(int id)
        {
            ImageFieldNews newsModel = new ImageFieldNews();
            if (id != null)
            {
                newsModel.idNews = id;
            }
            return View(newsModel);
        }

        [HttpPost]
        public async Task<IActionResult> ImagePost(int idNews, List<IFormFile> imageNews)
        {
            try
            {
                if (idNews == null)
                {
                    ViewBag.Message = $"O ID da News é Null!";
                    return View(new ImageFieldNews() { idNews = idNews});
                }

                var file = imageNews.FirstOrDefault();
                var fileName = $"{idNews}_{file.FileName}";
                string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot//Uploads", fileName);

                if (await _service.SaveFile(idNews, fileName) > 0)
                {
                    var stream = new FileStream(path, FileMode.Create);
                    file.CopyToAsync(stream);
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Message = $"Não foi possível salvar o arquivo: {path}";
                return View(new ImageFieldNews() { idNews = idNews , imageNews = fileName});
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error: {ex.Message}";
            }
            return View();
        }
    }
}