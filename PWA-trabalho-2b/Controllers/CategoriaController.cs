using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PWA_trabalho_2b.Models.Categoria;
using PWA_trabalho_2b.RequestModels.Categoria;
using PWA_trabalho_2b.ViewModels.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaService _categoriaService;

        public CategoriaController(CategoriaService categoria)
        {
            _categoriaService = categoria;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var categorias = _categoriaService.GetAll();

            var viewModel = new CategoriaViewModel
            {
                //MENSAGEM VINDA DO CREATE(POST)
                MensagemSucesso = (string)TempData["MensagemSucesso"],
                MensagemErro = (string)TempData["MensagemErro"],
            };

            //ALIMENTANDO A LISTAGEM DE CATEGORIAS PARA TELA
            foreach (CategoriaEntity categoria in categorias)
            {
                if (categoria.CategoriaPaiId == 0)
                {
                    viewModel.Categorias.Add(new Categoria(categoria.Id, categoria.Descricao));
                } else
                {
                    var cat = _categoriaService.GetById(categoria.CategoriaPaiId);
                    viewModel.Categorias.Add(new Categoria(categoria.Id, categoria.Descricao, categoria.CategoriaPaiId.ToString()));
                }
            }

            return View(viewModel);
        }


        //CHAMA PAGINA CREATE(CATEGORIAS)
        [HttpGet]
        public IActionResult Create()
        {
            var categorias = _categoriaService.GetAll();

            var viewModel = new CategoriaViewModel();

            //COMBOBOX DE SUBCATEGORIA
            foreach (CategoriaEntity c in categorias)
            {
                viewModel.CategoriasPai.Add(new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Descricao
                });
            }

            return View(viewModel);
        }

        //RECEBE REQUISCAO
        [HttpPost]
        public RedirectToActionResult Create(CategoriaRequestModel request)
        {
            _categoriaService.Create(request);

            //RETORNA MENSAGEM PARA O INDEX
            TempData["MensagemSucesso"] = "Cadastro efetuado com sucesso!";
            return RedirectToAction("Index");
        }

        //CHAMA PAGINA EDIT
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var categoriaEntity = _categoriaService.GetById(id);
            
            var viewModel = new CategoriaViewModel
            {
                 Categoria = categoriaEntity
            };


            var all = _categoriaService.GetAll();
            //COMBOBOX DE SUBCATEGORIA
            foreach (CategoriaEntity c in all)
            {
                //NA HORA DE EDITAR NAO DEIXA EXIBIR A CATEGORIA SER IGUAL A SUBCATEGORIA
                if (categoriaEntity.Descricao != c.Descricao)
                {
                    viewModel.CategoriasPai.Add(new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Descricao
                    });
                }
                
            }

            return View(viewModel);
        }

        //RECEBE REQUISCAO
        [HttpPost]
        public RedirectToActionResult Edit(int id, CategoriaRequestModel request)
        {
            _categoriaService.Edit(id, request);

            //RETORNA MENSAGEM PARA O INDEX
            TempData["MensagemSucesso"] = "Parametro editado com sucesso!";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public RedirectToActionResult Delete(int id)
        {

            var list = _categoriaService.GetByCategoriaPaiId(id);

            if(list.Any())
            {
                TempData["MensagemErro"] = "Em uso, não pode ser deletado!";
                return RedirectToAction("Index");
            }

            _categoriaService.Delete(id);

            //RETORNA MENSAGEM PARA O INDEX
            TempData["MensagemSucesso"] = "Parametro deletado com sucesso!";
            return RedirectToAction("Index");
        }
    }
}
