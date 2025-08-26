using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.Associacao;
using TaniaDecoracoes.Entities.Models.Associacao.Tabelas;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Associacao
{
    internal class AssociacaoDecoracaoFloresTypeConfiguration : IEntityTypeConfiguration<AssociacaoDecoracaoFlores>
    {
        private AssociacaoDecoracaoFloresTabela tabela = new AssociacaoDecoracaoFloresTabela();

        public void Configure(EntityTypeBuilder<AssociacaoDecoracaoFlores> entity)
        {

            entity
                .ToTable(tabela.NameInDataBase);

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
