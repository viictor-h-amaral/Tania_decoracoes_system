using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
        public DataTemplate StringTemplate { get; set; }
        public DataTemplate BooleanTemplate { get; set; }
        public DataTemplate ObjectsTemplate { get; set; }
        // Adicione templates para outros tipos conforme necessário

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is FormFieldViewModel field)
            {
                if (field.ehInstance)
                    return ObjectsTemplate;
                else if (field.PropertyType == typeof(bool))
                    return BooleanTemplate;
                else
                    return StringTemplate;
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
