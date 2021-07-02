using Microsoft.AspNetCore.Mvc;
using PWA_trabalho_2b.Models.Parametros;
using PWA_trabalho_2b.RequestModels.Parametro;
using PWA_trabalho_2b.ViewModels.Parametro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.Controllers
{
    public class ParametroController : Controller
    {
        private readonly ParametroService _parametroService;

        public ParametroController(ParametroService parametroService)
        {
            _parametroService = parametroService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var parametros = _parametroService.GetAll();
           
            var viewModel = new ParametroViewModel
            {
                //MENSAGEM VINDA DO CREATE(POST)
                MensagemSucesso = (string)TempData["MensagemSucesso"]
            };

            foreach (ParametroEntity p in parametros)
            {
                viewModel.Parametros.Add(p);
            }

            return View(viewModel);
        }

        //CHAMA PAGINA CREATE
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //RECEBE REQUISCAO
        [HttpPost]
        public RedirectToActionResult Create(ParametroRequestModel request)
        {
            _parametroService.Create(request);

            //RETORNA MENSAGEM PARA O INDEX
            TempData["MensagemSucesso"] = "Cadastro efetuado com sucesso!";
            return RedirectToAction("Index");
        }


        //CHAMA PAGINA CREATE
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var parametroEntity = _parametroService.GetById(id);

            var viewModel = new ParametroViewModel
            {
                Parametro = parametroEntity
            };

            return View(viewModel);
        }

        //RECEBE REQUISCAO
        [HttpPost]
        public RedirectToActionResult Edit(int id, ParametroRequestModel request)
        {
            _parametroService.Edit(id, request);

            //RETORNA MENSAGEM PARA O INDEX
            TempData["MensagemSucesso"] = "Parametro editado com sucesso!";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public RedirectToActionResult Delete(int id)
        {
            _parametroService.Delete(id);

            //ENVIA MENSAGEM PARA O INDEX
            TempData["MensagemSucesso"] = "Parametro deletado com sucesso!";
            
            return RedirectToAction("Index");
        }

    }
}
