using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.Pagamentos;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Pagamentos
{
    public class DecoracaoPagamentoTypeConfiguration : IEntityTypeConfiguration<DecoracaoPagamento>
    {
        public void Configure(EntityTypeBuilder<DecoracaoPagamento> entity)
        {
            entity
                .ToTable("pg_decoracoespagamentos");

            #region Propriedades

            entity
                .Property(dp => dp.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(dp => dp.DecoracaoId)
                .HasColumnName("Decoracao")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(dp => dp.FormaPagamentoEntradaId)
                .HasColumnName("FormaPagamentoEntrada")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(dp => dp.ValorEntrada)
                .HasColumnName("ValorEntrada")
                .HasColumnType("decimal(6,3)")
                .IsRequired();

            entity
                .Property(dp => dp.DataPagamentoEntrada)
                .HasColumnName("DataPagamentoEntrada")
                .HasColumnType("date")
                .IsRequired(false);

            entity
                .Property(dp => dp.FormaPagamentoRestanteId)
                .HasColumnName("FormaPagamentoRestante")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(dp => dp.ValorRestante)
                .HasColumnName("ValorRestante")
                .HasColumnType("decimal(6,3)")
                .IsRequired();

            entity
                .Property(dp => dp.DataPagamentoRestante)
                .HasColumnName("DataPagamentoRestance")
                .HasColumnType("date")
                .IsRequired(false);

            entity
                .Property(dp => dp.ValorParcelaRestante)
                .HasColumnName("ValorParcelaRestante")
                .HasColumnType("decimal(6,3)")
                .IsRequired(false);

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(dp => dp.Id);

            entity
                .HasOne(dp => dp.DecoracaoInstance)
                .WithOne(d => d.DecoracaoPagamentosInstance)
                .HasForeignKey<DecoracaoPagamento>(dp => dp.DecoracaoId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(dp => dp.FormaPagamentoEntradaInstance)
                .WithMany(fp => fp.DecoracoesPagamentosEntradas)
                .HasForeignKey(dp => dp.FormaPagamentoEntradaId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(dp => dp.FormaPagamentoRestanteInstance)
                .WithMany(fp => fp.DecoracoesPagamentosRestante)
                .HasForeignKey(dp => dp.FormaPagamentoRestanteId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion Relacionamentos
        }
    }
}