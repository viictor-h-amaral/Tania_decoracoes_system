using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TaniaDecoracoes.WPFLibrary.Utils;

namespace TaniaDecoracoes.WPFLibrary.ViewModel.UserControl
{
    public class CommonDataGridViewModel : ViewModelBase
    {
        private string _titulo = "Não implementado";
        public string Titulo
        {
            get => _titulo;
            set => SetProperty(ref _titulo, value);
        }

        private IEnumerable _items;
        public IEnumerable Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        private object? _selectedItem;
        public object? SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        private ObservableCollection<DataGridColumn> _dataGridColumns = new ObservableCollection<DataGridColumn>();
        public ObservableCollection<DataGridColumn> DataGridColumns
        {
            get => _dataGridColumns ??= new ObservableCollection<DataGridColumn>();
            set => SetProperty(ref _dataGridColumns, value);
        }


        public void AddColumn(DataGridColumn column)
        {
            DataGridColumns.Add(column);
            OnPropertyChanged(nameof(DataGridColumns));
        }

        public ICommand VoltarCommand { get; }
        public ICommand AvancarCommand { get; }

        public CommonDataGridViewModel()
        {
            VoltarCommand = new RelayCommand(() =>
            {
                // Implementar lógica de voltar
                Console.WriteLine("Voltar command executed.");
            });

            AvancarCommand = new RelayCommand(() =>
            {
                // Implementar lógica de voltar
                Console.WriteLine("Voltar command executed.");
            });
        }
    }
}
