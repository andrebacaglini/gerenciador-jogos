using AutoMapper;
using GerenciadorJogos.Domain.Entities;
using GerenciadorJogos.WebApp.Models;

namespace GerenciadorJogos.WebApp.MapperProfiles
{
    public class JogoMapperProfile :Profile
    {
        public JogoMapperProfile()
        {
            CreateMap<JogoViewModel, Jogo>();
            CreateMap<Jogo, JogoViewModel>();
        }
    }
}