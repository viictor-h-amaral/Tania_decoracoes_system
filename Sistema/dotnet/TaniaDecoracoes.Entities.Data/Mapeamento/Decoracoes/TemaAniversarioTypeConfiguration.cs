using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.Decoracoes;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Decoracoes
{
    internal class TemaAniversarioTypeConfiguration : IEntityTypeConfiguration<TemaAniversario>
    {
        public void Configure(EntityTypeBuilder<TemaAniversario> entity)
        {
            entity
                .ToTable("dec_temasaniversarios");

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