using DDDTreino.Dominio.Entidades;
using DDDTreino.Dominio.Interfaces.Repositorios;
using DDDTreino.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;

namespace DDDTreino.Infra.Data.Repositorios
{
    public class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade>
        where TEntidade : EntidadeBase
    {
        protected readonly DbContexto _contexto;

        public RepositorioBase(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public void Alterar(TEntidade entidade)
        {
            _contexto.InitTransacao();
            _contexto.Set<TEntidade>().Attach(entidade);
            _contexto.Entry(entidade).State = EntityState.Modified;
            _contexto.SendChanges();
        }

        public void Excluir(int id)
        {
            var entidade = SelecionarPorId(id);
            if (entidade != null)
            {
                _contexto.InitTransacao();
                _contexto.Set<TEntidade>().Remove(entidade);
                _contexto.SendChanges();
            }
        }

        public void Excluir(TEntidade entidade)
        {
            _contexto.InitTransacao();
            _contexto.Set<TEntidade>().Remove(entidade);
            _contexto.SendChanges();
        }

        public int Incluir(TEntidade entidade)
        {
            _contexto.InitTransacao();
            var id = _contexto.Set<TEntidade>().Add(entidade).Entity.Id;
            _contexto.SendChanges();
            return id;
        }

        public TEntidade SelecionarPorId(int id)
        {
            return _contexto.Set<TEntidade>().Find(id);
        }

        public IEnumerable<TEntidade> SelecionarTodos()
        {
            return _contexto.Set<TEntidade>().ToList();
        }
    }
}
