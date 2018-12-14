namespace Loja.Repositorio.SqlServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenomearProdutoDescontinuadoParaAtivo : DbMigration
    {
        public override void Up()
        {
            //Sql("")
            AddColumn("dbo.Produto", "Ativo", c => c.Boolean(nullable: false, defaultValue: true));
            DropColumn("dbo.Produto", "Descontinuado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produto", "Descontinuado", c => c.Boolean(nullable: false, defaultValue: false));
            DropColumn("dbo.Produto", "Ativo");
        }
    }
}
