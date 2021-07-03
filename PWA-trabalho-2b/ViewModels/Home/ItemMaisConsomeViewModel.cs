using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.ViewModels.Home
{
    public class ItemMaisConsomeViewModel
    {
        public List<ItemMaisConsome> lista { get; set; } = new List<ItemMaisConsome>();
    }

    public class ItemMaisConsome
    {
        public string Item { get; set; }
        public decimal ConsumoMensalWatts { get; set; }
        public decimal ValorMensalKwh { get; set; }
    }
}
