using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaniaDecoracoes.Entities.Models.Clientes;

namespace TaniaDecoracoes.Entities.Data.Mapeamento.Clientes
{
    internal class ClienteTypeConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> entity)
        {
            entity
                .ToTable("cl_clientes");

            #region Propriedades

            entity
                .Property(c => c.Id)
                .HasColumnName("Id")
                .HasColumnType("integer")
                .ValueGeneratedOnAdd();

            entity
                .Property(c => c.DataCadastro)
                .HasColumnName("DataCadastro")
                .HasColumnType("Date")
                .IsRequired();

            entity
                .Property(c => c.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(80)")
                .HasMaxLength(80)
                .IsRequired();

            entity
                .Property(c => c.Apelido)
                .HasColumnName("Apelido")
                .HasColumnType("varchar(120)")
                .HasMaxLength(120);

            entity
                .Property(c => c.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("Date");

            entity
                .Property(c => c.GeneroId)
                .HasColumnName("Genero")
                .HasColumnType("integer");

            entity
                .Property(c => c.EnderecoClienteId)
                .HasColumnName("Endereco")
                .HasColumnType("integer")
                .IsRequired();

            entity
                .Property(c => c.TelefoneCelular)
                .HasColumnName("TelefoneCelular")
                .HasColumnType("char(11)")
                .IsRequired();

            entity
                .Property(c => c.Cpf)
                .HasColumnName("Cpf")
                .HasColumnType("char(11)");

            #endregion Propriedades

            #region Relacionamentos

            entity
                .HasKey(c => c.Id);

            entity
                .HasOne(c => c.GeneroInstance)
                .WithMany(g => g.Clientes)
                .HasForeignKey(c => c.GeneroId);

            entity
                .HasOne(c => c.EnderecoClienteInstance)
                .WithMany(e => e.Clientes)
                .HasForeignKey(c => c.EnderecoClienteId);

            #endregion Relacionamentos
        }
    }
}
