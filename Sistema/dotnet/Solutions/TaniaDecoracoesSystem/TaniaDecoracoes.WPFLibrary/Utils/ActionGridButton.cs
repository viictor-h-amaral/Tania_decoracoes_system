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
        #region PROPRIEDADES

        private string _icone = "\uf5ac";
        public string Icone
        {
            get => _icone;
            set => _icone = value;
        }

        private Color _foregroundColor;
        public Color ForegroundColor
        {
            get => _foregroundColor;
            set => _foregroundColor = value;
        }

        private Color _mouseOverForegroundColor;
        public Color MouseOverForegroundColor
        {
            get => _mouseOverForegroundColor;
            set => _mouseOverForegroundColor = value;
        }

        private Color _rowSelectedForegroundColor = (Color)ColorConverter.ConvertFromString("White");
        public Color RowSelectedForegroundColor
        {
            get => _rowSelectedForegroundColor;
            set => _rowSelectedForegroundColor = value;
        }

        private string _commandName;
        public string CommandName
        {
            get => _commandName;
            set => _commandName = value;
        }

        private RelativeSource _commandSource;
        public RelativeSource CommandSource
        {
            get => _commandSource;
            set => _commandSource = value;
        }

        private string? _toolTip = String.Empty;
        public string? ToolTip
        {
            get => _toolTip;
            set => _toolTip = value;
        }

        #endregion PROPRIEDADES

        public ActionGridButton(string icone, string foregroundColor, string mouseOverForegroundColor, string rowSelectedForegroundColor, string commandName, RelativeSource relativeSource, string? tooltip = null)
        {
            Icone = icone;
            ForegroundColor = (Color)ColorConverter.ConvertFromString(foregroundColor);
            MouseOverForegroundColor = (Color)ColorConverter.ConvertFromString(mouseOverForegroundColor);
            RowSelectedForegroundColor = (Color)ColorConverter.ConvertFromString(rowSelectedForegroundColor);
            CommandName = commandName;
            CommandSource = relativeSource;
            ToolTip = tooltip ?? String.Empty;
        }

        public FrameworkElementFactory ToFrameworkElement()
        {
            return CreateActionButton(
                Icone,
                ForegroundColor,
                MouseOverForegroundColor,
                RowSelectedForegroundColor,
                CommandName,
                CommandSource,
                ToolTip);
        }

        private static readonly ResourceDictionary _resourceDictionary = new ResourceDictionary
        {
            Source = new Uri("pack://application:,,,/TaniaDecoracoes.WPFLibrary;component/Styles/RowGridButtonsStyle.xaml", UriKind.Absolute)
        };

        public static FrameworkElementFactory EditButton
        {
            get
            {
                var foregroundColor = (Color)ColorConverter.ConvertFromString("#1eacd6");
                var mouseOverForegroundColor = (Color)ColorConverter.ConvertFromString("#0893bd");
                var rowSelectedForegroundColor = (Color)ColorConverter.ConvertFromString("#c5effc");

                return CreateActionButton(
                    "\uf044",
                    foregroundColor,
                    mouseOverForegroundColor,
                    rowSelectedForegroundColor,
                    "DataContext.EditCommand",
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
                var rowSelectedForegroundColor = (Color)ColorConverter.ConvertFromString("#ff9d96");

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

        public static FrameworkElementFactory ViewButton
        {
            get
            {
                var foregroundColor = (Color)ColorConverter.ConvertFromString("#920bdb");
                var mouseOverForegroundColor = (Color)ColorConverter.ConvertFromString("#a80b00");
                var rowSelectedForegroundColor = (Color)ColorConverter.ConvertFromString("#ddc5fc");

                return CreateActionButton(
                    "\uf06e",
                    foregroundColor,
                    mouseOverForegroundColor,
                    rowSelectedForegroundColor,
                    "DataContext.ViewCommand",
                    new RelativeSource(RelativeSourceMode.FindAncestor, typeof(DataGrid), 1),
                    "Clique para visualizar detalhadamente o registro");
            }
        }

        public static FrameworkElementFactory CreateActionButton(
                string icone, 
                Color foregroundColor,
                Color mouseOverForegroundColor,
                Color rowSelectedForegroundColor,
                string commandName, 
                RelativeSource commandSource,
                string? toolTip)
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

            if(!string.IsNullOrEmpty(toolTip))
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
