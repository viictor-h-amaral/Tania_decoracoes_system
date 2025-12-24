using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.Pagamentos;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Pagamentos
{
    internal class DecoracaoCustoTypeConfiguration : IEntityTypeConfiguration<DecoracaoCustos>
    {
        public void Configure(EntityTypeBuilder<DecoracaoCustos> entity)
        {
            entity
                .ToTable("pg_decoracoescustos");

            #region Propriedades

            entity
                .Property(dc => dc.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(dc => dc.DecoracaoId)
                .HasColumnName("Decoracao")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(dc => dc.CustoCalculado)
                .HasColumnName("CustoCalculado")
                .HasColumnType("decimal(6,3)")
                .IsRequired(false);

            entity
                .Property(dc => dc.CustoFlores)
                .HasColumnName("CustoFlores")
                .HasColumnType("decimal(6,3)")
                .IsRequired(false);

            entity
                .Property(dc => dc.CustoBaloes)
                .HasColumnName("CustoBaloes")
                .HasColumnType("decimal(6,3)")
                .IsRequired(false);

            entity
                .Property(dc => dc.CustoMoveis)
                .HasColumnName("CustoMoveis")
                .HasColumnType("decimal(6,3)")
                .IsRequired(false);

            entity
                .Property(dc => dc.CustosExtras)
                .HasColumnName("CustosExtras")
                .HasColumnType("decimal(6,3)")
                .IsRequired(false);

            entity
                .Property(dc => dc.CustosCombustivel)
                .HasColumnName("CustosCombustivel")
                .HasColumnType("decimal(6,3)")
                .IsRequired();

            entity
                .Property(dc => dc.CustoTotal)
                .HasColumnName("CustoTotal")
                .HasColumnType("decimal(6,3)")
                .IsRequired();

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(dc => dc.Id);

            entity
                .HasOne(dc => dc.DecoracaoInstance)
                .WithMany(d => d.DecoracaoCustos)
                .HasForeignKey(dc => dc.DecoracaoId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion Relacionamentos
        }
    }
}
