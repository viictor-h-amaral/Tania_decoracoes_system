using System.Windows;
using System.Windows.Input;
using TaniaDecoracoes.Entities.Models.Decoracoes;
using TaniaDecoracoes.WPFApp.WindowsPattern.DialogWindows;

namespace TaniaDecoracoes.WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private bool _isDragging;
        private DateTime _lastClickTime;
        private Point _lastClickPosition;
        private Point _dragStartPosition;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Minimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Maximizar_Click(object sender, RoutedEventArgs e)
        {
            MaximizarNormalizar();
        }

        private void MaximizarNormalizar()
        {
            var window = Window.GetWindow(this);

            window.WindowState = window.WindowState == WindowState.Maximized ?
                WindowState.Normal : WindowState.Maximized;

            btnMaximizar.Content = window.WindowState == WindowState.Maximized ?
                "❐" : "☐";
        }

        private void Fechar_Click(object sender, RoutedEventArgs e)
        {
            FecharAplicacao janelaConfirmacao = new FecharAplicacao(this);
            janelaConfirmacao.ShowDialog();
            if (janelaConfirmacao.Fechar)
                this.Close();
        }

        private void GridControles_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            var window = Window.GetWindow(this);
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

            if (window.WindowState == WindowState.Normal)
            {
                _isDragging = false;
                DragMove();
                e.Handled = true;
                return;
            }
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;
            ((UIElement)sender).ReleaseMouseCapture();
            e.Handled = true;
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {

            if (_isDragging && e.LeftButton == MouseButtonState.Pressed)
            {
                var window = Window.GetWindow(this);

                if (window.WindowState == WindowState.Maximized)
                {
                    var mouseRelativeToScreen = PointToScreen(e.GetPosition(this));
                    var mouseRelativeToWindow = e.GetPosition(window);
                    var widthPercent = mouseRelativeToWindow.X / window.ActualWidth;

                    MaximizarNormalizar();

                    window.Left = mouseRelativeToScreen.X - (window.ActualWidth * widthPercent);
                    window.Top = mouseRelativeToScreen.Y - mouseRelativeToWindow.Y;

                    DragMove();
                }
            }
        }
    }
}