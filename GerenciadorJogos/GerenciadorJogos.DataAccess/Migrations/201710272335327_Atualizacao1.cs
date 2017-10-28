namespace GerenciadorJogos.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Atualizacao1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_emprestimo", "DataEmprestimo", c => c.DateTime(nullable: false));
            AddColumn("dbo.tb_emprestimo", "DataDevolucao", c => c.DateTime());
            AddColumn("dbo.tb_jogo", "Plataforma", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_jogo", "Plataforma");
            DropColumn("dbo.tb_emprestimo", "DataDevolucao");
            DropColumn("dbo.tb_emprestimo", "DataEmprestimo");
        }
    }
}
