using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.Models.Parametros
{
    public class ParametroEntity
    {
        public ParametroEntity(decimal valorKwh, decimal faixaConsumoAlto, decimal faixaConsumoMedio)
        {
            ValorKwh = valorKwh;
            FaixaConsumoAlto = faixaConsumoAlto;
            FaixaConsumoMedio = faixaConsumoMedio;
        }

        public ParametroEntity()
        {
            Id = 0;
            ValorKwh = 0;
            FaixaConsumoAlto = 0;
            FaixaConsumoMedio = 0;
        }

        public int Id { get;  set; }
        public decimal ValorKwh { get; set; }
        public decimal FaixaConsumoAlto { get; set; }
        public decimal FaixaConsumoMedio { get; set; }
       
    }
}
