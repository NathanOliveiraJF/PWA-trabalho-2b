using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PWA_trabalho_2b.Models.Categoria;
using PWA_trabalho_2b.Models.Item;
using PWA_trabalho_2b.RequestModels.Item;
using PWA_trabalho_2b.ViewModels.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemService  _ItemService;
        private readonly CategoriaService _categoriaService;

        public ItemController(ItemService itemService, CategoriaService categoriaService)
        {
            _ItemService = itemService;
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var itens = _ItemService.GetAll();

            var viewModel = new ItemViewModel
            {
                //MENSAGEM VINDA DO CREATE(POST)
                MensagemSucesso = (string)TempData["MensagemSucesso"]
            };


            foreach (var item in itens)
            {
                viewModel.Itens.Add(new Item 
                { 
                    Nome = item.Nome, 
                    ConsumoWatts = item.ConsumoWatts.ToString(), 
                    DataFabricacao = item.DataFabricacao.ToString("dd/MM/yyyy"),
                    Descricao = item.Descricao,
                    HorasUsoDiario = item.HorasUsoDiario.ToString(),
                    Id = item.Id,
                    Categoria = item.Categoria.Descricao
                });
            }
            

            return View(viewModel);
        }



        //CHAMA PAGINA CREATE(itens)
        [HttpGet]
        public IActionResult Create()
        {
            var categorias = _categoriaService.GetAll();

            var viewModel = new ItemViewModel
            {
                //MENSAGEM VINDA DO CREATE(POST)
                MensagemSucesso = (string)TempData["MensagemSucesso"]
            };

            //ALIMENTANDO A LISTAGEM DE CATEGORIAS PARA TELA
            foreach (CategoriaEntity categoria in categorias)
            {

                //COMBOBOX DE SUBCATEGORIA
                viewModel.Categorias.Add(new SelectListItem
                {
                    Value = categoria.Id.ToString(),
                    Text = categoria.Descricao
                });
            }

            return View(viewModel);
        }

        //RECEBE REQUISCAO
        [HttpPost]
        public RedirectToActionResult Create(ItemRequestModel request)
        {
            _ItemService.Create(request);

            //RETORNA MENSAGEM PARA O INDEX
            TempData["MensagemSucesso"] = "Cadastro efetuado com sucesso!";
            return RedirectToAction("Index");
        }

        //CHAMA PAGINA EDIT
        [HttpGet]
        public IActionResult Edit(Guid id)
        {

            var item = _ItemService.GetById(id);

            var viewModel = new ItemViewModel();

            viewModel.Item.ConsumoWatts = item.ConsumoWatts.ToString();
            viewModel.Item.DataFabricacao = item.DataFabricacao.ToString("yyyy-MM-dd");
            viewModel.Item.Descricao = item.Descricao;
            viewModel.Item.Nome = item.Nome;
            viewModel.Item.Id = item.Id;
            viewModel.Item.HorasUsoDiario = item.HorasUsoDiario.ToString();

            var categorias = _categoriaService.GetAll();
            
            //ALIMENTANDO A LISTAGEM DE CATEGORIAS PARA TELA
            foreach (CategoriaEntity categoria in categorias)
            {

                //COMBOBOX DE SUBCATEGORIA
                viewModel.Categorias.Add(new SelectListItem
                {
                    Value = categoria.Id.ToString(),
                    Text = categoria.Descricao
                });
            }


            return View(viewModel);
        }

        //RECEBE REQUISCAO
        [HttpPost]
        public RedirectToActionResult Edit(Guid id, ItemRequestModel request)
        {
            _ItemService.Edit(id, request);

            //RETORNA MENSAGEM PARA O INDEX
            TempData["MensagemSucesso"] = "Item editado com sucesso!";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public RedirectToActionResult Delete(Guid id)
        {
            _ItemService.Delete(id);

            //RETORNA MENSAGEM PARA O INDEX
            TempData["MensagemSucesso"] = "Item deletado com sucesso!";
            return RedirectToAction("Index");
        }
    }
}
