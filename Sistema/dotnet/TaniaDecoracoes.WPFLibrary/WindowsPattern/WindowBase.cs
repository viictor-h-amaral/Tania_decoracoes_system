using System.Windows;
using System.Windows.Input;
using System.Windows.Shell;
using TaniaDecoracoes.WPFLibrary.Utils;
using TaniaDecoracoes.WPFLibrary.Windows;

namespace TaniaDecoracoes.WPFLibrary.WindowsPattern
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

            var chrome = new WindowChrome
            {
                CornerRadius = new CornerRadius(20),
                GlassFrameThickness = new Thickness(-1),
                ResizeBorderThickness = new Thickness(15),
                CaptionHeight = 0
            };

            WindowChrome.SetWindowChrome(this, chrome);

        }

        #region InteracaoJanela

        protected bool _isDragging;
        protected DateTime _lastClickTime;
        protected Point _lastClickPosition;
        protected Point _dragStartPosition;

        protected void MaximizarNormalizar()
        {
            this.WindowState = this.WindowState == WindowState.Maximized ?
                WindowState.Normal : WindowState.Maximized;
        }

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