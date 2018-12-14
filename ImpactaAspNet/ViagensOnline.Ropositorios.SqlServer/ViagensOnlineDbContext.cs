﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagensOnline.Dominio;

namespace ViagensOnline.Ropositorios.SqlServer
{
    public class ViagensOnlineDbContext : DbContext
    {
        public ViagensOnlineDbContext() : base("viagensOnlineSqlServer")
        {

        }

        public DbSet<Destino> Destinos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
