using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.infrastructure;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Services;

namespace myfinance_web_dotnet.Controllers
{

public class PlanoContaController : Controller
    {

        private readonly IPlanoContaService _planoContaService;
            
    
    public PlanoContaController(IPlanoContaService planoContaService) { 
        _planoContaService = planoContaService;
    }

    public IActionResult Index()
        {
            ViewBag.Lista = _planoContaService.ListarRegistros();
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }
    }
}
