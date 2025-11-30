using TaniaDecoracoes.Entities.Models.Enderecos;
using TaniaDecoracoes.WPFLibrary.Utils.GridUtils;
using TaniaDecoracoes.WPFLibrary.ViewModel;
using TaniaDecoracoes.WPFLibrary.ViewModel.Interfaces;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl;

namespace TaniaDecoracoes.WPFApp.ViewModel.Pages.Enderecos
{
    public class EstadosPageViewModel : ViewModelBase
    {
        private IGridViewModel? _dataGridVM;
        public IGridViewModel? DataGridVM
        {
            get => _dataGridVM;
            set => SetProperty(ref _dataGridVM, value);
        }

        public EstadosPageViewModel()
        {
            var gridConfig = new GridConfigObject(title: "Estados",
                                                    readOnly: true,
                                                    autoGenerateColumns: true,
                                                    (DefaultActionButtons.All));

            DataGridVM = new CommonDataGridViewModel<Estado>(gridConfig) { };
            DataGridVM.AddDefaultTableButtons();
        }
    }
}
