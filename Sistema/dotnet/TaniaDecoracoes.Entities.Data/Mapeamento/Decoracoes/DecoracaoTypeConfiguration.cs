using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Data.Mapeamento.Utilitários;
using TaniaDecoracoes.Entities.Models.Associacao.Tabelas;
using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.Entities.Models.Decoracoes.Tabelas;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Decoracoes
{
    internal class DecoracaoTypeConfiguration : IEntityTypeConfiguration<Decoracao>
    {
        private DecoracaoTabela tabela = new DecoracaoTabela();

        public void Configure(EntityTypeBuilder<Decoracao> entity)
        {
            entity
                .ToTable(tabela.NameInDataBase);

            #region Propriedades

            entity
                .Property(d => d.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(d => d.DataCadastro)
                .HasColumnName("DataCadastro")
                .HasColumnType("Date")
                .IsRequired();

            entity
                .Property(d => d.ClienteId)
                .HasColumnName("Cliente")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(d => d.ComemorandoId)
                .HasColumnName("Comemorando")
                .HasColumnType("integer");

            entity
                .Property(d => d.EnderecoEventoId)
                .HasColumnName("EnderecoEvento")
                .HasColumnType("integer");

            entity
                .Property (d => d.TipoEventoId)
                .HasColumnName("TipoEvento")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(d => d.TemaAniversarioId)
                .HasColumnName("TemaAniversario")
                .HasColumnType("integer");

            entity
                .Property(d => d.CarroUtilizadoId)
                .HasColumnName("CarroUtilizado")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(d => d.DistanciaDeCasa)
                .HasColumnName("DistanciaDeCasa")
                .HasColumnType("float");

            entity
                .Property(d => d.ValorSugerido)
                .HasColumnName("ValorSugerido")
                .HasColumnType("decimal(6,3)");

            entity
                .Property(d => d.ValorCobrado)
                .HasColumnName("ValorCobrado")
                .HasColumnType("decimal(6,3)")
                .IsRequired();

            entity
                .Property(d => d.Lucro)
                .HasColumnName("Lucro")
                .HasColumnType("decimal(6,3)");

            entity
                .Property(d => d.DataEvento)
                .HasColumnName("DataEvento")
                .HasColumnType("datetime");

            entity
                .Property(d => d.DataHoraMontagem)
                .HasColumnName("DataHoraMontagem")
                .HasColumnType("datetime");

            entity
                .Property(d => d.PegueEMonte)
                .HasColumnName("PegueEMonte")
                .HasColumnType("tinyint")
                .IsRequired()
                .HasConversion(new TinyIntToBoolConverter());

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(d => d.Id);

            entity
                .HasOne(d => d.ClienteInstance)
                .WithMany(c => c.Decoracoes)
                .HasForeignKey(d => d.ClienteId);

            entity
                .HasOne(d => d.ComemorandoInstance)
                .WithMany(c => c.Decoracoes)
                .HasForeignKey(d => d.ComemorandoId);

            entity
                .HasOne(d => d.TipoEventoInstance)
                .WithMany(t => t.Decoracoes)
                .HasForeignKey(d => d.TipoEventoId);

            entity
                .HasOne(d => d.CarroUtilizadoInstance)
                .WithMany(c => c.Decoracoes)
                .HasForeignKey(d => d.CarroUtilizadoId);

            #endregion Relacionamentos
        }
    }
}
