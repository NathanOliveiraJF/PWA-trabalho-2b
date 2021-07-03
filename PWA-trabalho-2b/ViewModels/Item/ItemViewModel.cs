using Microsoft.AspNetCore.Mvc.Rendering;
using PWA_trabalho_2b.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.ViewModels.Item
{
    public class ItemViewModel
    {
        public ItemViewModel()
        {
            Categorias = new List<SelectListItem>
            {
                new SelectListItem("Selecione", "0")
            };
        }

        public string MensagemSucesso { get; set; }
        public string MensagemErro { get; set; }
        public Item Item { get; set; } = new Item();
        public List<SelectListItem> Categorias { get; set; }
        public List<Item> Itens { get; set; } = new List<Item>();



    }

    public class Item
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string Nome { get; set; }
        public string DataFabricacao { get; set; }
        public string ConsumoWatts { get; set; }
        public string HorasUsoDiario { get; set; }
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
