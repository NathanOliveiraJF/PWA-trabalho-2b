using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.Models.Categoria
{
    public class CategoriaEntity
    {
        public CategoriaEntity(int id, string descricao, int categoriaPaiId)
        {
            Id = id;
            Descricao = descricao;
            CategoriaPaiId = categoriaPaiId;
        }

        public CategoriaEntity(string descricao)
        {
            Descricao = descricao;
        }

        public CategoriaEntity()
        {
            Descricao = "";
            CategoriaPaiId = 0;
        }

        public CategoriaEntity(string descricao, int categoriaPaiId) : this(descricao)
        {
            CategoriaPaiId = categoriaPaiId;
        }

        public int Id { get; private set; }
        public string Descricao { get; set; }
        public int CategoriaPaiId { get; set; }
    }
}
