using Microsoft.AspNetCore.Mvc.Rendering;
using PWA_trabalho_2b.Models.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.ViewModels.Categoria
{
    public class CategoriaViewModel
    {
        public CategoriaViewModel()
        {
            CategoriasPai = new List<SelectListItem>
            {
                new SelectListItem("Selecione", "0")
            };
        }

        public string MensagemSucesso { get; set; }
        public string MensagemErro { get; set; }
        public List<SelectListItem> CategoriasPai { get; set; }
        public List<Categoria> Categorias { get; set; } = new List<Categoria>();
        public CategoriaEntity Categoria { get; set; }

    }

    public class Categoria
    {
        public Categoria(int id, string descricao)
        {
            Descricao = descricao;
            Id = id;
        }

        public Categoria(int id, string descricao, string categoriaPaiId)
        {
            Id = id;
            Descricao = descricao;
            CategoriaPaiId = categoriaPaiId;
        }



        public int Id { get; private set; }
        public string Descricao { get; set; }
        public string CategoriaPaiId { get; set; }
    }
}
