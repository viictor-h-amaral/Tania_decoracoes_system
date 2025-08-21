using System.Windows.Input;

namespace TaniaDecoracoes.WPFLibrary.Utils
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _acao;
        private readonly Func<T, bool>? _podeExecutar;

        public RelayCommand(Action<T> Acao, Func<T, bool>? PodeExecutar = null)
        {
            _acao = Acao ?? throw new ArgumentNullException(nameof(_acao));
            _podeExecutar = PodeExecutar;
        }

        public bool CanExecute(object? parameter) => _podeExecutar?.Invoke((T)parameter) ?? true;

        public void Execute(object? parameter) => _acao((T)parameter);

        public event EventHandler? CanExecuteChanged;
    }

    public class RelayCommand : ICommand
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
