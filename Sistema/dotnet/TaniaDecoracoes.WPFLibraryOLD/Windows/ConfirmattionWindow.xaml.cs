using TaniaDecoracoes.WPFLibrary.ViewModel.Windows;
using TaniaDecoracoes.WPFLibrary.WindowsPattern;

namespace TaniaDecoracoes.WPFLibrary.Windows
{
    /// <summary>
    /// Lógica interna para ConfirmattionWindow.xaml
    /// </summary>
    public partial class ConfirmattionWindow : YesNoWindowBase
    {
        public ConfirmattionWindow()
        {
            InitializeComponent();

            var viewModel = new YesNoWindowViewModel();
            viewModel.RequestClose += result =>
            {
                this.DialogResult = result;
                this.Close();
            };

            this.DataContext = viewModel;
        }

        public void Configure(string question, string yesText = "Sim", string noText = "Não", bool neutralStyle = false)
        {
            var vm = (YesNoWindowViewModel)DataContext;
            vm.QuestionText = question;
            vm.YesButtonText = yesText;
            vm.NoButtonText = noText;
            vm.UseAlternativeNoButtonStyle = neutralStyle;
        }
    }
}
