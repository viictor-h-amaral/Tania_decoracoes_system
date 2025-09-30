using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TaniaDecoracoes.WPFApp.Pages;
using TaniaDecoracoes.WPFApp.Pages.Clientes;
using TaniaDecoracoes.WPFApp.Pages.Decoracoes;
using TaniaDecoracoes.WPFLibrary.Utils;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl;
using TaniaDecoracoes.WPFLibrary.ViewModel.Windows;

namespace TaniaDecoracoes.WPFApp.ViewModel
{
    internal class MainWindowViewModel : WindowBaseViewModel
    {
        private Page _paginaAtual = new HomePage();
        public Page PaginaAtual
        {
            get => _paginaAtual;
            set => SetProperty(ref _paginaAtual, value); //TODO
        }

        private MenuModulosViewModel _menuModulosVM;
        public MenuModulosViewModel MenuModulosVM
        {
            get => _menuModulosVM;
            set => SetProperty(ref _menuModulosVM, value);
        }
        public MainWindowViewModel()
        {
            MenuModulosVM = new MenuModulosViewModel();

            MenuModulosVM.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(MenuModulosViewModel.ModuloSelecionado))
                {
                    AtualizarPaginaAtual();
                }
            };

            AtualizarPaginaAtual();
        }

        private void AtualizarPaginaAtual()
        {
            switch (MenuModulosVM.ModuloSelecionado)
            {
                case "_ModuloHome":
                    PaginaAtual = new HomePage();
                    break;
                case "_ModuloDecoracoes":
                    PaginaAtual = new DecoracoesMainPage();
                    break;
                case "_ModuloClientes":
                    PaginaAtual = new ClientesMainPage();
                    break;
                default:
                    PaginaAtual = new DefaultTestePage(); // Página padrão
                    break;
            }
        }
    }
}
