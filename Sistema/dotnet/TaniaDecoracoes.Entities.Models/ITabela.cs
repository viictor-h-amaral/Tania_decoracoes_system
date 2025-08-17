using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.Entities.Models
{
    public interface ITabela
    {
        string NameInDataBase { get; }
        Type ModelType { get; }
        //class TableFields ;
    }
}
