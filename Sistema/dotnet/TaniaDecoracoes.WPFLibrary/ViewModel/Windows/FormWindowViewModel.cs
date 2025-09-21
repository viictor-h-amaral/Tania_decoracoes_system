using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaniaDecoracoes.WPFLibrary.Utils;
using TaniaDecoracoes.WPFLibrary.ViewModel.Interfaces;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.Windows
{
    public class FormWindowViewModel : ViewModelBase
    {
        public event EventHandler RequestClose;
        public ICommand CloseCommand { get; set; }

        private IFormViewModel _formVM;
        public IFormViewModel FormVM
        {
            get => _formVM;
            set => SetProperty(ref _formVM, value);
        }

        public FormWindowViewModel(IFormViewModel formVM)
        {
            CloseCommand = new RelayCommand(() => RequestClose?.Invoke(this, EventArgs.Empty));
            FormVM = formVM;
        }
    }
}
