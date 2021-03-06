namespace GerenciadorJogos.DataAccess.Migrations
{
    using global::GerenciadorJogos.DataAccess.Context;
    using global::GerenciadorJogos.Domain.Entities;
    using global::GerenciadorJogos.Util.Enums;
    using global::GerenciadorJogos.Util.Helpers;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<GerenciadorJogosContext>
    {
        public Configuration()
        { 
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GerenciadorJogosContext context)
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
