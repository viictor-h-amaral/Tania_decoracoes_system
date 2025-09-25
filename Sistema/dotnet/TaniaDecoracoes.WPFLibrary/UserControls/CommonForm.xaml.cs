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

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is not IFormFieldViewModel) return base.SelectTemplate(item, container);

            // Para tipos genéricos
            if (item.GetType().IsGenericType)
            {
                var genericType = item.GetType().GetGenericTypeDefinition();

                if (genericType == typeof(FormFieldViewModel<>))
                {
                    return StringTemplate ?? throw new Exception("StringTemplate não encontrado.");
                }
                else if (genericType == typeof(InstanceFormFieldViewModel<>))
                {
                    return ObjectsTemplate ?? throw new Exception("ObjectsTemplate não encontrado.");
                }
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
