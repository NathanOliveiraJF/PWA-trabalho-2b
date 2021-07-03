using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.RequestModels.Categoria
{
    public class CategoriaRequestModel
    {
        public CategoriaRequestModel(string descricao, string categoriaPaiId)
        {
            Descricao = descricao;
            CategoriaPaiId = categoriaPaiId;
        }

        public CategoriaRequestModel()
        {
            Descricao = "";
            CategoriaPaiId = "";
        }

        public string Descricao { get; set; }
        public string CategoriaPaiId { get; set; }
    }
}
