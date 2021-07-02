using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.Models.Categoria
{
    public class CategoriaEntity
    {
        public CategoriaEntity(string descricao, int categoriaPaiId)
        {
            Descricao = descricao;
            CategoriaPaiId = categoriaPaiId;
        }

        public CategoriaEntity()
        {
            Descricao = "";
            CategoriaPaiId = 0;
        }

        public int Id { get; private set; }
        public string Descricao { get; set; }
        public int CategoriaPaiId { get; set; }
    }
}
