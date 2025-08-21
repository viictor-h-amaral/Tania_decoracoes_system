using System.Windows;
using System.Windows.Controls;
using TaniaDecoracoes.WPFLibrary.Utils.GridUtils;

namespace TaniaDecoracoes.WPFLibrary.UserControls
{
    /// <summary>
    /// Interação lógica para CommonDataGrid.xam
    /// </summary>
    public partial class CommonDataGrid : UserControl
    {
        public CommonDataGrid()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ColumnsSourceProperty =
        DependencyProperty.Register("ColumnsSource",
            typeof(IEnumerable<DataGridColumn>),
            typeof(CommonDataGrid),
            new PropertyMetadata(null, OnColumnsSourceChanged));

        public IEnumerable<DataGridColumn> ColumnsSource
        {
            get => (IEnumerable<DataGridColumn>)GetValue(ColumnsSourceProperty);
            set => SetValue(ColumnsSourceProperty, value);
        }

        private static void OnColumnsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CommonDataGrid control && e.NewValue is IEnumerable<DataGridColumn> columns)
            {
                control.MainGrid.Columns.Clear();
                foreach (var column in columns)
                {
                    control.MainGrid.Columns.Add(column);
                }
            }
        }

    }
}
