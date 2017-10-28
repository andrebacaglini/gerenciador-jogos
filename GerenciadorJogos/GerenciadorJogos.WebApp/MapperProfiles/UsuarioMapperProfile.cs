using AutoMapper;
using GerenciadorJogos.Domain.Entities;
using GerenciadorJogos.WebApp.Models;

namespace GerenciadorJogos.WebApp.MapperProfiles
{
    public class UsuarioMapperProfile : Profile
    {
        public UsuarioMapperProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>();
        }

    }
}