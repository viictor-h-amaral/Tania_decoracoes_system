using TaniaDecoracoes.Entities.Models;
using TaniaDecoracoes.EntitiesLibrary.Utils;

namespace TaniaDecoracoes.WPFLibrary.Utils.GridUtils
{
    public class GridConfigObject
    {
        //public required IEnumerable<object> SourceObjList { get; set; }
        public ITabela tabelaSource { get; set; }
        public Criterio? CriterioSelecao { get; set; }

        public string Title { get; set; } = "Título";
        public int MaxItensPerPage { get; set; } = 10;

        public bool IsGridReadOnly { get; set; } = true;
        public bool AutoGenerateColumns { get; set; } = true;

        public GridConfigObject() { }

        public GridConfigObject(ITabela source,
                                Criterio? criterio,
                                string title, 
                                bool readOnly, 
                                bool autoGenerateColumns, 
                                int? maxItensPerPage) 
        { 
            tabelaSource = source;
            CriterioSelecao = criterio;
            Title = title;
            IsGridReadOnly = readOnly;
            AutoGenerateColumns = autoGenerateColumns;

            if (maxItensPerPage.HasValue && maxItensPerPage.Value > 0)
                MaxItensPerPage = maxItensPerPage.Value;
        }
    }
}
