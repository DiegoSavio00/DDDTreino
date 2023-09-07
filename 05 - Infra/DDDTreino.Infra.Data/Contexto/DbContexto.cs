using DDDTreino.Dominio.Entidades;
using DDDTreino.Infra.Data.Mapeamentos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DDDTreino.Infra.Data.Contexto
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }
        public IDbContextTransaction Transaction { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new LivroMap());
        }

        public IDbContextTransaction InitTransacao()
        {
            if (Transaction is null)
                Transaction = Database.BeginTransaction();
            return Transaction;
        }

        private void RollBack()
        {
            if (Transaction != null)
                Transaction.Rollback();
        }

        private void Salvar()
        {
            try
            {
                ChangeTracker.DetectChanges();
                SaveChanges();
            }
            catch (Exception ex)
            {
                RollBack();
                throw new Exception(ex.Message);
            }
        }

        private void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        public void SendChanges()
        {
            Salvar();
            Commit();
        }

    }
}
