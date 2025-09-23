using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TaniaDecoracoes.Entities.Models;
using TaniaDecoracoes.WPFLibrary.ViewModel.Interfaces;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl;

namespace TaniaDecoracoes.WPFLibrary.UserControls
{
    /// <summary>
    /// Interação lógica para CommonForm.xam
    /// </summary>
    public partial class CommonForm : UserControl
    {

        public static readonly DependencyProperty ViewModelProperty =
        DependencyProperty.Register("ViewModel", typeof(IFormViewModel), typeof(CommonForm),
            new PropertyMetadata(null, OnViewModelChanged));

        public IFormViewModel ViewModel
        {
            get => (IFormViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        private static void OnViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CommonForm control)
            {
                control.UpdateDataContext();
            }
        }

        private void UpdateDataContext()
        {
            // Mantemos o DataContext como o próprio UserControl para acessar a ViewModel via DP
            // A ViewModel é exposta para binding interno via propriedade
        }

        public CommonForm()
        {
            InitializeComponent();
        }
    }

    public class FieldTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? StringTemplate { get; set; }
        public DataTemplate? BooleanTemplate { get; set; }
        public DataTemplate? ObjectsTemplate { get; set; }
        //public DataTemplate? NumericTemplate { get; set; }
        //public DataTemplate? MonetaryTemplate { get; set; }
        //public DataTemplate? DateTimeTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is not IFormFieldViewModel) return base.SelectTemplate(item, container);

            if (item.GetType().IsGenericType &&
                     item.GetType().GetGenericTypeDefinition() == typeof(FormFieldViewModel<>))
                return StringTemplate;
            /*if (item is FormFieldViewModel<string>)
            {
                return StringTemplate ?? throw new Exception("StringTemplate não encontrado.");
            }
            else if (item is FormFieldViewModel<int>)
            {
                return StringTemplate;//NumericTemplate ?? throw new Exception("NumericTemplate não encontrado.");
            }
            else if (item is FormFieldViewModel<decimal>)
            {
                return StringTemplate;//MonetaryTemplate ?? throw new Exception("MonetaryTemplate não encontrado.");
            }
            else if (item is FormFieldViewModel<bool>)
            {
                return BooleanTemplate ?? throw new Exception("BooleanTemplate não encontrado.");
            }
            else if (item is FormFieldViewModel<DateTime>)
            {
                return StringTemplate;// DateTimeTemplate ?? throw new Exception("DateTimeTemplate não encontrado.");
            }*/
            else if (item.GetType().IsGenericType &&
                     item.GetType().GetGenericTypeDefinition() == typeof(InstanceFormFieldViewModel<>))
            {
                return ObjectsTemplate ?? throw new Exception("ObjectsTemplate(combobox) não encontrado.");
            }

            return base.SelectTemplate(item, container);
        }
    }

    public class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(value is bool && (bool)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
}
