using AutoMapper;
using GerenciadorJogos.Domain.Entities;
using GerenciadorJogos.WebApp.Models;

namespace GerenciadorJogos.WebApp.MapperProfiles
{
    public class EmprestimoMapperProfile : Profile
    {
        public EmprestimoMapperProfile()
        {
            CreateMap<EmprestimoViewModel, Emprestimo>();                
            CreateMap<Emprestimo, EmprestimoViewModel>();
        }
    }
}