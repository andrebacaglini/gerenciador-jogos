using Autofac;
using GerenciadorJogos.Business;
using GerenciadorJogos.DataAccess.Context;
using System.Linq;

namespace GerenciadorJogos.Bootstrapper
{
    public class BootstrapContainer
    {
        public static ContainerBuilder InicializarContainer()
        {
            var builder = new ContainerBuilder();

            var business = typeof(UsuarioBusiness).Assembly;
            builder.RegisterAssemblyTypes(business)
                .Where(x => x.Name.EndsWith("Business") && x.Namespace == "GerenciadorJogos.Business")
                .AsImplementedInterfaces()
                .PropertiesAutowired();

            var dataAccess = typeof(GerenciadorJogosContext).Assembly;
            builder.RegisterAssemblyTypes(dataAccess)
                .Where(x=>x.Namespace == "GerenciadorJogos.DataAccess.Context")
                .AsSelf();

            return builder;
        }
    }
}
