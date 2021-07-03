using PWA_trabalho_2b.Models.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.Models.Item
{
    public class ItemEntity
    {
        public ItemEntity(CategoriaEntity categoria, string nome, string descricao, DateTime dataFabricacao, decimal consumoWatts, int horasUsoDiario)
        {
            
            Categoria = categoria;
            Nome = nome;
            Descricao = descricao;
            DataFabricacao = dataFabricacao;
            ConsumoWatts = consumoWatts;
            HorasUsoDiario = horasUsoDiario;
        }

        public ItemEntity()
        {
            Id = new Guid();
            Nome = "";
            Descricao = "";
            ConsumoWatts = 0;
            HorasUsoDiario = 0;
        }

        public Guid Id { get;  set; }
        public CategoriaEntity Categoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public decimal ConsumoWatts { get; set; }
        public int HorasUsoDiario { get; set; }


        public decimal CalculaGastoEnergeticoMensalKwh()
        {
            return ((ConsumoWatts * HorasUsoDiario) * 30) / 1000;
        }

      
    }
}
