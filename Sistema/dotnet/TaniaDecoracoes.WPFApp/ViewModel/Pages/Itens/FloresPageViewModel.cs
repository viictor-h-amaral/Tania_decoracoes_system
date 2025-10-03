using TaniaDecoracoes.Entities.Models.Itens;
using TaniaDecoracoes.WPFLibrary.Utils.GridUtils;
using TaniaDecoracoes.WPFLibrary.ViewModel;
using TaniaDecoracoes.WPFLibrary.ViewModel.Interfaces;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl;

namespace TaniaDecoracoes.WPFApp.ViewModel.Pages.Itens
{
    public class FloresPageViewModel : ViewModelBase
    {
        private IGridViewModel? _dataGridVM;
        public IGridViewModel? DataGridVM
        {
            get => _dataGridVM;
            set => SetProperty(ref _dataGridVM, value);
        }
        public FloresPageViewModel()
        {
            var gridConfig = new GridConfigObject(title: "Flores",
                                                    readOnly: true,
                                                    autoGenerateColumns: true,
                                                    (DefaultActionButtons.All));

            DataGridVM = new CommonDataGridViewModel<Item>(gridConfig) { };

            DataGridVM.AddDefaultTableButtons();
        }
    }
}
