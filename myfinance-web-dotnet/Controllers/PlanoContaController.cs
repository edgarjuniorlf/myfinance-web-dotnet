using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.infrastructure;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Services;

namespace myfinance_web_dotnet.Controllers
{

[Route("[Controller]")]
public class PlanoContaController : Controller
    {

        private readonly IPlanoContaService _planoContaService;
            
    
    public PlanoContaController(IPlanoContaService planoContaService) { 
        _planoContaService = planoContaService;
    }

    [Route("Index")]
    public IActionResult Index()
        {
            ViewBag.Lista = _planoContaService.ListarRegistros();
            return View();
        }

        [HttpGet]
        [HttpPost]
        [Route("Cadastro")]
        public IActionResult Cadastro(PlanoContaModel? model)
        {
            if (model != null && ModelState.IsValid)
            {
                var planoConta = new PlanoConta
                {
                    Id = model.Id,
                    Nome = model.Nome,
                    Tipo = model.Tipo
                };

                _planoContaService.Salvar(planoConta);
            }

            return View();
        }
    }
}
