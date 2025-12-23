using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TaniaDecoracoes.WPFLibrary.ViewModel.Interfaces;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl.EngenhoFormField;

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
        public required DataTemplate StringTemplate     { get; set; }
        public required DataTemplate IntegerTemplate    { get; set; }
        public required DataTemplate CurrencyTemplate   { get; set; }
        public required DataTemplate DoubleTemplate     { get; set; }
        public required DataTemplate FloatTemplate      { get; set; }
        public required DataTemplate DateTimeTemplate   { get; set; }
        public required DataTemplate DateOnlyTemplate   { get; set; }
        public required DataTemplate BooleanTemplate    { get; set; }
        public required DataTemplate ObjectsTemplate    { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is not IFormFieldViewModel) return base.SelectTemplate(item, container);

            var itemType = item.GetType();
            if (itemType.IsGenericType)
            {
                var genericType = itemType.GetGenericTypeDefinition();

                if (genericType == typeof(FormFieldViewModel<>))
                {
                    var typeArg = itemType.GetGenericArguments()[0];

                    if (typeArg == typeof(string))
                        return StringTemplate;

                    else if (typeArg == typeof(int) || typeArg == typeof(int?))
                        return IntegerTemplate;

                    else if (typeArg == typeof(decimal) || typeArg == typeof(decimal?))
                        return CurrencyTemplate;

                    else if (typeArg == typeof(float) || typeArg == typeof(float?))
                        return FloatTemplate;

                    else if (typeArg == typeof(double) || typeArg == typeof(double?))
                        return DoubleTemplate;

                    else if (typeArg == typeof(DateTime) || typeArg == typeof(DateTime?))
                        return DateTimeTemplate;

                    else if (typeArg == typeof(DateOnly) || typeArg == typeof(DateOnly?))
                        return DateOnlyTemplate;

                    else if (typeArg == typeof(bool) || typeArg == typeof(bool?))
                        return BooleanTemplate;

                    return ObjectsTemplate;
                }
                else if (genericType == typeof(InstanceFormFieldViewModel<>))
                {
                    return ObjectsTemplate;
                }
            }

            return base.SelectTemplate(item, container);
        }
    }
}
