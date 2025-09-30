using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using TaniaDecoracoes.Entities.Data.Contexto;
using TaniaDecoracoes.Entities.Models.Clientes;
using TaniaDecoracoes.Entities.Models.Clientes.Tabelas;
using TaniaDecoracoes.Entities.Models.Itens;
using TaniaDecoracoes.Entities.Models.Itens.Tabelas;
using TaniaDecoracoes.EntitiesLibrary.Entities.Itens;
using TaniaDecoracoes.WPFLibrary.Utils;
using TaniaDecoracoes.WPFLibrary.Utils.GridUtils;
using TaniaDecoracoes.WPFLibrary.ViewModel;
using TaniaDecoracoes.WPFLibrary.ViewModel.Interfaces;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl;

namespace TaniaDecoracoes.WPFApp.ViewModel.Pages.Clientes
{
    public class ClientesMainPageViewModel : ViewModelBase
    {
        private DbContext _dbContext;

        private IGridViewModel? _dataGridVM;
        public IGridViewModel? DataGridVM
        {
            get => _dataGridVM;
            set => SetProperty(ref _dataGridVM, value);
        }

        public ICommand NavegarParaTiposEventosCommand { get; }

        public event Action? OnNavegarParaTiposEventos;

        public ClientesMainPageViewModel()
        {
            NavegarParaTiposEventosCommand = new RelayCommand<object>(_ =>
            {
                OnNavegarParaTiposEventos?.Invoke();
            });

            _dbContext = new TaniaDecoracoesDbContext();

            var gridConfig = new GridConfigObject(source: new ClienteTabela(),
                                                    title: "Clientes",
                                                    readOnly: true,
                                                    autoGenerateColumns: true,
                                                    (DefaultActionButtons.All));

            DataGridVM = new CommonDataGridViewModel<Cliente>(gridConfig) { };
            DataGridVM.AddDefaultTableButtons();
        }
    }
}
