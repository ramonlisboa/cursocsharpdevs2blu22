using Devs2Blu.ProjetosAula.CSharpMVCRevisao.Models;
using Devs2Blu.ProjetosAula.CSharpMVCRevisao.Models.DTOAPI;
using Devs2Blu.ProjetosAula.CSharpMVCRevisao.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Devs2Blu.ProjetosAula.CSharpMVCRevisao.Controllers
{
    [Route("cards")]
    public class CardApiController : Controller
    {
        private readonly ILogger<CardApiController> _logger;
        private readonly ServiceAPI service;

        public CardApiController(ILogger<CardApiController> logger)
        {
            _logger = logger;
            service = new ServiceAPI();
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("loadcards")]
        public async Task<PartialViewResult> LoadListCards()
        {
            _logger.LogInformation("Carregando a lista de Cards");
            var result = await service.GetListCards();
            var listCards = result.Take(20).ToList();
            return PartialView(listCards);
        }

        [Route("search/{nameCard}")]
        public async Task<PartialViewResult> SearchCard(string nameCard)
        {
            var card = await service.GetCardByName(nameCard);            
            return PartialView(card);
        }

    }
}