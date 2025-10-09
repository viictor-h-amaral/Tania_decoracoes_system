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
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl.EngenhoMenu;

namespace TaniaDecoracoes.WPFApp.ViewModel.Pages.Decoracoes
{
    public class DecoracoesMainPageViewModel : ViewModelBase
    {
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

        public DecoracoesMainPageViewModel()
        {
            NavegarParaTiposEventosCommand = new RelayCommand<object>(_ =>
            {
                OnNavegarParaTiposEventos?.Invoke();
            });

            NavegarParaTemasAniversariosCommand = new RelayCommand<object>(_ =>
            {
                OnNavegarParaTemasAniversarios?.Invoke();
            });

            ConfigurarGrid();
            ConfigurarMenu();
            
        }

        private void ConfigurarGrid()
        {
            var gridConfig = new GridConfigObject(title: "Decorações",
                                                    readOnly: true,
                                                    autoGenerateColumns: true,
                                                    (DefaultActionButtons.All));

            DataGridVM = new CommonDataGridViewModel<Decoracao>(gridConfig) { };

            DataGridVM.AddDefaultTableButtons();
        }

        private void ConfigurarMenu()
        {
            var menuVm = new MenuViewModel();
            menuVm.Titulo = "Decorações";
            menuVm.Grupos = new List<GrupoViewModel>()
            {
                new GrupoViewModel()
                {
                    Titulo = "Eventos",
                    Itens = new List<ItemViewModel>()
                    {
                        new ItemViewModel()
                        {
                            Titulo = "Tipos de Eventos",
                            Comando = NavegarParaTiposEventosCommand
                        }
                    }
                },
                new GrupoViewModel()
                {
                    Titulo = "Aniversários",
                    Itens = new List<ItemViewModel>()
                    {
                        new ItemViewModel()
                        {
                            Titulo = "Temas de aniversários",
                            Comando = NavegarParaTemasAniversariosCommand
                        }
                    }
                }
            };

            MenuVM = menuVm;
        }

        public ICommand NavegarParaTiposEventosCommand { get; }

        public event Action? OnNavegarParaTiposEventos;

        public ICommand NavegarParaTemasAniversariosCommand { get; }

        public event Action? OnNavegarParaTemasAniversarios;

    }
}
