using DDDTreino.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDTreino.Infra.Data.Mapeamentos
{
    public class LivroMap : MapBase<Livro>
    {
        public override void Configure(EntityTypeBuilder<Livro> builder)
        {
            base.Configure(builder);
            builder.ToTable("Livro");
            builder.Property(l => l.Nome).IsRequired().HasColumnName("Nome").HasMaxLength(100);
            builder.Property(l => l.Autor).IsRequired().HasColumnName("Autor").HasMaxLength(100);
        }
    }
}
