namespace TaniaDecoracoesSystem.Entities.Models.Enderecos
{
    public class Cep
    {
        public int Id { get; set; }

        public required int LogradouroId { get; set; }
        public required Logradouro LogradouroInstance { get; set; }

        public required string CepValor { get; set; }
    }
}
