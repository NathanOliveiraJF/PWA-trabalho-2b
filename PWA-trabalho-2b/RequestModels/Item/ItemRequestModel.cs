using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.RequestModels.Item
{
    public class ItemRequestModel
    {
        public ItemRequestModel()
        {
            CategoriaId = "";
            Nome = "";
            Descricao = "";
            DataFabricacao = "";
            ConsumoWatts = "";
            HorasUsoDiario = 0;
         }

        public string CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string DataFabricacao { get; set; }
        public string ConsumoWatts { get; set; }
        public int HorasUsoDiario { get; set; }
    }
}
