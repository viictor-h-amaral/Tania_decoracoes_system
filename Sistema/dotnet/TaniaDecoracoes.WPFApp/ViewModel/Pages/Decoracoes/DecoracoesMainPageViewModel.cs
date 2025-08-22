using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using TaniaDecoracoes.Entities.Data.Contexto;
using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.Entities.Models.Itens;
using TaniaDecoracoes.Entities.Models.Itens.Tabelas;
using TaniaDecoracoes.EntitiesLibrary.Entities.Itens;
using TaniaDecoracoes.WPFLibrary.Utils;
using TaniaDecoracoes.WPFLibrary.Utils.GridUtils;
using TaniaDecoracoes.WPFLibrary.ViewModel;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl;

namespace TaniaDecoracoes.WPFApp.ViewModel.Pages.Decoracoes
{
    public class DecoracoesMainPageViewModel : ViewModelBase
    {
        private readonly DbContext _dbContext;

        private CommonDataGridViewModel? _dataGridVM;
        public CommonDataGridViewModel? DataGridVM
        {
            get => _dataGridVM;
            set => SetProperty(ref _dataGridVM, value);
        }

        private CommonFormViewModel? _formVM;
        public CommonFormViewModel? FormVM
        {
            get => _formVM;
            set => SetProperty(ref _formVM, value);
        }

        public DecoracoesMainPageViewModel()
        {
            _dbContext = new TaniaDecoracoesDbContext();

            var tipoItemEntity = new TipoItemEntity(_dbContext);
            var source = tipoItemEntity.GetMany().FirstOrDefault();

            var commandSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Page), 1);
            var myButton = new ActionGridButton("\uf1ec",
                                                "Black",
                                                "Green",
                                                "Violet",
                                                "DataContext.MyCommandName",
                                                commandSource);

            var gridConfig = new GridConfigObject(  source: new ItemTabela(),
                                                    title: "Itens",
                                                    readOnly: true,
                                                    autoGenerateColumns: true,
                                                    (DefaultActionButtons.Delete)); 

            gridConfig.CustomActionButtons = new List<ActionGridButton>
            {
                myButton
            };
            gridConfig.CustomColumns = new List<DataGridColumn>()
            {
                new DataGridTextColumn
                {
                    Header = "Tipo Item",
                    Binding = new Binding("TipoItemInstance.Nome"),
                    Width = DataGridLength.Auto
                }
            };

            // Inicializa o ViewModel do DataGrid
            DataGridVM = new CommonDataGridViewModel(gridConfig) { };
                       

            //DataGridVM.AddActionColumn((DefaultActionButtons.None), myButton);

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
            //Inicializa o ViewModel do Formulário
            FormVM = new CommonFormViewModel(titulo: "Cadastro de decorações", FormMode.View, source, _dbContext, true);
        }

        private ICommand _myCommandName;
        public ICommand MyCommandName
        {
            get => _myCommandName;
            set => SetProperty(ref _myCommandName, value);
        }

    }
}
