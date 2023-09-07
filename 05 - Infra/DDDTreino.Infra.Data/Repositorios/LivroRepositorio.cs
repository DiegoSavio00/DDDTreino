using DDDTreino.Dominio.Entidades;
using DDDTreino.Dominio.Interfaces.Repositorios;
using DDDTreino.Infra.Data.Contexto;

namespace DDDTreino.Infra.Data.Repositorios
{
    public class LivroRepositorio : RepositorioBase<Livro>, ILivroRepositorio
    {
        public LivroRepositorio(DbContexto contexto) : base(contexto)
        { }
    }
}
