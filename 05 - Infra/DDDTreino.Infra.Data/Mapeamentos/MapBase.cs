using DDDTreino.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDTreino.Infra.Data.Mapeamentos
{
    public class MapBase<T> : IEntityTypeConfiguration<T> where T : EntidadeBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).IsRequired().HasColumnName("Id").UseIdentityColumn();
        }
    }
}
