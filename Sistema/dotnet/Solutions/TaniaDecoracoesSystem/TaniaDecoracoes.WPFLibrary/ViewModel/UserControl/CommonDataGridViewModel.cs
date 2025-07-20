using System.Collections;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using TaniaDecoracoes.WPFLibrary.Utils;
using TaniaDecoracoes.WPFLibrary.Utils.Interfaces;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.UserControl
{
    public class CommonDataGridViewModel : ViewModelBase
    {
        
        private string? _titulo = "";
        public string? Titulo
        {
            get => _titulo;
            set => SetProperty(ref _titulo, value);
        }

        private IEnumerable _items = new ObservableCollection<object>() { new { campo = "Nenhum conteúdo a ser exibido" } };
        public IEnumerable Items
        {
            get => _items;
            set 
            {
                if (value is not null)
                    SetProperty(ref _items, value); 
            }
        }

        private object? _selectedItem;
        public object? SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        #region COLUNAS

        private ObservableCollection<DataGridColumn> _dataGridColumns = [];
        public ObservableCollection<DataGridColumn> DataGridColumns
        {
            get => _dataGridColumns ??= new ObservableCollection<DataGridColumn>();
            set => SetProperty(ref _dataGridColumns, value);
        }

        private void AddColumn(DataGridColumn column)
        {
            DataGridColumns.Add(column);
            OnPropertyChanged(nameof(DataGridColumns));
        }

        public void AddColumns(ObservableCollection<DataGridColumn> columns)
        {
            foreach (var column in columns) 
            { 
                this.AddColumn(column);
            }
            OnPropertyChanged(nameof(DataGridColumns));
        }

        public void AddColumns(params DataGridColumn[] columns)
        {
            foreach (var column in columns)
            {
                this.AddColumn(column);
            }
            OnPropertyChanged(nameof(DataGridColumns));
        }

        public void AddActionColumns()
        {
            var column = new DataGridTemplateColumn
            {
                Header = "Ações",
                Width = DataGridUnits.GridLengthAuto,
                IsReadOnly = true,
                CellTemplate = CreateActionButtonsTemplate()
            };
            DataGridColumns.Add(column);
            OnPropertyChanged(nameof(DataGridColumns));
        }

        public void AddActionColumns(params DataGridColumn[] buttons)
        {
            var column = new DataGridTemplateColumn
            {
                Header = "Ações",
                Width = DataGridUnits.GridLengthAuto,
                IsReadOnly = true,
                CellTemplate = CreateActionButtonsTemplate()
            };
            DataGridColumns.Add(column);
            OnPropertyChanged(nameof(DataGridColumns));
        }

        private DataTemplate CreateActionButtonsTemplate()
        {
            var factory = new FrameworkElementFactory(typeof(StackPanel));
            factory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            factory.SetValue(StackPanel.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            factory.SetValue(StackPanel.VerticalAlignmentProperty, VerticalAlignment.Center);;

            var editButton = ActionGridButton.EditButton;
            var deleteButton = ActionGridButton.DeleteButton;

            factory.AppendChild(editButton);
            factory.AppendChild(deleteButton);

            return new DataTemplate { VisualTree = factory };
        }

        private DataTemplate CreateActionButtonsTemplate(params IActionGridButton[] buttons)
        {
            ResourceDictionary _resourceDictionary = new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/TaniaDecoracoes.WPFLibrary;component/Styles/RowGridButtonsStyle.xaml", UriKind.Absolute)
            };

            var factory = new FrameworkElementFactory(typeof(StackPanel));
            factory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            factory.SetValue(StackPanel.HorizontalAlignmentProperty, HorizontalAlignment.Center);

            // Botão Editar
            var editButton = new FrameworkElementFactory(typeof(Button));
            editButton.SetValue(Button.TagProperty, "\uf044");
            editButton.SetValue(Button.StyleProperty, (Style)_resourceDictionary["RowGridButton"]);

            editButton.SetValue(Button.CursorProperty, Cursors.Hand);
            editButton.SetValue(Button.IsHitTestVisibleProperty, true);
            editButton.SetValue(Button.FocusableProperty, true);
            editButton.SetBinding(Button.CommandProperty, new Binding("DataContext.EditCommand")
            {
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(DataGrid), 1)
            });
            editButton.SetBinding(Button.CommandParameterProperty, new Binding("."));

            /* Botão Excluir
            var deleteButton = new FrameworkElementFactory(typeof(Button));
            deleteButton.SetValue(Button.ContentProperty, "Excluir");
            //deleteButton.SetValue(Button.StyleProperty, Application.Current.FindResource("ActionButtonStyle"));
            deleteButton.SetValue(Button.MarginProperty, new Thickness(5, 0, 5, 0));
            deleteButton.SetBinding(Button.CommandProperty, new Binding("DataContext.DeleteCommand")
            {
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(DataGrid), 1)
            });
            deleteButton.SetBinding(Button.CommandParameterProperty, new Binding("."));*/

            factory.AppendChild(editButton);
            //factory.AppendChild(deleteButton);

            return new DataTemplate { VisualTree = factory };
        }

        #endregion COLUNAS

        #region COMANDOS

        public ICommand VoltarCommand = new RelayCommand(() =>
        {
            // TODO Implementar lógica de voltar
        });

        public ICommand AvancarCommand = new RelayCommand(() =>
        {
            // TODO Implementar lógica de avancar
        });

        private ICommand _editCommand;
        public ICommand EditCommand
        {
            get => _editCommand;
            set => SetProperty(ref _editCommand, value);
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get => _deleteCommand;
            set => SetProperty(ref _deleteCommand, value);
        }

        #endregion COMANDOS

        #region CONSTRUTORES

        public CommonDataGridViewModel()
        {
            EditCommand = new RelayCommand<object>(registro =>
            {
                var idProperty = registro.GetType().GetProperty("Id");
                this.Titulo = $"Edit command executed: {idProperty.GetValue(registro)}";

            });

            DeleteCommand = new RelayCommand<object>(registro =>
            {
                var valorProperty = registro.GetType().GetProperty("Valor");
                this.Titulo = $"Delete command executed: {valorProperty.GetValue(registro)}";
            });
        }

        public CommonDataGridViewModel(ObservableCollection<DataGridColumn> columns)
        {
            this.AddColumns(columns);
            EditCommand = new RelayCommand<object>(registro =>
            {
                var idProperty = registro.GetType().GetProperty("Id");
                this.Titulo = $"Edit command executed: {idProperty.GetValue(registro)}";

            });

            DeleteCommand = new RelayCommand<object>(registro =>
            {
                var valorProperty = registro.GetType().GetProperty("Valor");
                this.Titulo = $"Delete command executed: {valorProperty.GetValue(registro)}";
            });
        }

        public CommonDataGridViewModel(IEnumerable itens, string titulo)
        {
            Items = itens;
            Titulo = titulo;
            EditCommand = new RelayCommand<object>(registro =>
            {
                var idProperty = registro.GetType().GetProperty("Id");
                this.Titulo = $"Edit command executed: {idProperty.GetValue(registro)}";
            });

            DeleteCommand = new RelayCommand<object>(registro =>
            {
                var valorProperty = registro.GetType().GetProperty("Valor");
                this.Titulo = $"Delete command executed: {valorProperty.GetValue(registro)}";
            });
        }

        public CommonDataGridViewModel(IEnumerable itens, string titulo, ObservableCollection<DataGridColumn> columns)
        {
            Items = itens;
            Titulo = titulo;
            this.AddColumns(columns);
            EditCommand = new RelayCommand<object>(registro =>
            {
                var idProperty = registro.GetType().GetProperty("Id");
                this.Titulo = $"Edit command executed: {idProperty.GetValue(registro)}";
            });

            DeleteCommand = new RelayCommand<object>(registro =>
            {
                var valorProperty = registro.GetType().GetProperty("Valor");
                this.Titulo = $"Delete command executed: {valorProperty.GetValue(registro)}";
            });
        }

        #endregion CONSTRUTORES
    }
}
