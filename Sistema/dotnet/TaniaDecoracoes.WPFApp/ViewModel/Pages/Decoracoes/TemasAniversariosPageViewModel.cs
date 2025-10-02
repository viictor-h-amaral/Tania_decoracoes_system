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
using TaniaDecoracoes.WPFLibrary.ViewModel.Interfaces;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl;

namespace TaniaDecoracoes.WPFApp.ViewModel.Pages.Decoracoes
{
    public class TemasAniversariosPageViewModel : ViewModelBase
    {

        private IGridViewModel? _dataGridVM;
        public IGridViewModel? DataGridVM
        {
            get => _dataGridVM;
            set => SetProperty(ref _dataGridVM, value);
        }

        public TemasAniversariosPageViewModel()
        {
            var gridConfig = new GridConfigObject(  title: "Temas de aniversários",
                                                    readOnly: true,
                                                    autoGenerateColumns: true,
                                                    (DefaultActionButtons.All)); 

            DataGridVM = new CommonDataGridViewModel<TemaAniversario>(gridConfig) { };

            DataGridVM.AddDefaultTableButtons();
        }

    }
}
