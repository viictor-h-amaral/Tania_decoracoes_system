using System.Collections;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using TaniaDecoracoes.Entities.Data.Contexto;
using TaniaDecoracoes.Entities.Models;
using TaniaDecoracoes.Entities.Models.Attributes;
using TaniaDecoracoes.EntitiesLibrary;
using TaniaDecoracoes.WPFLibrary.Utils;
using TaniaDecoracoes.WPFLibrary.Utils.GridUtils;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.UserControl
{
    public class CommonDataGridViewModel : ViewModelBase
    {
        private object _entityBase;
        private Type ElementsType => TabelaSource.ModelType;


        private string? _titulo = "";
        public string? Titulo
        {
            get => _titulo;
            set => SetProperty(ref _titulo, value);
        }

        private IEnumerable? _items;
        public IEnumerable? Items
        {
            get => _items;
            set 
            {
                if (value is not null)
                    SetProperty(ref _items, value);
                else
                    SetProperty(ref _items, 
                        new ObservableCollection<object>() 
                        { 
                            new { campo = "Nenhum conteúdo a ser exibido." } 
                        });
            }
        }

        private ITabela _tabelaSource;
        public ITabela TabelaSource 
        { 
            get => _tabelaSource;
            set
            {
                if (value != null)
                    SetProperty(ref _tabelaSource, value);
            }
        }


        private object? _selectedItem;
        public object? SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        #region COMANDOS PERSONALIZADOS

        private ObservableCollection<CustomGridButton> _dataGridTableButtons = [

                new CustomGridButton
                {
                    Conteudo = "Novo",
                    Icone = "\u002b",
                    Foreground = Colors.White,
                    MouseOverForeground = Colors.White,
                    PressedForeground = Colors.White,
                    Background = (Color)ColorConverter.ConvertFromString("#28a745"),
                    MouseOverBackground = (Color)ColorConverter.ConvertFromString("#218838"),
                    PressedBackground = (Color)ColorConverter.ConvertFromString("#1e7e34"),
                    Comando = new RelayCommand(() =>
                    {
                        MessageBox.Show("Novo botão clicado!");
                    }),
                    Ordem = 0
                }
            
            ];
        public ObservableCollection<CustomGridButton> DataGridTableButtons
        {
            get => _dataGridTableButtons ??= new ObservableCollection<CustomGridButton>();
            set => SetProperty(ref _dataGridTableButtons, value);
        }

        private void AddTableButton(CustomGridButton button)
        {
            DataGridTableButtons.Add(button);
            OnPropertyChanged(nameof(DataGridTableButtons));
        }

        public void AddTableButtons(params CustomGridButton[] buttons)
        {
            foreach (var button in buttons)
            {
                this.AddTableButton(button);
            }
            OnPropertyChanged(nameof(DataGridTableButtons));
        }

        public void AddDefaultTableButtons()
        {
            var newButton = new CustomGridButton
            {
                Conteudo = "Novo",
                Icone = "\u002b",
                Foreground = Colors.White,
                MouseOverForeground = Colors.White,
                PressedForeground = Colors.White,
                Background = (Color)ColorConverter.ConvertFromString("#28a745"),
                MouseOverBackground = (Color)ColorConverter.ConvertFromString("#218838"),
                PressedBackground = (Color)ColorConverter.ConvertFromString("#1e7e34"),
                Comando = new RelayCommand(() =>
                {
                    MessageBox.Show("Novo botão clicado!");
                }),
                Ordem = 0
            };
            this.AddTableButton(newButton);
            OnPropertyChanged(nameof(DataGridTableButtons));
        }

        #endregion COMANDOS PERSONALIZADOS

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
            var cellTemplate = CreateActionButtonsColumnTemplate(addDefaultButtons, buttons);

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

        private DataTemplate? CreateActionButtonsColumnTemplate(bool addDefaultButtons, params ActionGridButton[]? buttons)
        {
            var factory = new FrameworkElementFactory(typeof(StackPanel));
            factory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            factory.SetValue(StackPanel.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            factory.SetValue(StackPanel.VerticalAlignmentProperty, VerticalAlignment.Center);;

            var buttonsList = new List<FrameworkElementFactory>();

            if (addDefaultButtons)
            {
                CriarComandosDefault();
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

        private void CriarComandosDefault()
        {
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

                var deleteMethod = _entityBase.GetType().GetMethod("Delete");
                deleteMethod?.Invoke(_entityBase, [registro]);

                LoadSource();
                OnPropertyChanged(nameof(Items));
            });

            ViewCommand = new RelayCommand<object>(registro =>
            {
                var idProperty = registro.GetType().GetProperty("Id");
                this.Titulo = $"View command executed: {idProperty.GetValue(registro)}";
            });
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

        public CommonDataGridViewModel(GridConfigObject configObj)
        {
            TabelaSource = configObj.tabelaSource;
            CreateEntityBase();
            Titulo = configObj.Title;
            LoadSource();

            if (configObj.AutoGenerateColumns == true) GenerateColumns();

        }


        private void GenerateColumns()
        {
            var properties = ElementsType.GetProperties();

            foreach (var property in properties)
            {
                if (property.GetCustomAttribute<IgnoreOnGridAttribute>() != null)
                    continue;

                var column = new DataGridTextColumn
                {
                    Header = FormatPropertyLabelHelper.GetPropertyLabel(property),
                    Binding = new Binding(property.Name),
                    Width = DataGridUnits.GridLengthAuto
                };

                AddColumn(column);
            }
        }

        private void LoadSource()
        {
            try
            {
                var getManyMethod = _entityBase.GetType().GetMethod("GetMany");
                Items = getManyMethod?.Invoke(_entityBase, [null]) as IEnumerable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os dados: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                Items = null;
            }
        }

        private void CreateEntityBase()
        {
            var context = new TaniaDecoracoesDbContext();

            var entityBaseType = typeof(EntityBase<>).MakeGenericType(ElementsType);
            var entity = Activator.CreateInstance(entityBaseType, context);

            if (entity == null)
                throw new InvalidOperationException($"Não foi possível criar uma instância de EntityBase para o tipo {entityBaseType} do EntityBase do Grid.");

            _entityBase = entity;
        }

        #endregion CONSTRUTOR
    }
}
