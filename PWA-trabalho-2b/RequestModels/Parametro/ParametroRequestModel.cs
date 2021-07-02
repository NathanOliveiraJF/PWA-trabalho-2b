using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.RequestModels.Parametro
{
    public class ParametroRequestModel
    {
        public ParametroRequestModel(decimal valorKwh, decimal faixaConsumoAlto, decimal faixaConsumoMedio)
        {
            ValorKwh = valorKwh;
            FaixaConsumoAlto = faixaConsumoAlto;
            FaixaConsumoMedio = faixaConsumoMedio;
        }

        public ParametroRequestModel()
        {

        }

        public decimal ValorKwh { get; set; }
        public decimal FaixaConsumoAlto { get; set; }
        public decimal FaixaConsumoMedio { get; set; }
    }
}
