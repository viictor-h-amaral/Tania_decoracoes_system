using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shell;
using TaniaDecoracoes.WPFLibrary.Utils;

namespace TaniaDecoracoes.WPFLibrary.WindowsPattern
{
    public class FormWindowBase : Window
    {
        public FormWindowBase()
        {
            this.WindowStyle = WindowStyle.None;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            var chrome = new WindowChrome
            {
                CornerRadius = new CornerRadius(20),
                GlassFrameThickness = new Thickness(1),
                ResizeBorderThickness = new Thickness(3),
                CaptionHeight = 0
            };

            WindowChrome.SetWindowChrome(this, chrome);
        }
    }
}
