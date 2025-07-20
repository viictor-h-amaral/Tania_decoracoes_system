using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using TaniaDecoracoes.WPFLibrary.Utils.Interfaces;

namespace TaniaDecoracoes.WPFLibrary.Utils
{
    public class ActionGridButton : IActionGridButton
    {
        private static readonly ResourceDictionary _resourceDictionary = new ResourceDictionary
        {
            Source = new Uri("pack://application:,,,/TaniaDecoracoes.WPFLibrary;component/Styles/RowGridButtonsStyle.xaml", UriKind.Absolute)
        };


        public static FrameworkElementFactory EditButton
        {
            get
            {
                var foregroundColor = (Color)ColorConverter.ConvertFromString("#2bceff");
                var mouseOverForegroundColor = (Color)ColorConverter.ConvertFromString("#029fcf");
                var rowSelectedForegroundColor = (Color)ColorConverter.ConvertFromString("White");

                return CreateActionButton(
                    "\uf044",
                    foregroundColor,
                    mouseOverForegroundColor,
                    rowSelectedForegroundColor,
                    "DataContext.DeleteCommand",
                    new RelativeSource(RelativeSourceMode.FindAncestor, typeof(DataGrid), 1),
                    "Clique para editar o registro");
            }
        }

        public static FrameworkElementFactory DeleteButton
        {
            get
            {
                var foregroundColor = (Color)ColorConverter.ConvertFromString("#db190b");
                var mouseOverForegroundColor = (Color)ColorConverter.ConvertFromString("#a80b00");
                var rowSelectedForegroundColor = (Color)ColorConverter.ConvertFromString("White");

                return CreateActionButton(
                    "\uf1e2", 
                    foregroundColor,
                    mouseOverForegroundColor,
                    rowSelectedForegroundColor,
                    "DataContext.DeleteCommand", 
                    new RelativeSource(RelativeSourceMode.FindAncestor, typeof(DataGrid), 1),
                    "Clique para excluir permanentemente o registro");
            }
        }

        public static FrameworkElementFactory CreateActionButton(
                string icone, 
                Color foregroundColor,
                Color mouseOverForegroundColor,
                Color rowSelectedForegroundColor,
                string commandName, 
                RelativeSource commandSource,
                string? toolTip = null)
        {
            var button = new FrameworkElementFactory(typeof(Button));

            var baseStyle = (Style)_resourceDictionary["RowGridButton"];

            button.AddHandler(
                FrameworkElement.LoadedEvent,
                new RoutedEventHandler((s, e) =>
                {
                    if (s is Button btn)
                    {
                        btn.Resources["ActionButton.Default.Foreground"] = 
                            new SolidColorBrush(foregroundColor);
                        btn.Resources["ActionButton.MouseOver.Foreground"] =
                            new SolidColorBrush(mouseOverForegroundColor);
                        btn.Resources["ActionButton.SelectedRow.Foreground"] =
                            new SolidColorBrush(rowSelectedForegroundColor);
                    }
                })
            );

            button.SetValue(Button.TagProperty, icone);
            button.SetValue(Button.MarginProperty, new Thickness(2, 0, 2, 0));
            button.SetValue(Button.StyleProperty, baseStyle);

            button.SetValue(Button.CursorProperty, Cursors.Hand);
            button.SetValue(Button.IsHitTestVisibleProperty, true);
            button.SetValue(Button.FocusableProperty, true);
            button.SetValue(Button.ToolTipProperty, toolTip);

            button.SetBinding(Button.CommandProperty, new Binding(commandName)
            {
                RelativeSource = commandSource
            });
            button.SetBinding(Button.CommandParameterProperty, new Binding("."));

            return button;
        }
    }
}
