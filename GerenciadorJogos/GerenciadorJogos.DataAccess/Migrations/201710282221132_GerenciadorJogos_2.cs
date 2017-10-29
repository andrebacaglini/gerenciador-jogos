namespace GerenciadorJogos.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GerenciadorJogos_2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tb_emprestimo");
            AddPrimaryKey("dbo.tb_emprestimo", new[] { "AmigoId", "JogoId" });
            DropColumn("dbo.tb_emprestimo", "EmprestimoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_emprestimo", "EmprestimoId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.tb_emprestimo");
            AddPrimaryKey("dbo.tb_emprestimo", "EmprestimoId");
        }
    }
}
