using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TaniaDecoracoes.WPFLibrary.ViewModel.UserControl;
using TaniaDecoracoes.WPFLibrary.ViewModel.Windows;
using TaniaDecoracoes.WPFLibrary.WindowsPattern;

namespace TaniaDecoracoes.WPFLibrary.Windows
{
    /// <summary>
    /// Lógica interna para FormWindow.xaml
    /// </summary>
    public partial class FormWindow : FormWindowBase
    {
        
        public FormWindow(FormWindowViewModel vm)
        {
            this.DataContext = vm;
            vm.RequestClose += (s, e) => Close();

            InitializeComponent();
        }
    }
}
