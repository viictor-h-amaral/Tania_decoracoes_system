﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.Associacao;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Associacao
{
    internal class AssociacaoDecoracaoFloresTypeConfiguration : IEntityTypeConfiguration<AssociacaoDecoracaoFlores>
    {
        public void Configure(EntityTypeBuilder<AssociacaoDecoracaoFlores> entity)
        {
            entity
                .ToTable("assoc_decoracoes_flores");

            #region Propriedades

            entity
                .Property(a => a.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(a => a.DecoracaoId)
                .HasColumnName("Decoracao")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(a => a.FlorId)
                .HasColumnName("Flor")
                .HasColumnType("integer")
                .IsRequired();

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(a => a.Id);

            entity
                .HasOne(a => a.DecoracaoInstance)
                .WithMany(d => d.AssociacaoDecoracaoFlores)
                .HasForeignKey(a => a.DecoracaoId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(a => a.FlorInstance)
                .WithMany(f => f.AssociacaoDecoracaoFlores)
                .HasForeignKey(a => a.FlorId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion Relacionamentos
        }
    }
}
