namespace GerenciadorJogos.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GerenciadorJogos_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_amigo",
                c => new
                    {
                        AmigoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Sobrenome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Apelido = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.AmigoId);
            
            CreateTable(
                "dbo.tb_emprestimo",
                c => new
                    {
                        EmprestimoId = c.Int(nullable: false, identity: true),
                        AmigoId = c.Int(nullable: false),
                        JogoId = c.Int(nullable: false),
                        DataEmprestimo = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DataDevolucao = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.EmprestimoId)
                .ForeignKey("dbo.tb_amigo", t => t.AmigoId)
                .ForeignKey("dbo.tb_jogo", t => t.JogoId)
                .Index(t => t.AmigoId)
                .Index(t => t.JogoId);
            
            CreateTable(
                "dbo.tb_jogo",
                c => new
                    {
                        JogoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Plataforma = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JogoId);
            
            CreateTable(
                "dbo.tb_usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        NomeUsuario = c.String(nullable: false, maxLength: 50, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.tb_emprestimo", "JogoId", "dbo.tb_jogo");
            //DropForeignKey("dbo.tb_emprestimo", "AmigoId", "dbo.tb_amigo");
            //DropIndex("dbo.tb_emprestimo", new[] { "JogoId" });
            //DropIndex("dbo.tb_emprestimo", new[] { "AmigoId" });
            //DropTable("dbo.tb_usuario");
            //DropTable("dbo.tb_jogo");
            //DropTable("dbo.tb_emprestimo");
            //DropTable("dbo.tb_amigo");
        }
    }
}
