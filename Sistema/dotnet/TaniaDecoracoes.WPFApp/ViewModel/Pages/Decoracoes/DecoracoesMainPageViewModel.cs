using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using TaniaDecoracoes.Entities.Data.Contexto;
using TaniaDecoracoes.Entities.Models.Itens;
using TaniaDecoracoes.Entities.Models.Itens.Tabelas;
using TaniaDecoracoes.EntitiesLibrary.Entities.Itens;
using TaniaDecoracoes.WPFLibrary.Utils;
using TaniaDecoracoes.WPFLibrary.Utils.GridUtils;
using TaniaDecoracoes.WPFLibrary.ViewModel;
using TaniaDecoracoes.WPFLibrary.ViewModel.Interfaces;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl;

namespace TaniaDecoracoes.WPFApp.ViewModel.Pages.Decoracoes
{
    public class DecoracoesMainPageViewModel : ViewModelBase
    {
        private DbContext _dbContext;

        private IGridViewModel? _dataGridVM;
        public IGridViewModel? DataGridVM
        {
            get => _dataGridVM;
            set => SetProperty(ref _dataGridVM, value);
        }

        public DecoracoesMainPageViewModel()
        {
            NavegarParaTiposEventosCommand = new RelayCommand<object>(_ =>
            {
                // Aqui você pode usar um serviço de navegação ou evento
                OnNavegarParaTiposEventos?.Invoke();
            });

            _dbContext = new TaniaDecoracoesDbContext();

            var tipoItemEntity = new TipoItemEntity(_dbContext);

            var commandSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Page), 1);
            var myButton = new ActionGridButton("\uf1ec",
                                                "Black",
                                                "Green",
                                                "Violet",
                                                "DataContext.MyCommandName",
                                                commandSource);

            var gridConfig = new GridConfigObject(  source: new ItemTabela(),
                                                    title: "Tipos de itens",
                                                    readOnly: true,
                                                    autoGenerateColumns: true,
                                                    (DefaultActionButtons.All)); 

            gridConfig.CustomActionButtons = new List<ActionGridButton>
            {
                myButton
            };
            /*gridConfig.CustomColumns = new List<DataGridColumn>()
            {
                new DataGridTextColumn
                {
                    Header = "Tipo Item",
                    Binding = new Binding("TipoItemInstance.Nome"),
                    Width = DataGridLength.Auto
                }
            };*/

            // Inicializa o ViewModel do DataGrid
            DataGridVM = new CommonDataGridViewModel<Item>(gridConfig) { };

            MyCommandName = new RelayCommand<object>((registro) =>
            {
                var objectType = registro.GetType();
                var idProperty = objectType.GetProperty("Id");

                var dialogService = new DialogService();
                bool? dialogResult = dialogService.ShowYesNoDialog(
                    questionText: $"Apagar o registro de id {idProperty.GetValue(registro)}",
                    yesButtonText: "Sim",
                    noButtonText: "Não",
                    useAlternativeNoButtonStyle: false
                );
            });

            DataGridVM.AddDefaultTableButtons();

        }

        private ICommand _myCommandName;
        public ICommand MyCommandName
        {
            get => _myCommandName;
            set => SetProperty(ref _myCommandName, value);
        }

        // DecoracoesMainPageViewModel.cs
        public ICommand NavegarParaTiposEventosCommand { get; }

        public event Action? OnNavegarParaTiposEventos;

    }
}
