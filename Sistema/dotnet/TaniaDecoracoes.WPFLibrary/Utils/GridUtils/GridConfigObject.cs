using System.Windows.Controls;
using TaniaDecoracoes.Entities.Models;
using TaniaDecoracoes.EntitiesLibrary.Utils;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl;

namespace TaniaDecoracoes.WPFLibrary.Utils.GridUtils
{
    public class GridConfigObject
    {
        //public required IEnumerable<object> SourceObjList { get; set; }
        public ITabela tabelaSource { get; set; }

        public string Title { get; set; } = "Título";

        private int maxItensPerPage = 10;
        public int MaxItensPerPage 
        { 
            get => maxItensPerPage;
            set
            {
                if(value > 0)
                    maxItensPerPage = value;
            } 
        }

        public bool IsGridReadOnly { get; set; } = true;
        public bool AutoGenerateColumns { get; set; } = true;

        public DefaultActionButtons DefaultActionButtonsToAdd { get; set; } = DefaultActionButtons.All;

        public List<DataGridColumn>? CustomColumns { get; set; } = null;
        public List<ActionGridButton>? CustomActionButtons { get; set; } = null;
        public Criterio? CriterioSelecao { get; set; }


        public GridConfigObject() { }

        public GridConfigObject(ITabela source,
                                string title, 
                                bool readOnly, 
                                bool autoGenerateColumns,
                                DefaultActionButtons defaultActionButtonsToAdd) 
        { 
            tabelaSource = source;
            Title = title;
            IsGridReadOnly = readOnly;
            AutoGenerateColumns = autoGenerateColumns;
            DefaultActionButtonsToAdd = defaultActionButtonsToAdd;
        }

        public GridConfigObject(ITabela source,
                                Criterio? criterio,
                                string title,
                                bool readOnly,
                                bool autoGenerateColumns,
                                DefaultActionButtons defaultActionButtonsToAdd)
        {
            tabelaSource = source;
            CriterioSelecao = criterio;
            Title = title;
            IsGridReadOnly = readOnly;
            AutoGenerateColumns = autoGenerateColumns;
            DefaultActionButtonsToAdd = defaultActionButtonsToAdd;
        }
    }
}
