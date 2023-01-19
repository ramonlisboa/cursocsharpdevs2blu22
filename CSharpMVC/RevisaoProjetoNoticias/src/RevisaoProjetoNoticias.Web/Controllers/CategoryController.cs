using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RevisaoProjetoNoticias.Domain.IServices;
using RevisaoProjetoNoticias.Web.Models;
using System.Diagnostics;

namespace RevisaoProjetoNoticias.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            // To List all categories
            // Get of CategoryRepository through Dependecy Injection (CategoryService)
            return View(_service.FindAll());
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}