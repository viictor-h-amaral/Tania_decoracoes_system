using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaniaDecoracoes.WPFLibrary.Utils.Interfaces;

namespace TaniaDecoracoes.WPFLibrary.Utils
{
    public class DialogService : IDialogService
    {
        public bool? ShowYesNoDialog(string questionText, string yesButtonText = "Sim", string noButtonText = "Não", bool useAlternativeNoButtonStyle = false)
        {
            var confirmationWindow = new Windows.ConfirmattionWindow();
            confirmationWindow.Configure(questionText, yesButtonText, noButtonText, useAlternativeNoButtonStyle);
            return confirmationWindow.ShowDialog();
        }
    }
}