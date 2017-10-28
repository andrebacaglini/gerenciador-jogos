namespace GerenciadorJogos.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Atualizacao11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_emprestimo", "DataEmprestimo", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.tb_emprestimo", "DataDevolucao", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_emprestimo", "DataDevolucao", c => c.DateTime());
            AlterColumn("dbo.tb_emprestimo", "DataEmprestimo", c => c.DateTime(nullable: false));
        }
    }
}
