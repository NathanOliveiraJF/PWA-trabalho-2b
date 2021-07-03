using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.ViewModels.Home
{
    public class CategoriaMaisConsomeViewModel
    {
        public List<CategoriaMaisConsome> lista { get; set; } = new List<CategoriaMaisConsome>();

    }

    public class CategoriaMaisConsome 
    {
        public string Categoria { get; set; }
        public decimal ConsumoMensalWatts { get; set; }
        public decimal ValorMensalKwh { get; set; }
    }

}
