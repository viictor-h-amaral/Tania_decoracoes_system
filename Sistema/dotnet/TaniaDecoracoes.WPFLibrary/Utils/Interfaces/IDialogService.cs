using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.WPFLibrary.Utils.Interfaces
{
    public interface IDialogService
    {
        bool? ShowYesNoDialog(string questionText, string yesButtonText = "Sim", string noButtonText = "Não", bool useAlternativeNoButtonStyle = false);
    }
}
