using AutoMapper;
using DDDTreino.Aplicao.DTO;
using DDDTreino.Aplicao.Interfaces;
using DDDTreino.Dominio.Entidades;
using DDDTreino.Dominio.Interfaces.Servicos;

namespace DDDTreino.Aplicao.Servicos
{
    public class LivroApp : ServicoAppBase<Livro, LivroDTO>, ILivroApp
    {
        public LivroApp(IMapper mapper, ILivroServico service) : base(service, mapper)
        {
        }
    }
}
