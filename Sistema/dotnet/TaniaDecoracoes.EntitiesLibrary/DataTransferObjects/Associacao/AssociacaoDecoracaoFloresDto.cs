using TaniaDecoracoes.Entities.Models.Associacao;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.Associacao
{
    public class AssociacaoDecoracaoFloresDto
    {
        public AssociacaoDecoracaoFloresDto()
        {
        }

        public AssociacaoDecoracaoFloresDto(AssociacaoDecoracaoFlores assoc)
        {
            this.Id = assoc.Id;
            this.DecoracaoId = assoc.DecoracaoId;
            this.FlorNome = assoc.FlorInstance.Nome;
        }

        public int Id { get; set; }

        public int DecoracaoId { get; set; }

        public string FlorNome { get; set; }
    }
}
