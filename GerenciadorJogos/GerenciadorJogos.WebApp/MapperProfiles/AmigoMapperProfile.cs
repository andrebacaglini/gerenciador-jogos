using AutoMapper;
using GerenciadorJogos.Domain.Entities;
using GerenciadorJogos.WebApp.Models;

namespace GerenciadorJogos.WebApp.MapperProfiles
{
    public class AmigoMapperProfile : Profile
    {
        public AmigoMapperProfile()
        {
            CreateMap<AmigoViewModel, Amigo>();
            CreateMap<Amigo, AmigoViewModel>();
        }
    }
}