namespace GerenciadorJogos.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Atualizacao2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Usuario", newName: "tb_usuario");
            AlterColumn("dbo.tb_usuario", "NomeUsuario", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.tb_usuario", "Senha", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.tb_usuario", "Email", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_usuario", "Email", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.tb_usuario", "Senha", c => c.String(maxLength: 200, unicode: false));
            AlterColumn("dbo.tb_usuario", "NomeUsuario", c => c.String(maxLength: 200, unicode: false));
            RenameTable(name: "dbo.tb_usuario", newName: "Usuario");
        }
    }
}
