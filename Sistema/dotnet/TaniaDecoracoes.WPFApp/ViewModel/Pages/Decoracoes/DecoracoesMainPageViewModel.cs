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
        private CommonDataGridViewModel? _dataGridVM;
        public CommonDataGridViewModel? DataGridVM
        {
            get => _dataGridVM;
            set => SetProperty(ref _dataGridVM, value);
        }

        public DecoracoesMainPageViewModel()
        {
            // Inicializa o ViewModel do DataGrid
            var source = TamanhoEntity.GetMany();
            DataGridVM = new CommonDataGridViewModel(itens:source, titulo:"Tamanhos") {};

            DataGridVM.AddColumns(
            new ObservableCollection<DataGridColumn>()
            {
                new DataGridTextColumn
                {
                    Header = "Id",
                    Binding = new Binding("Id"),
                    Width = DataGridUnits.GridLengthAuto //new DataGridLength(1, DataGridLengthUnitType.Star)
                },
                new DataGridTextColumn
                {
                    Header = "Valor",
                    Binding = new Binding("Valor"),
                    Width = DataGridUnits.GridLengthAuto //new DataGridLength(1, DataGridLengthUnitType.Star)
                },
                new DataGridTextColumn
                {
                    Header = "Valor",
                    Binding = new Binding("Valor"),
                    Width = DataGridUnits.GridLengthAuto //new DataGridLength(1, DataGridLengthUnitType.Star)
                },
                new DataGridTextColumn
                {
                    Header = "Valor",
                    Binding = new Binding("Valor"),
                    Width = DataGridUnits.GridLengthAuto //new DataGridLength(1, DataGridLengthUnitType.Star)
                },
                new DataGridTextColumn
                {
                    Header = "Valor",
                    Binding = new Binding("Valor"),
                    Width = DataGridUnits.GridLengthAuto //new DataGridLength(1, DataGridLengthUnitType.Star)
                },
                new DataGridTextColumn
                {
                    Header = "Valor",
                    Binding = new Binding("Valor"),
                    Width = DataGridUnits.GridLengthAuto //new DataGridLength(1, DataGridLengthUnitType.Star)
                },
                new DataGridTextColumn
                {
                    Header = "Valor",
                    Binding = new Binding("Valor"),
                    Width = DataGridUnits.GridLengthAuto //new DataGridLength(1, DataGridLengthUnitType.Star)
                },
                new DataGridTextColumn
                {
                    Header = "Valor",
                    Binding = new Binding("Valor"),
                    Width = DataGridUnits.GridLengthAuto //new DataGridLength(1, DataGridLengthUnitType.Star)
                },
                new DataGridTextColumn
                {
                    Header = "Valor",
                    Binding = new Binding("Valor"),
                    Width = DataGridUnits.GridLengthAuto
                }
            });

            /*DataGridVM.AddColumns(
                new DataGridTextColumn
                {
                    Header = "Id",
                    Binding = new Binding("Id"),
                    Width = DataGridUnits.GridLengthAuto //new DataGridLength(1, DataGridLengthUnitType.Star)
                },
                new DataGridTextColumn
                {
                    Header = "Valor",
                    Binding = new Binding("Valor"),
                    Width = DataGridUnits.GridLengthStars(1) //new DataGridLength(1, DataGridLengthUnitType.Star)
                });*/

            DataGridVM.AddActionColumns();

        }
    }
}
