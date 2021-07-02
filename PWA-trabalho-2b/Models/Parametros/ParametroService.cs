using PWA_trabalho_2b.Data;
using PWA_trabalho_2b.RequestModels.Parametro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.Models.Parametros
{
    public class ParametroService
    {
        private readonly DataBaseContext _dbContext;

        public ParametroService(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ParametroEntity> GetAll()
        {
            return _dbContext.Parametros;
        }


        public ParametroEntity GetById(int id)
        {
            var parametroEntity = _dbContext.Parametros.FirstOrDefault(x => x.Id == id);
            return parametroEntity ?? null;
        }

        public void Create(ParametroRequestModel request)
        {
            ParametroEntity parametro = new ParametroEntity(request.ValorKwh, request.FaixaConsumoAlto, request.FaixaConsumoMedio);
            _dbContext.Parametros.Add(parametro);
            _dbContext.SaveChanges();
        }

        public void Edit(int id, ParametroRequestModel request)
        {
            var parametroEntity = _dbContext.Parametros.Find(id);
            parametroEntity.ValorKwh = request.ValorKwh;
            parametroEntity.FaixaConsumoAlto = request.FaixaConsumoAlto;
            parametroEntity.FaixaConsumoMedio = request.FaixaConsumoMedio;

            _dbContext.Parametros.Update(parametroEntity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var parametroEntity = _dbContext.Parametros.Find(id);
            _dbContext.Remove(parametroEntity);
            _dbContext.SaveChanges();
        }
    }
}
