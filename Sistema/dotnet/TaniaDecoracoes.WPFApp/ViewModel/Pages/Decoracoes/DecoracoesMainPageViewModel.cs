using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using TaniaDecoracoes.EntitiesLibrary.Entities.TabelasGerais;
using TaniaDecoracoes.WPFLibrary.Utils;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl;

namespace TaniaDecoracoes.WPFApp.ViewModel.Pages.Decoracoes
{
    public class DecoracoesMainPageViewModel : ViewModelBase
    {
        private CommonDataGridViewModel _dataGridVM;
        public CommonDataGridViewModel DataGridVM
        {
            get => _dataGridVM;
            set => SetProperty(ref _dataGridVM, value);
        }

        public DecoracoesMainPageViewModel()
        {
            // Inicializa o ViewModel do DataGrid
            DataGridVM = new CommonDataGridViewModel
            {
                Titulo = "Lista de Tamanhos",
                Items = TamanhoEntity.GetMany().ToList()
            };

            

            DataGridVM.DataGridColumns.Add(
            new DataGridTextColumn
            {
                Header = "Id",
                Binding = new Binding("Id"),
                Width = DataGridColumnsUnits.GridLengthStars(1) //new DataGridLength(1, DataGridLengthUnitType.Star)
            });

            DataGridVM.DataGridColumns.Add(
            new DataGridTextColumn
            {
                Header = "Valor",
                Binding = new Binding("Valor"),
                Width = DataGridColumnsUnits.GridLengthStars(2) //new DataGridLength(1, DataGridLengthUnitType.Star)
            });
        }
    }
}
