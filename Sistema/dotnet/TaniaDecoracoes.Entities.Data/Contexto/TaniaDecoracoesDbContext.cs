using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaniaDecoracoes.Entities.Models.Associacao;
using TaniaDecoracoes.Entities.Models.Clientes;
using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.Entities.Models.Enderecos;
using TaniaDecoracoes.Entities.Models.Itens;
using TaniaDecoracoes.Entities.Models.Pagamentos;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.Entities.Data.Contexto
{
    public class TaniaDecoracoesDbContext : DbContext
    {
        public TaniaDecoracoesDbContext()
        {
        }

        public TaniaDecoracoesDbContext(DbContextOptions<TaniaDecoracoesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaniaDecoracoesDbContext).Assembly);
        }

        #region TABELAS

            #region ASSOCIACOES
                public DbSet<AssociacaoDecoracaoFlores> AssociacaoDecoracaoFlores { get; set; }
                public DbSet<AssociacaoDecoracaoItens> AssociacaoDecoracaoItens { get; set; }
        #endregion ASSOCIACOES

            #region CLIENTES
                public DbSet<Cliente> Clientes { get; set; }
                public DbSet<DependenteCliente> DependentesClientes { get; set; }
        #endregion CLIENTES

            #region DECORACOES
                public DbSet<Decoracao> Decoracoes { get; set; }
                public DbSet<TemaAniversario> TemasAniversarios { get; set; }
                public DbSet<TipoEvento> TiposEventos { get; set; }
        #endregion DECORACOES

            #region ENDERECOS
                public DbSet<Estado> Estados { get; set; }
                public DbSet<Municipio> Municipios { get; set; }
                public DbSet<Bairro> Bairros { get; set; }
                public DbSet<Logradouro> Logradouros { get; set; }
                public DbSet<Cep> Ceps { get; set; }
                public DbSet<TipoLogradouro> TiposLogradouros { get; set; }
                public DbSet<EnderecoCliente> EnderecosClientes { get; set; }
                public DbSet<EnderecoEvento> EnderecosEventos { get; set; }
                public DbSet<TipoEnderecoCliente> TiposEnderecosClientes { get; set; }
                public DbSet<TipoEnderecoEvento> TiposEnderecosEventos { get; set; }
        #endregion ENDERECOS

            #region ITENS
                public DbSet<Flor> Flores{ get; set; }
                public DbSet<Item> Itens{ get; set; }
                public DbSet<TipoItem> TiposItens { get; set; }
        #endregion ITENS

            #region DECORACOES
                public DbSet<DecoracaoCustos> DecoracoesCustos { get; set; }
                public DbSet<DecoracaoPagamento> DecoracoesPagamentos { get; set; }
                public DbSet<FormaPagamento> FormasPagamentos { get; set; }
                public DbSet<TaxaParcelamento> TaxasParcelamentos { get; set; }
        #endregion DECORACOES

            #region GERAIS
                public DbSet<Carro> Carros { get; set; }
                public DbSet<Cor> Cores { get; set; }
                public DbSet<CustoCombustivel> CustosCombustiveis { get; set; }
                public DbSet<Genero> Generos { get; set; }
                public DbSet<Tamanho> Tamanhos { get; set; }
                public DbSet<TipoCombustivel> TiposCombustiveis { get; set; }
            #endregion GERAIS

        #endregion TABELAS

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = AppSettings.Configuration.GetConnectionString("DefaultConnection");

                optionsBuilder
                    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                    .EnableDetailedErrors();
            }
        }
    }
}
