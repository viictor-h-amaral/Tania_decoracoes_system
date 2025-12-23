using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;
using TaniaDecoracoes.Entities.Data.Contexto;
using TaniaDecoracoes.Entities.Models;
using TaniaDecoracoes.Entities.Models.Attributes;
using TaniaDecoracoes.EntitiesLibrary;
using TaniaDecoracoes.EntitiesLibrary.Interfaces;
using TaniaDecoracoes.WPFLibrary.Utils;
using TaniaDecoracoes.WPFLibrary.Utils.GridUtils;
using TaniaDecoracoes.WPFLibrary.ViewModel.Interfaces;
using TaniaDecoracoes.WPFLibrary.ViewModel.Windows;
using TaniaDecoracoes.WPFLibrary.Windows;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.UserControl
{
    public class CommonDataGridViewModel<T> : ViewModelBase, IGridViewModel where T : class, IEntityModel
    {
        private readonly IEntityBase<T> _entityBase;
        private readonly DbContext _context;
        private Type ElementsType => typeof(T);


        private string? _titulo = "";
        public string? Titulo
        {
            get => _titulo;
            set => SetProperty(ref _titulo, value);
        }

        private IList<T>? _items;
        public IList<T>? Items
        {
            get => _items;
            set
            {
                if (value is not null)
                    SetProperty(ref _items, value);
            }
        }

        private T? _selectedItem;
        public T? SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public int MaxItensPerPage { get; set; }
        
        private int _currentPage = 1;
        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                if (value > 0)
                    _currentPage = value;
                else
                    _currentPage = 1;

                OnPropertyChanged(nameof(TextoPaginacao));
            }
        }

        private readonly int _quantidadeTotalPaginas;
        public string TextoPaginacao => "Página " + CurrentPage + " de " + _quantidadeTotalPaginas;

        #region COMANDOS PERSONALIZADOS

        private ObservableCollection<CustomGridButton> _dataGridTableButtons = [];
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
                Foreground = new SolidColorBrush(Colors.White),
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0271cc")),
                Comando = new RelayCommand(() =>
                {
                    var formVm = new CommonFormViewModel<T>(Titulo, true, _context) as IFormViewModel;

                    var formWindowVM = new FormWindowViewModel(formVm);

                    var formWindow = new FormWindow(formWindowVM);
                    formWindow.ShowDialog();
                    LoadSource();
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

        private void AddColumns(List<DataGridColumn> columns)
        {
            foreach (var column in columns)
            {
                this.AddColumn(column);
            }
            OnPropertyChanged(nameof(DataGridColumns));
        }

            #region ACTION COLUMN

            private void AddActionColumn(DefaultActionButtons defaultButtonsToAdd, List<ActionGridButton>? buttons)
            {
                var cellTemplate = CreateActionButtonsColumnTemplate(defaultButtonsToAdd, buttons);

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

            private DataTemplate? CreateActionButtonsColumnTemplate(DefaultActionButtons defaultButtonsToAdd, List<ActionGridButton>? buttons)
            {
                var factory = new FrameworkElementFactory(typeof(StackPanel));
                factory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
                factory.SetValue(StackPanel.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                factory.SetValue(StackPanel.VerticalAlignmentProperty, VerticalAlignment.Center);

                var buttonsList = new List<FrameworkElementFactory>();

                if (!defaultButtonsToAdd.HasFlag(DefaultActionButtons.None))
                    buttonsList.AddRange(CreateSelectedDefaultActionButtons(defaultButtonsToAdd));
            
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

            private List<FrameworkElementFactory> CreateSelectedDefaultActionButtons(DefaultActionButtons defaultButtonsToAdd)
            {

                var list = new List<FrameworkElementFactory>();

                bool addAll = defaultButtonsToAdd.HasFlag(DefaultActionButtons.All);

                if (addAll || defaultButtonsToAdd.HasFlag(DefaultActionButtons.View))
                {
                    ViewCommand = new RelayCommand<T>(registro =>
                    {
                        var formVm = new CommonFormViewModel<T>(Titulo, FormMode.View, registro.Id, _context, true) as IFormViewModel;

                        var formWindowVM = new FormWindowViewModel(formVm);

                        var formWindow = new FormWindow(formWindowVM);
                        formWindow.ShowDialog();
                    }); 
                    list.Add(ActionGridButton.ViewButton);
                }

                if (addAll || defaultButtonsToAdd.HasFlag(DefaultActionButtons.Edit))
                {
                    EditCommand = new RelayCommand<T>(registro =>
                    {
                        var formVm = new CommonFormViewModel<T>(Titulo, FormMode.Edit, registro.Id, _context, true) as IFormViewModel;

                        var formWindowVM = new FormWindowViewModel(formVm);

                        var formWindow = new FormWindow(formWindowVM);
                        formWindow.ShowDialog();
                        LoadSource();
                    });
                    list.Add(ActionGridButton.EditButton);
                }

                if (addAll || defaultButtonsToAdd.HasFlag(DefaultActionButtons.Delete))
                {
                    DeleteCommand = new RelayCommand<T>(registro =>
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

                        _entityBase.Delete(registro);

                        LoadSource();
                        OnPropertyChanged(nameof(Items));
                    });
                    list.Add(ActionGridButton.DeleteButton);
                }

                return list;
            }

            private void CarregarComandosAvancarEVoltar()
            {
                AvancarCommand = new RelayCommand(() =>
                {
                    int totalRegistrosJaExibidos = (CurrentPage - 1) * MaxItensPerPage + Items.Count;
                    int totalRegistrosDaTabela = _entityBase.Count();

                    bool semRegistrosParaExibir = !(totalRegistrosDaTabela > totalRegistrosJaExibidos);
                    if (semRegistrosParaExibir)
                        return;

                    CurrentPage++;
                    LoadSource();
                });

                VoltarCommand = new RelayCommand(() =>
                {
                    if (CurrentPage <= 1)
                        return;

                    CurrentPage--;
                    LoadSource();
                });
            }
        
        #endregion ACTION COLUMN

        #endregion COLUNAS

        #region COMANDOS

        private ICommand _voltarCommand;
        public ICommand VoltarCommand
        {
            get => _voltarCommand;
            set => SetProperty(ref _voltarCommand, value);
        }

        private ICommand _avancarCommand;
        public ICommand AvancarCommand
        {
            get => _avancarCommand;
            set => SetProperty(ref _avancarCommand, value);
        }

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
            _context = new TaniaDecoracoesDbContext();
            _entityBase = new EntityBase<T>(_context);

            Titulo = configObj.Title;
            MaxItensPerPage = configObj.MaxItensPerPage;
            _quantidadeTotalPaginas = (int)Math.Ceiling((double)_entityBase.Count() / MaxItensPerPage);

            LoadSource();

            if (configObj.AutoGenerateColumns == true) GenerateColumns();

            if (configObj.CustomColumns != null && configObj.CustomColumns.Count != 0)
                AddColumns(configObj.CustomColumns);

            bool hasNOActionButton = configObj.DefaultActionButtonsToAdd.HasFlag(DefaultActionButtons.None) &&
                                        configObj.CustomActionButtons is null;

            if (!hasNOActionButton)
                AddActionColumn(configObj.DefaultActionButtonsToAdd, configObj.CustomActionButtons);

            CarregarComandosAvancarEVoltar();
        }
        
        private void GenerateColumns()
        {
            var properties = ElementsType.GetProperties();

            foreach (var property in properties)
            {
                if (property.GetCustomAttribute<IgnoreOnGridAttribute>() != null)
                    continue;

                string bindingPath = SetBindingPath(property);

                var column = new DataGridTextColumn
                {
                    Header = FormatPropertyLabelHelper.GetPropertyLabel(property),
                    Binding = new Binding(bindingPath),
                    Width = DataGridUnits.GridLengthAuto
                };

                AddColumn(column);
            }
        }

        private string SetBindingPath (PropertyInfo prop)
        {
            string binding = prop.Name;
            if (prop.GetCustomAttribute<BindingAttribute>() != null) binding += "."+prop.GetCustomAttribute<BindingAttribute>()!.FieldToBringFromInstance;

            return binding;
        }

        private void LoadSource()
        {
            try
            {
                var quantidadeItensAtePaginaAnterior = (CurrentPage - 1) * MaxItensPerPage;
                Items = _entityBase
                                .GetManyWithNoTracking()?
                                .Skip(quantidadeItensAtePaginaAnterior)
                                .Take(MaxItensPerPage) as IList<T>;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os dados: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                Items = null;
            }
        }

        #endregion CONSTRUTOR
    }

    public enum DefaultActionButtons
    {
        None = 1,
        Edit = 2,
        Delete = 4,
        View = 8,
        All = 16
    }
}
