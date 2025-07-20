using System.CodeDom;
using System.Collections;
using System.Collections.ObjectModel;
using System.Net.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using TaniaDecoracoes.EntitiesLibrary;
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

        public void AddColumns(params DataGridColumn[] columns)
        {
            foreach (var column in columns)
            {
                this.AddColumn(column);
            }
            OnPropertyChanged(nameof(DataGridColumns));
        }

        public void AddActionColumn(bool addDefaultButtons, params ActionGridButton[]? buttons)
        {
            var cellTemplate = CreateActionButtonsTemplate(addDefaultButtons, buttons);

            if (cellTemplate is null)
                return;

            var column = new DataGridTemplateColumn
            {
                Header = "Ações",
                Width = DataGridUnits.GridLengthAuto,
                IsReadOnly = true,
                CellTemplate = cellTemplate
            };
            DataGridColumns.Add(column);
            OnPropertyChanged(nameof(DataGridColumns));
        }

        private static DataTemplate? CreateActionButtonsTemplate(bool addDefaultButtons, params ActionGridButton[]? buttons)
        {
            var factory = new FrameworkElementFactory(typeof(StackPanel));
            factory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            factory.SetValue(StackPanel.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            factory.SetValue(StackPanel.VerticalAlignmentProperty, VerticalAlignment.Center);;

            var buttonsList = new List<FrameworkElementFactory>();

            if (addDefaultButtons)
            {
                buttonsList.Add(ActionGridButton.EditButton);
                buttonsList.Add(ActionGridButton.DeleteButton);
                buttonsList.Add(ActionGridButton.ViewButton);
            }

            foreach (var button in buttons ?? [])
            {
                var buttonFactory = button.ToFrameworkElement();
                buttonsList.Add(buttonFactory);
            }

            if (buttonsList.Count == 0)
                return null;

            foreach (var buttonFactory in buttonsList)
            {
                factory.AppendChild(buttonFactory);
            }

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

        private ICommand _viewCommand;
        public ICommand ViewCommand
        {
            get => _viewCommand;
            set => SetProperty(ref _viewCommand, value);
        }

        #endregion COMANDOS

        #region CONSTRUTOR

        public CommonDataGridViewModel(IEnumerable itens, string titulo, bool? autoGenerateColumns = true)
        {
            Items = itens;
            Titulo = titulo;

            if (autoGenerateColumns == true)
            {
                // Adiciona colunas automaticamente com base nas propriedades dos itens
                var firstItem = Items.Cast<object>().FirstOrDefault();
                if (firstItem != null)
                {
                    var properties = firstItem.GetType().GetProperties();
                    foreach (var property in properties)
                    {
                        var column = new DataGridTextColumn
                        {
                            Header = property.Name,
                            Binding = new Binding(property.Name),
                            Width = DataGridUnits.GridLengthAuto
                        };
                        AddColumn(column);
                    }
                }
            }

            EditCommand = new RelayCommand<object>(registro =>
            {
                var idProperty = registro.GetType().GetProperty("Id");
                this.Titulo = $"Edit command executed: {idProperty.GetValue(registro)}";
            });

            DeleteCommand = new RelayCommand<object>(registro =>
            {
                var dialogService = new DialogService();
                bool? dialogResult = dialogService.ShowYesNoDialog(
                    questionText: "Apagar o registro?",
                    yesButtonText: "Sim",
                    noButtonText: "Não",
                    useAlternativeNoButtonStyle: false
                );
                if (dialogResult != null && dialogResult == false)
                    return;

                var objectType = registro.GetType();
                var idProperty = objectType.GetProperty("Id");

                var deleteMethod = typeof(EntityBase<>).MakeGenericType(objectType).GetMethod("Delete");

                deleteMethod?.Invoke(null, [registro]);
                OnPropertyChanged(nameof(Items));
            });

            ViewCommand = new RelayCommand<object>(registro =>
            {
                var idProperty = registro.GetType().GetProperty("Id");
                this.Titulo = $"View command executed: {idProperty.GetValue(registro)}";
            });
        }

        #endregion CONSTRUTOR
    }
}
