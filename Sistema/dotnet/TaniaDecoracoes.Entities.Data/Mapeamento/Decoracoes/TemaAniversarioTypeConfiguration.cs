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
    internal class TemaAniversarioTypeConfiguration : IEntityTypeConfiguration<TemaAniversario>
    {
        private TemaAniversarioTabela tabela = new TemaAniversarioTabela();

        public void Configure(EntityTypeBuilder<TemaAniversario> entity)
        {
            entity
                .ToTable(tabela.NameInDataBase);

            #region Propriedades

            entity
                .Property(ta => ta.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(ta => ta.Nome)
                .HasColumnName("Tema")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(ta => ta.Id);

            #endregion Relacionamentos
        }
    }
}