using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using TaniaDecoracoes.Entities.Models.Itens;
using TaniaDecoracoes.EntitiesLibrary;
using TaniaDecoracoes.EntitiesLibrary.DataTransferObjects.TabelasGerais;
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
            var source = TamanhoEntity.GetMany().Select(t => new TamanhoDto(t));
            DataGridVM = new CommonDataGridViewModel(itens:source, titulo:"Tamanhos") {};

            var commandSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Page), 1);

            var myButton = new ActionGridButton("\uf1ec", 
                                                "Black", 
                                                "Green", 
                                                "Violet", 
                                                "DataContext.MyCommandName",
                                                commandSource);

            DataGridVM.AddActionColumn(true, myButton);

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
        }

        private ICommand _myCommandName;
        public ICommand MyCommandName
        {
            get => _myCommandName;
            set => SetProperty(ref _myCommandName, value);
        }

    }
}
