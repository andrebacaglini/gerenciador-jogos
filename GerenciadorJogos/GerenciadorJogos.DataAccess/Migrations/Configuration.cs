namespace GerenciadorJogos.DataAccess.Migrations
{
    using GerenciadorJogos.Domain.Entities;
    using GerenciadorJogos.Util.Enums;
    using GerenciadorJogos.Util.Helpers;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<GerenciadorJogos.DataAccess.Context.GerenciadorJogosContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GerenciadorJogos.DataAccess.Context.GerenciadorJogosContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var jogo = new Jogo { Nome = "Jogo", Plataforma = EnumPlataforma.PC };
            var amigo = new Amigo { Nome = "Amigo", Sobrenome = "Sobrenome" };
            var emprestimo = new Emprestimo { Amigo = amigo, Jogo = jogo, DataEmprestimo = DateTime.Now };

            context.Emprestimos.AddOrUpdate(emprestimo);

            var usuario = new Usuario
            {
                NomeUsuario = "andrebacaglini",
                Senha = CriptografiaHelper.Criptografar("#B4c4glini"),
                DataCadastro = DateTime.Now,
                Email = "andrebacaglini@gmail.com"
            };

            context.Usuarios.AddOrUpdate(usuario);
        }
    }
}
