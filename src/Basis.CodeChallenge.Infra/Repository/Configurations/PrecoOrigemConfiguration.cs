using Basis.CodeChallenge.Domain.Models;
using Basis.CodeChallenge.Domain.Models.Repository;
using Basis.CodeChallenge.Infra.Repository.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Basis.CodeChallenge.Infra.Repository.Configurations
{
    internal class PrecoOrigemConfiguration : IEntityTypeConfiguration<PrecoOrigemDb>
    {
        public void Configure(EntityTypeBuilder<PrecoOrigemDb> builder)
        {
            builder.ToTable("PrecoOrigem");
            builder.HasKey(u => u.CoPo);
            builder.Property(u => u.CoPo).HasColumnType("integer COLLATE BINARY")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.Origem)
                .HasColumnType("varchar COLLATE BINARY")
                .HasMaxLength(100)
            .IsRequired();
            builder.Property(e => e.Valor).IsRequired();

            builder.Property(u => u.DateCreated).HasColumnType("bigint COLLATE BINARY").HasConversion(new UnixDateTimeConverter());

        }
    }
     
}
