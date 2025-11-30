using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaniaDecoracoes.WPFLibrary.Utils;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl.EngenhoMenu;

namespace TaniaDecoracoes.WPFApp.ViewModel.Pages.Enderecos
{
    public class EnderecosMainPageViewModel
    {
        private MenuViewModel _menuVM;
        public MenuViewModel MenuVM
        {
            get => _menuVM;
            set => _menuVM = value;
        }

        public EnderecosMainPageViewModel()
        {
            #region Inicializar comandos de navegação
            NavegarParaLogradourosCommand = new RelayCommand<object>(_ =>
            {
                OnNavegarParaLogradouros?.Invoke();
            });

            NavegarParaTiposLogradourosCommand = new RelayCommand<object>(_ =>
            {
                OnNavegarParaTiposLogradouros?.Invoke();
            });

            NavegarParaBairrosCommand = new RelayCommand<object>(_ =>
            {
                OnNavegarParaBairros?.Invoke();
            });

            NavegarParaMunicipiosCommand = new RelayCommand<object>(_ =>
            {
                OnNavegarParaMunicipios?.Invoke();
            });

            NavegarParaEstadosCommand = new RelayCommand<object>(_ =>
            {
                OnNavegarParaEstados?.Invoke();
            });

            NavegarParaEnderecosEventosCommand = new RelayCommand<object>(_ =>
            {
                OnNavegarParaEnderecosEventos?.Invoke();
            });

            NavegarParaTiposEnderecosEventosCommand = new RelayCommand<object>(_ =>
            {
                OnNavegarParaTiposEnderecosEventos?.Invoke();
            });

            NavegarParaEnderecosClientesCommand = new RelayCommand<object>(_ =>
            {
                OnNavegarParaEnderecosClientes?.Invoke();
            });

            NavegarParaTiposEnderecosClientesCommand = new RelayCommand<object>(_ =>
            {
                OnNavegarParaTiposEnderecosClientes?.Invoke();
            });
            #endregion Inicializar comandos de navegação

            ConfigurarMenu();
        }

        private void ConfigurarMenu()
        {
            var menuVM = new MenuViewModel();
            menuVM.Titulo = "Endereços";
            
            var grupoCadastro = new GrupoViewModel()
            {
                Titulo = "Cadastrar",
                Itens = new List<ItemViewModel>()
                {
                    new ItemViewModel()
                    {
                        Titulo = "Logradouro",
                        Comando = NavegarParaLogradourosCommand,
                        SubItens = new List<ItemViewModel>()
                        {
                            new ItemViewModel()
                            {
                                Titulo = "Tipos de logradouro",
                                Comando = NavegarParaTiposLogradourosCommand
                            }
                        }
                    },
                    new ItemViewModel()
                    {
                        Titulo = "Bairro",
                        Comando = NavegarParaBairrosCommand
                    },
                    new ItemViewModel()
                    {
                        Titulo = "Município",
                        Comando = NavegarParaMunicipiosCommand
                    },
                    new ItemViewModel()
                    {
                        Titulo = "Estado",
                        Comando = NavegarParaEstadosCommand
                    }
                }
            };

            var grupoEnderecosClientes = new GrupoViewModel()
            {
                Titulo = "Endereços de clientes",
                Itens = new List<ItemViewModel>()
                {
                    new ItemViewModel()
                    {
                        Titulo = "Cadastrar",
                        Comando = NavegarParaEnderecosClientesCommand
                    },
                    new ItemViewModel()
                    {
                        Titulo = "Tipos de endereço",
                        Comando = NavegarParaTiposEnderecosClientesCommand
                    }
                }
            };

            var grupoEnderecosEventos = new GrupoViewModel()
            {
                Titulo = "Endereços de eventos",
                Itens = new List<ItemViewModel>()
                {
                    new ItemViewModel()
                    {
                        Titulo = "Cadastrar",
                        Comando = NavegarParaEnderecosEventosCommand
                    },
                    new ItemViewModel()
                    {
                        Titulo = "Tipos de endereço",
                        Comando = NavegarParaTiposEnderecosEventosCommand
                    }
                }
            };

            menuVM.Grupos = new List<GrupoViewModel>()
            {
                grupoCadastro,
                grupoEnderecosClientes,
                grupoEnderecosEventos
            };

            MenuVM = menuVM;
        }


        #region Comandos de navegação

        public ICommand NavegarParaLogradourosCommand { get; }

        public event Action? OnNavegarParaLogradouros;

        public ICommand NavegarParaTiposLogradourosCommand { get; }

        public event Action? OnNavegarParaTiposLogradouros;

        public ICommand NavegarParaBairrosCommand { get; }

        public event Action? OnNavegarParaBairros;

        public ICommand NavegarParaMunicipiosCommand { get; }

        public event Action? OnNavegarParaMunicipios;

        public ICommand NavegarParaEstadosCommand { get; }

        public event Action? OnNavegarParaEstados;

        public ICommand NavegarParaEnderecosEventosCommand { get; }

        public event Action? OnNavegarParaEnderecosEventos;

        public ICommand NavegarParaTiposEnderecosEventosCommand { get; }

        public event Action? OnNavegarParaTiposEnderecosEventos;

        public ICommand NavegarParaEnderecosClientesCommand { get; }

        public event Action? OnNavegarParaEnderecosClientes;

        public ICommand NavegarParaTiposEnderecosClientesCommand { get; }

        public event Action? OnNavegarParaTiposEnderecosClientes;

        #endregion Comandos de navegação
    }
}
