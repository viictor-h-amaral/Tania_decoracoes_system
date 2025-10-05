using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.UserControl.EngenhoMenu
{
    public class MenuViewModel : ViewModelBase
    {
        private string _titulo = "Título";
        public string Titulo
        {
            get => _titulo;
            set => _titulo = value;
        }

        private IEnumerable<GrupoViewModel> _grupos;
        public IEnumerable<GrupoViewModel> Grupos
        {
            get => _grupos;
            set => _grupos = value;
        }
    }
}
