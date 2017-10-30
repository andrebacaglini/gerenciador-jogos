namespace GerenciadorJogos.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GerenciadorJogos_3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tb_emprestimo");
            AddColumn("dbo.tb_amigo", "UsuarioId", c => c.Int(nullable: false));
            AddColumn("dbo.tb_emprestimo", "UsuarioId", c => c.Int(nullable: false));
            AddColumn("dbo.tb_jogo", "UsuarioId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.tb_emprestimo", new[] { "AmigoId", "JogoId", "UsuarioId" });
            CreateIndex("dbo.tb_amigo", "UsuarioId");
            CreateIndex("dbo.tb_emprestimo", "UsuarioId");
            CreateIndex("dbo.tb_jogo", "UsuarioId");
            AddForeignKey("dbo.tb_jogo", "UsuarioId", "dbo.tb_usuario", "UsuarioId");
            AddForeignKey("dbo.tb_emprestimo", "UsuarioId", "dbo.tb_usuario", "UsuarioId");
            AddForeignKey("dbo.tb_amigo", "UsuarioId", "dbo.tb_usuario", "UsuarioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_amigo", "UsuarioId", "dbo.tb_usuario");
            DropForeignKey("dbo.tb_emprestimo", "UsuarioId", "dbo.tb_usuario");
            DropForeignKey("dbo.tb_jogo", "UsuarioId", "dbo.tb_usuario");
            DropIndex("dbo.tb_jogo", new[] { "UsuarioId" });
            DropIndex("dbo.tb_emprestimo", new[] { "UsuarioId" });
            DropIndex("dbo.tb_amigo", new[] { "UsuarioId" });
            DropPrimaryKey("dbo.tb_emprestimo");
            DropColumn("dbo.tb_jogo", "UsuarioId");
            DropColumn("dbo.tb_emprestimo", "UsuarioId");
            DropColumn("dbo.tb_amigo", "UsuarioId");
            AddPrimaryKey("dbo.tb_emprestimo", new[] { "AmigoId", "JogoId" });
        }
    }
}
