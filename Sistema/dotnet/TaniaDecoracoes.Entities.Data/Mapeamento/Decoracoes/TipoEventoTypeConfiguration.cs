using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.Associacao.Tabelas;
using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.Entities.Models.Decoracoes.Tabelas;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Decoracoes
{
    internal class TipoEventoTypeConfiguration : IEntityTypeConfiguration<TipoEvento>
    {
        private TipoEventoTabela tabela = new TipoEventoTabela();

        public void Configure(EntityTypeBuilder<TipoEvento> entity)
        {
            entity
                .ToTable(tabela.NameInDataBase);

            #region Propriedades

            entity
                .Property(te => te.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(te => te.Nome)
                .HasColumnName("TipoEvento")
                .HasColumnType("varchar")
                .HasMaxLength(120)
                .IsRequired();


            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(te => te.Id);

            #endregion Relacionamentos
        }
    }
}
