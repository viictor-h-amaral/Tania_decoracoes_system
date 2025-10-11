using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.WPFLibrary.UserControls.EngenhoMenuUserControls;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.UserControl.EngenhoMenu
{
    public class GrupoViewModel : ViewModelBase
    {
        private string titulo = "título";
        public string Titulo
        {
            get => titulo + "     ";
            set => titulo = value;
        }

        private IEnumerable<ItemViewModel> _itens;
        public IEnumerable<ItemViewModel> Itens
        {
            get => _itens;
            set => _itens = value;
        }
    }
}
