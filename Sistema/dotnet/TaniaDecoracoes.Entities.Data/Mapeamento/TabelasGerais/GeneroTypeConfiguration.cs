using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.Clientes;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.TabelasGerais
{
    internal class GeneroTypeConfiguration : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> entity)
        {
            entity
                .ToTable("ta_generos");


            #region Propriedades

            entity
                .Property(g => g.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(g => g.Sexo)
                .HasColumnName("Sexo")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            entity
                .Property(g => g.Letra)
                .HasColumnName("LetraSexo")
                .HasColumnType("char(1)")
                .IsRequired(false);

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(g => g.Id);

            #endregion Relacionamentos
        }
    }
}