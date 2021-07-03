using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PWA_trabalho_2b.Models;
using PWA_trabalho_2b.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AnalisesService _analisesService;

        public HomeController(ILogger<HomeController> logger, AnalisesService analisesService)
        {
            _logger = logger;
            _analisesService = analisesService;
        }

        public IActionResult Index()
        {
            ResultadoFinalViewModel viewModel = new ResultadoFinalViewModel();
            var categoriaMaisConsome = _analisesService.CategoriasMaisConsome();
            var totalConsumo = _analisesService.TotalConsumo();
            var itensMaisConsome = _analisesService.ItemMaisConsomeEnergia();
            viewModel.CategoriaMaisConsome = categoriaMaisConsome;
            viewModel.ConsumoTotalEnergia = totalConsumo;
            viewModel.ItemMaisConsome = itensMaisConsome;
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
