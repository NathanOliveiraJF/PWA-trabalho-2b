using Microsoft.EntityFrameworkCore;
using PWA_trabalho_2b.Models.Categoria;
using PWA_trabalho_2b.Models.Item;
using PWA_trabalho_2b.Models.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<ParametroEntity> Parametros { get; set; }
        public DbSet<ItemEntity> Itens { get; set; }
        public DbSet<CategoriaEntity> Categorias { get; set; }
    }
}
