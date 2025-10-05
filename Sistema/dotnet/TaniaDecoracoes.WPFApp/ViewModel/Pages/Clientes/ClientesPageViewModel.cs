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

        public ICommand NavegarParaTiposEventosCommand { get; }

        public event Action? OnNavegarParaTiposEventos;

        public ClientesMainPageViewModel()
        {
            NavegarParaTiposEventosCommand = new RelayCommand<object>(_ =>
            {
                OnNavegarParaTiposEventos?.Invoke();
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
                Titulo = "Dependentes",
                Itens = new List<ItemViewModel>()
                {
                    new ItemViewModel()
                    {
                        Titulo = "Item 1",
                        SubItens = new List<ItemViewModel>()
                        {
                            new ItemViewModel()
                            {
                                Titulo = "subitem 1"
                            },
                            new ItemViewModel()
                            {
                                Titulo = "subitem 2"
                            }
                        }
                    },
                    new ItemViewModel()
                    {
                        Titulo = "Item 2",
                        SubItens = new List<ItemViewModel>()
                        {
                            new ItemViewModel()
                            {
                                Titulo = "subitem 1"
                            },
                            new ItemViewModel()
                            {
                                Titulo = "subitem 2"
                            },
                            new ItemViewModel()
                            {
                                Titulo = "subitem 3"
                            },
                            new ItemViewModel()
                            {
                                Titulo = "subitem 4"
                            }
                        }
                    }
                }
            };

            var grupoDependentes2 = new GrupoViewModel()
            {
                Titulo = "Dependentes 2",
                Itens = new List<ItemViewModel>()
                {
                    new ItemViewModel()
                    {
                        Titulo = "Item 1",
                        SubItens = new List<ItemViewModel>()
                        {
                            new ItemViewModel()
                            {
                                Titulo = "subitem 1"
                            },
                            new ItemViewModel()
                            {
                                Titulo = "subitem 2"
                            }
                        }
                    },
                    new ItemViewModel()
                    {
                        Titulo = "Item 2",
                        SubItens = new List<ItemViewModel>()
                        {
                            new ItemViewModel()
                            {
                                Titulo = "subitem 1"
                            },
                            new ItemViewModel()
                            {
                                Titulo = "subitem 2"
                            },
                            new ItemViewModel()
                            {
                                Titulo = "subitem 3"
                            },
                            new ItemViewModel()
                            {
                                Titulo = "subitem 4"
                            }
                        }
                    }
                }
            };

            menuVm.Grupos = new List<GrupoViewModel>()
            {
                grupoDependentes,
                grupoDependentes2
            };

            MenuVM = menuVm;
        }
    }
}
