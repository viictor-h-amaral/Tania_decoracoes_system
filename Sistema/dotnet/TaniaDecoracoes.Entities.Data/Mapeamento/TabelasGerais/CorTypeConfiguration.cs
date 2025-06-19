using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.Itens;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.TabelasGerais
{
    internal class CorTypeConfiguration : IEntityTypeConfiguration<Cor>
    {
        public void Configure(EntityTypeBuilder<Cor> entity)
        {
            entity
                .ToTable("ta_cores");


            #region Propriedades

            entity
                .Property(c => c.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            entity
                .Property(c => c.CodigoHex)
                .HasColumnName("CodigoHex")
                .HasColumnType("char(7)")
                .IsRequired(false);


            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(c => c.Id);

            #endregion Relacionamentos
        }
    }
}