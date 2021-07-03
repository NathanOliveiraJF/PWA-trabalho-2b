using PWA_trabalho_2b.Data;
using PWA_trabalho_2b.Models.Categoria;
using PWA_trabalho_2b.Models.Item;
using PWA_trabalho_2b.Models.Parametros;
using PWA_trabalho_2b.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.Models
{
    public class AnalisesService
    {
        private readonly DataBaseContext _databaseContext;
        private readonly ParametroService _parametroService;
        private readonly CategoriaService _categoriaService;
        private readonly ItemService _itemService;

        public AnalisesService(DataBaseContext databaseContext, ParametroService parametroService, CategoriaService categoriaService, ItemService itemService)
        {
            _databaseContext = databaseContext;
            _parametroService = parametroService;
            _categoriaService = categoriaService;
            _itemService = itemService;
        }

        public CategoriaMaisConsomeViewModel CategoriasMaisConsome()
        {
            var pa = _parametroService.GetAtivo();
            var allCategorias = _categoriaService.GetAll();
            var itens = _itemService.GetAll().ToList();
            var viewModel = new CategoriaMaisConsomeViewModel();
           

            foreach (var cat in allCategorias)
            {
                var itemDaCategoria = itens.Where(x => x.Categoria == cat);
                    
                decimal consumoMensalItens = 0;

                foreach (var itemEntity in itemDaCategoria)
                {
                    consumoMensalItens += itemEntity.CalculaGastoEnergeticoMensalKwh();
                }

                viewModel.lista.Add(new CategoriaMaisConsome
                {
                    Categoria = cat.Descricao,
                    ConsumoMensalWatts = consumoMensalItens,
                    ValorMensalKwh = consumoMensalItens * pa.ValorKwh
                });
            }

            viewModel.lista = viewModel.lista.Take(3).ToList();

            return viewModel;

            //viewModel.lista = viewModel.lista.OrderByDescending(x => x.ConsumoMensalWatts).Take(5).ToList();
        }

        public ConsumoTotalEnergiaViewModel TotalConsumo()
        {
            var viewModel = new ConsumoTotalEnergiaViewModel();

            var itens = _databaseContext.Itens.ToList();
            var pa = _parametroService.GetAtivo();



            var diaAtual = DateTime.DaysInMonth(DateTime.Now.Year,  DateTime.Now.Month);

            foreach (var item in itens)
            {
                viewModel.lista.Add(new ConsumoTotal
                {
                    TotalGastos = ((item.ConsumoWatts * item.HorasUsoDiario) * diaAtual) / 1000,
                    ValorReaisMensal = item.ConsumoWatts * pa.ValorKwh,
                    Item = item.Nome
                });
            }

            foreach (var item in viewModel.lista)
            {
                if(item.TotalGastos > pa.FaixaConsumoAlto)
                {
                    item.Faixa = "Alto";
                }
                else if(item.TotalGastos < pa.FaixaConsumoMedio)
                {
                    item.Faixa = "Baixo";
                } 
                else
                {
                    item.Faixa = "Médio";
                }
            }

            return viewModel;
        }

        public ItemMaisConsomeViewModel ItemMaisConsomeEnergia()
        {
            var itens = _databaseContext.Itens.ToList();

            var viewModel = new ItemMaisConsomeViewModel();



            foreach (var item in itens)
            {

                viewModel.lista.Add(new ItemMaisConsome
                {
                    Item = item.Nome,
                    ConsumoMensalWatts = ((item.ConsumoWatts * item.HorasUsoDiario) * DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)) / 1000,
                    ValorMensalKwh = item.CalculaGastoEnergeticoMensalKwh()
                });
            }

            viewModel.lista = viewModel.lista.OrderByDescending(x => x.ConsumoMensalWatts).Take(5).ToList();

            return viewModel;
        }
    }
}
