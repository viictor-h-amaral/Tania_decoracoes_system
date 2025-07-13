using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.Entities.Models.TabelasGerais;

namespace TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.TabelasGerais
{
    public class GeneroDto
    {
        public GeneroDto()
        {
            
        }
        public GeneroDto(Genero genero)
        {
            this.Id = genero.Id;
            this.Sexo = genero.Sexo;
            this.Letra = genero.Letra;
        }

        public int Id { get; set; }

        public string? Sexo { get; set; }

        public char? Letra { get; set; }
    }
}
