using Microsoft.EntityFrameworkCore;
using PWA_trabalho_2b.Data;
using PWA_trabalho_2b.Models.Categoria;
using PWA_trabalho_2b.RequestModels.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.Models.Item
{
    public class ItemService
    {
        private readonly DataBaseContext _dbContext;
        private readonly CategoriaService _categoriaService;

        public ItemService(DataBaseContext dbContext, CategoriaService categoriaService)
        {
            _dbContext = dbContext;
            _categoriaService = categoriaService;
        }

        public IEnumerable<ItemEntity> GetAll()
        {
            return _dbContext.Itens
                .Include(x => x.Categoria);
        }

        public ItemEntity GetById(Guid id)
        {
            var item = _dbContext.Itens.Find(id);
            return item ?? null;
        }

        public void Create(ItemRequestModel request)
        {

            var categoria = _categoriaService.GetById(Convert.ToInt32(request.CategoriaId));
            
            ItemEntity item = new ItemEntity
            {
                Categoria = categoria,
                ConsumoWatts = Convert.ToInt32(request.ConsumoWatts),
                DataFabricacao = DateTime.Parse(request.DataFabricacao),
                HorasUsoDiario = Convert.ToInt32(request.HorasUsoDiario),
                Descricao = request.Descricao,
                Nome = request.Nome
            };
            
            _dbContext.Itens.Add(item);
            _dbContext.SaveChanges();
        }

        public void Edit(Guid id, ItemRequestModel request)
        {
            CategoriaEntity categoriaEntity = _dbContext.Categorias.Find(Convert.ToInt32(request.CategoriaId));
            ItemEntity item = _dbContext.Itens.Find(id);

            item.Categoria = categoriaEntity;
            item.ConsumoWatts = Convert.ToDecimal(request.ConsumoWatts);
            item.DataFabricacao = DateTime.Parse(request.DataFabricacao);
            item.Nome = request.Nome;
            item.HorasUsoDiario = request.HorasUsoDiario;
            item.Descricao = request.Descricao;  

            _dbContext.Itens.Update(item);

            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var item = _dbContext.Itens.Find(id);
            _dbContext.Remove(item);
            _dbContext.SaveChanges();
        }

        public IEnumerable<ItemEntity> GetAllByCategoria(int id)
        {
           
            return _dbContext.Itens.Where(x => x.Categoria.Id == id).ToList();
        }
    }
}
