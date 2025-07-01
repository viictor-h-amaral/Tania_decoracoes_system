using System.Windows.Input;

namespace TaniaDecoracoes.WPFLibrary.Utils
{
    internal class RelayCommand : ICommand
    {
        private readonly Action _acao;
        private readonly Func<bool>? _podeExecutar;

        public RelayCommand(Action Acao, Func<bool>? PodeExecutar = null)
        {
            _acao = Acao ?? throw new ArgumentNullException(nameof(_acao));
            _podeExecutar = PodeExecutar;
        }

        public bool CanExecute(object? parameter) => _podeExecutar?.Invoke() ?? true;

        public void Execute(object? parameter) => _acao();

        public event EventHandler? CanExecuteChanged;
    }
}
