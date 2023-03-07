using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Domain.Interfaces.IRepository;

namespace ProjetoNotas.Application.API.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;
        public NoteController(INoteService noteService)
        {
            this._noteService = noteService;
        }
        public JsonResult Index()
        {
            var listNotesUser = _noteService.FindAll();
            return Json(listNotesUser);
        }
    }
}
