namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    public class Cep
    {
        public int Id { get; set; }

        public int LogradouroId { get; set; }
        public required Logradouro LogradouroInstance { get; set; }

        public required string CepValor { get; set; }
    }
}
