using DDDTreino.Dominio.Entidades;
using DDDTreino.Dominio.Interfaces.Repositorios;
using DDDTreino.Dominio.Interfaces.Servicos;

namespace DDDTreino.Dominio.Servicos
{
    public class LivroServico : ServicoBase<Livro>, ILivroServico
    {
        public LivroServico(ILivroRepositorio repositorio) : base(repositorio)
        { }
    }
}
