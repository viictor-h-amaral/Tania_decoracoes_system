using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.EntitiesLibrary.Utils
{
    public class Criterio
    {
        public Expression<Func<object, bool>>? PredicadoExpression { get; set; }
        public string WhereClause { get; set; } = string.Empty;

        public Criterio(Expression<Func<object, bool>> predicado)
        {
            PredicadoExpression = predicado;
        }

        public Criterio(string predicado)
        {
            WhereClause = predicado;
        }
    }
}
