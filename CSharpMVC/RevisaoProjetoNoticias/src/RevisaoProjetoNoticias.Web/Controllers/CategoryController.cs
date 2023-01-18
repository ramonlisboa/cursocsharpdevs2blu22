using Microsoft.AspNetCore.Mvc;
using RevisaoProjetoNoticias.Domain.IServices;
using RevisaoProjetoNoticias.Web.Models;
using System.Diagnostics;

namespace RevisaoProjetoNoticias.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _service;

        public CategoryController(ILogger<CategoryController> logger,
                                  ICategoryService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            // To List all categories
            // Get of CategoryRepository through Dependecy Injection (CategoryService)
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}