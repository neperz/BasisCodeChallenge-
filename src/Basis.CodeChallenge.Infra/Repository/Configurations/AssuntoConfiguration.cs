using Basis.CodeChallenge.Domain.Models.Repository;
using Basis.CodeChallenge.Infra.Repository.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basis.CodeChallenge.Infra.Repository.Configurations
{
    internal class AssuntoConfiguration : IEntityTypeConfiguration<AssuntoDb>
    {
        public void Configure(EntityTypeBuilder<AssuntoDb> builder)
        {
            builder.ToTable("Assunto");
            builder.HasKey(u => u.CodAs);
            builder.Property(u => u.CodAs).HasColumnType("integer COLLATE BINARY").IsRequired();
            builder.Property(x => x.Descricao)
                .HasColumnType("varchar COLLATE BINARY")
                .HasMaxLength(40)
            .IsRequired();

            builder.Property(u => u.DateCreated).HasColumnType("bigint COLLATE BINARY").HasConversion(new UnixDateTimeConverter());

        }
    }
     
}
