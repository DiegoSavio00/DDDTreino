using AutoMapper;
using DDDTreino.Aplicao.DTO;
using DDDTreino.Dominio.Entidades;

namespace DDDTreino.Aplicao
{
    public class MappingEntidade : Profile
    {
        public MappingEntidade()
        {
            CreateMap<Livro, LivroDTO>();
            CreateMap<LivroDTO, Livro>();
        }
    }
}
