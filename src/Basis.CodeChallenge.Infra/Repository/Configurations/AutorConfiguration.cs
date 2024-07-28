using Basis.CodeChallenge.Domain.Models;
using Basis.CodeChallenge.Domain.Models.Repository;
using Basis.CodeChallenge.Infra.Repository.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basis.CodeChallenge.Infra.Repository.Configurations
{
    internal class AutorConfiguration : IEntityTypeConfiguration<AutorDb>
    {
        public void Configure(EntityTypeBuilder<AutorDb> builder)
        {
            builder.ToTable("Autor");
            builder.HasKey(u => u.CodAu);
            builder.Property(u => u.CodAu).HasColumnType("integer COLLATE BINARY").IsRequired();
            builder.Property(x => x.Nome)
                .HasColumnType("varchar COLLATE BINARY")
                .HasMaxLength(40)
            .IsRequired();

            builder.Property(u => u.DateCreated).HasColumnType("bigint COLLATE BINARY").HasConversion(new UnixDateTimeConverter());

        }
    }
     
}
