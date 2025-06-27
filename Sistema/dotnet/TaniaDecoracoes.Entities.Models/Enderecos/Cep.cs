namespace TaniaDecoracoes.Entities.Models.Enderecos
{
    /// <summary>
    /// Classe referente aos CEPs
    /// </summary>
    public class Cep
    {
        /// <summary>
        /// Retorna o Id do registro no banco de dados
        /// 
        /// Required
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Retorna o Id do registro do logradouro associado ao CEP
        /// 
        /// Required
        /// </summary>
        public int LogradouroId { get; set; }
        /// <summary>
        /// Instância do logradouro associado ao CEP
        /// </summary>
        public required Logradouro LogradouroInstance { get; set; }
        /// <summary>
        /// Retorna o número do CEP
        /// 
        /// Rsequired
        /// </summary>
        public required string CepValor { get; set; }
    }
}
