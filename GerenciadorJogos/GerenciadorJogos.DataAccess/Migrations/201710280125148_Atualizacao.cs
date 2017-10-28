namespace GerenciadorJogos.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Atualizacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        NomeUsuario = c.String(maxLength: 50, unicode: false),
                        Senha = c.String(maxLength: 50, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false, precision: 7, storeType: "datetime2")
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
        }
    }
}
