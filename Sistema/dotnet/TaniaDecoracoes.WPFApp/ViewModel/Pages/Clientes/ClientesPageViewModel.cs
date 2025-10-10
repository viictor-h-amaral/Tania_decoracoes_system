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
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl.EngenhoMenu;

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

        private MenuViewModel? _menuVM;
        public MenuViewModel? MenuVM
        {
            get => _menuVM;
            set => SetProperty(ref _menuVM, value);
        }

        public ICommand NavegarParaDependentesClientesCommand { get; }

        public event Action? OnNavegarParaDependentes;

        public ClientesMainPageViewModel()
        {
            NavegarParaDependentesClientesCommand = new RelayCommand<object>(_ =>
            {
                OnNavegarParaDependentes?.Invoke();
            });

            _dbContext = new TaniaDecoracoesDbContext();

            var gridConfig = new GridConfigObject(title: "Clientes",
                                                    readOnly: true,
                                                    autoGenerateColumns: true,
                                                    (DefaultActionButtons.All));

            DataGridVM = new CommonDataGridViewModel<Cliente>(gridConfig) { };
            DataGridVM.AddDefaultTableButtons();

            var menuVm = new MenuViewModel();
            menuVm.Titulo = "Clientes";

            var grupoDependentes = new GrupoViewModel()
            {
                Titulo = "Dependentes de clientes",
                Itens = new List<ItemViewModel>()
                {
                    new ItemViewModel()
                    {
                        Titulo = "Consultar/cadastrar dependente",
                        Comando = NavegarParaDependentesClientesCommand
                    }
                }
            };

            var grupoEnderecos = new GrupoViewModel()
            {
                Titulo = "Endereços de clientes",
                Itens = new List<ItemViewModel>()
                {
                    new ItemViewModel()
                    {
                        Titulo = "Consultar/cadastrar endereço",
                        Comando = NavegarParaDependentesClientesCommand
                    }
                }
            };

            menuVm.Grupos = new List<GrupoViewModel>()
            {
                grupoDependentes, 
                grupoEnderecos,
            };

            MenuVM = menuVm;
        }
    }
}
