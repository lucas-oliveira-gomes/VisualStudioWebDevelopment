namespace ViagensOnline.Ropositorios.SqlServer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ViagensOnline.Ropositorios.SqlServer.ViagensOnlineDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ViagensOnline.Ropositorios.SqlServer.ViagensOnlineDbContext";
        }

        protected override void Seed(ViagensOnline.Ropositorios.SqlServer.ViagensOnlineDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
