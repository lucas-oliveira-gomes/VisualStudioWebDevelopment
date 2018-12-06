using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagensOnLine.Dominio;

namespace ViagensOnLine.Respositorios.SqlServer
{
    public class ViagensOnlineDbContext : DbContext
    {
        public ViagensOnlineDbContext() : base("viagensOnlineSqlServer")
        {

        }

        public DbSet<Destino> Destinos { get; set; }
    }
}
