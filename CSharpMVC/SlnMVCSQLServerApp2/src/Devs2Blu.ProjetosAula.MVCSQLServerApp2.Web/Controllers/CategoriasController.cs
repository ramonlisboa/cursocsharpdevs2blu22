using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models.Entities;
using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Models.ViewModel;
using Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devs2Blu.ProjetosAula.MVCSQLServerApp2.Web.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriasService _service;
        public CategoriasController(ICategoriasService service)
        {
            _service = service;
        }
        // GET: CategoriasController
        public async Task<ActionResult> Index()
        {
            var listCategorias = await _service.GetAllCategorias();
            return View(listCategorias);
        }

        // GET: CategoriasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Nome")] CategoriaViewModel categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Save(categoria.ToEntity());
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
            }
                return View(categoria);
        }

        // GET: CategoriasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoriasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriasController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var categoria = await _service.FindById(id);
            return View(new CategoriaViewModel() { id = categoria.Id, nome = categoria.Nome });
        }

        // POST: CategoriasController/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult<string>> ExecuteDelete([Bind("id,nome")] CategoriaViewModel categoria)
        {
            try
            {
                var resp = await _service.Delete(categoria.ToEntity());
                return new ActionResult<string>("OK");
            }
            catch (Exception ex)
            {
                return new ActionResult<string>(ex.Message);
            }
        }
    }
}
