using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaniaDecoracoes.WPFLibrary.Utils.Interfaces
{
    public interface IOnPropertyChanged : INotifyPropertyChanged
    {
        void OnPropertyChanged([CallerMemberName] string? propertyName = null);

        bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null);
    }
}
