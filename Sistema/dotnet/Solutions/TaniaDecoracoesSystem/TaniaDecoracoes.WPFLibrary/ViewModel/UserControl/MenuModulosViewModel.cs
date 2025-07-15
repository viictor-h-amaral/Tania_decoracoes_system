using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaniaDecoracoes.WPFLibrary.Utils;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.UserControl
{
    public class MenuModulosViewModel : ViewModelBase
    {
        private string _moduloSelecionado = "_ModuloHome";
        public string ModuloSelecionado
        {
            get => _moduloSelecionado;
            set => SetProperty(ref _moduloSelecionado, value);
        }

        public ICommand SelecionarModuloCommand { get; }
        public MenuModulosViewModel()
        {
            SelecionarModuloCommand = new RelayCommand<string>(modulo => 
            {
                ModuloSelecionado = modulo; 
            });
        }
    }
}
