using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.ViewModels.Home
{
    public class ConsumoTotalEnergiaViewModel
    {

        public List<ConsumoTotal> lista { get; set; } = new List<ConsumoTotal>();
    }

    public class ConsumoTotal
    {
        public string Item { get; set; }
        public decimal TotalGastos { get; set; }
        public decimal ValorReaisMensal { get; set; }
        public string Faixa { get; set; }
    }
}
