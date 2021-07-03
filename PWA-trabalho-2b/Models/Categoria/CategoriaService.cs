using PWA_trabalho_2b.Data;
using PWA_trabalho_2b.RequestModels.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.Models.Categoria
{
    public class CategoriaService
    {
        private readonly DataBaseContext _dbContext;

        public CategoriaService(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CategoriaEntity> GetAll()
        {
            return _dbContext.Categorias;
        }

        public CategoriaEntity GetById(int id)
        {
            var categoriaEntity = _dbContext.Categorias.Find(id);
            return categoriaEntity ?? null;
        }


        public IEnumerable<CategoriaEntity> GetByCategoriaPaiId(int id)
        {
            var categoriaEntity = _dbContext.Categorias.Where(x => x.CategoriaPaiId == id).ToList();
            return categoriaEntity ?? null;
        }

        public void Create(CategoriaRequestModel request)
        {
            CategoriaEntity categoriaEntity;

            //SE NÃO VIER CATEGORIA PAI
            if (request.CategoriaPaiId == "0" || request.CategoriaPaiId == "" || request.CategoriaPaiId == null)
            {
               categoriaEntity = new CategoriaEntity(request.Descricao);
            } 
            else
            {
                var categoriaPaiId = _dbContext.Categorias.Find( Convert.ToInt32(request.CategoriaPaiId) );
                categoriaEntity = new CategoriaEntity(request.Descricao, categoriaPaiId.Id);
            }

            
            _dbContext.Categorias.Add(categoriaEntity);
            _dbContext.SaveChanges();
        }

        public void Edit(int id, CategoriaRequestModel request)
        {
            CategoriaEntity categoriaEntity = _dbContext.Categorias.Find(id);

            //SE NÃO VIER CATEGORIA PAI, ATUALIZA SÓ O NOME
            if (request.CategoriaPaiId == "0")
            {
                categoriaEntity.Descricao = request.Descricao;
            }

            //BUSCA O ID DA SUB CATEGORIA
            var categoriaPaiId = _dbContext.Categorias.FirstOrDefault(x => x.Id.ToString() == request.CategoriaPaiId);

            

            categoriaEntity.Descricao = request.Descricao;
            
            categoriaEntity.CategoriaPaiId = categoriaPaiId.Id;
            
            _dbContext.Categorias.Update(categoriaEntity);
            
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var categoriaEntity = _dbContext.Categorias.Find(id);
            _dbContext.Remove(categoriaEntity);
            _dbContext.SaveChanges();
        }


    }
}
