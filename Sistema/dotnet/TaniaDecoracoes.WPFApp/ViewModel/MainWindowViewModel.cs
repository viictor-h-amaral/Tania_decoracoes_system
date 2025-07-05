using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TaniaDecoracoes.WPFApp.Pages;
using TaniaDecoracoes.WPFLibrary.Utils;
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

        public Page? ProximaPagina { get; set; }

        private void MudaModulo()
        {
            PaginaAtual = ProximaPagina;
            ProximaPagina = null;
        }

        public ICommand ModuloButton_Click { get; }

        public MainWindowViewModel()
        {
            ModuloButton_Click = new RelayCommand(MudaModulo, () => ProximaPagina is not null);
        }
    }
}
