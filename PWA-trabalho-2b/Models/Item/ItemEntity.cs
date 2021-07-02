using PWA_trabalho_2b.Models.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.Models.Item
{
    public class ItemEntity
    {
        public int Id { get; private set; }
        public CategoriaEntity categoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public decimal ConsumoWatts { get; set; }
        public int HorasUsoDiario { get; set; }
    }
}
