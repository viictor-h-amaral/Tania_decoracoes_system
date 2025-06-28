using System.Windows;
using System.Windows.Input;
using TaniaDecoracoes.WPFApp.Utils;
using TaniaDecoracoes.WPFApp.WindowsPattern.DialogWindows;

namespace TaniaDecoracoes.WPFApp.WindowsPattern
{
    /// <summary>
    /// Lógica interna para WindowBase.xaml e suas derivadas
    /// </summary>
    public partial class WindowBase : Window
    {
        public WindowBase()
        {
            this.WindowStyle = WindowStyle.None;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            CloseWindowCommand = new RelayCommand(Fechar);
            MinimizeWindowCommand = new RelayCommand(() => this.WindowState = WindowState.Minimized);
            MaximizeNormalizeWindowCommand = new RelayCommand(MaximizarNormalizar);
        }

        #region ControlesJanela
        public ICommand CloseWindowCommand { get; }
        public ICommand MinimizeWindowCommand { get; }
        public ICommand MaximizeNormalizeWindowCommand { get; }

        protected void Fechar()
        {
            FecharAplicacao janelaConfirmacao = new FecharAplicacao(this);
            janelaConfirmacao.ShowDialog();
            if (janelaConfirmacao.Fechar)
                this.Close();
        }

        protected void MaximizarNormalizar()
        {
            this.WindowState = this.WindowState == WindowState.Maximized ?
                WindowState.Normal : WindowState.Maximized;
        }

        public string MaximizeNormalizeButtonContent
        {
            get { return (string)GetValue(MaximizeNormalizeButtonContentProperty); }
            set { SetValue(MaximizeNormalizeButtonContentProperty, value); }
        }

        public static readonly DependencyProperty MaximizeNormalizeButtonContentProperty =
            DependencyProperty.Register("MaximizeNormalizeButtonContent", typeof(string), typeof(WindowBase),
                new PropertyMetadata("☐"));

        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);
            MaximizeNormalizeButtonContent = this.WindowState == WindowState.Maximized ? "❐" : "☐";
        }

        #endregion ControlesJanela

        #region InteracaoJanela

        protected bool _isDragging;
        protected DateTime _lastClickTime;
        protected Point _lastClickPosition;
        protected Point _dragStartPosition;

        protected void GridBarraTarefas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var currentTime = DateTime.Now;
            var currentPosition = e.GetPosition(this);

            if ((currentTime - _lastClickTime).TotalMilliseconds < 300 &&
                (currentPosition - _lastClickPosition).Length < 10)
            {
                MaximizarNormalizar();
                e.Handled = true;
                return;
            }

            _lastClickTime = currentTime;
            _lastClickPosition = currentPosition;
            _dragStartPosition = currentPosition;
            _isDragging = true;

            if (this.WindowState == WindowState.Normal)
            {
                _isDragging = false;
                DragMove();
                e.Handled = true;
                return;
            }
        }

        protected void GridBarraTarefas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;
            ((UIElement)sender).ReleaseMouseCapture();
            e.Handled = true;
        }

        protected void GridBarraTarefas_MouseMove(object sender, MouseEventArgs e)
        {

            if (_isDragging && e.LeftButton == MouseButtonState.Pressed)
            {

                if (this.WindowState == WindowState.Maximized)
                {
                    var mouseRelativeToScreen = PointToScreen(e.GetPosition(this));
                    var mouseRelativeToWindow = e.GetPosition(this);
                    var widthPercent = mouseRelativeToWindow.X / this.ActualWidth;

                    MaximizarNormalizar();

                    this.Left = mouseRelativeToScreen.X - (this.ActualWidth * widthPercent);
                    this.Top = mouseRelativeToScreen.Y - mouseRelativeToWindow.Y;

                    DragMove();
                }
            }
        }

        #endregion InteracaoJanela
    }
}
