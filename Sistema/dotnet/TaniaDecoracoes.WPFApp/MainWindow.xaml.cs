using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TaniaDecoracoes.Entities.Models.Enderecos;

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
            MaximizarMinimizar();
        }

        private void MaximizarMinimizar()
        {
            var window = Window.GetWindow(this);

            window.WindowState = window.WindowState == WindowState.Maximized ?
                WindowState.Normal : WindowState.Maximized;

            ToolBarRow.Height = window.WindowState == WindowState.Maximized ?
                new GridLength(40) : new GridLength(30);

            // Atualiza ícone do botão
            Maximizar.Content = window.WindowState == WindowState.Maximized ?
                "❐" : "☐";
        }

        private void Fechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GridControles_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            var window = Window.GetWindow(this);
            var currentTime = DateTime.Now;
            var currentPosition = e.GetPosition(this);

            // Verificação de duplo clique (300ms é o padrão Windows)
            if ((currentTime - _lastClickTime).TotalMilliseconds < 300 &&
                (currentPosition - _lastClickPosition).Length < 10)
            {
                MaximizarMinimizar();
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
                    // 1. Calcula a posição relativa do mouse na janela maximizada
                    var mouseRelativeToScreen = PointToScreen(e.GetPosition(this));
                    var mouseRelativeToWindow = e.GetPosition(window);
                    var widthPercent = mouseRelativeToWindow.X / window.ActualWidth;

                    // 2. Restaura a janela para o estado normal
                    MaximizarMinimizar();

                    
                    // 3. Reposiciona a janela para manter a posição relativa do mouse
                    window.Left = mouseRelativeToScreen.X - (window.ActualWidth * widthPercent);
                    window.Top = mouseRelativeToScreen.Y - mouseRelativeToWindow.Y;

                    DragMove();
                }
            }
        }
    }
}