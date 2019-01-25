using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ppedv.StrawberrySledgehammer.UI.WPF.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        protected void IHaveChanged([CallerMemberName]string cmb = "")
        {
            if (!string.IsNullOrEmpty(cmb))
                OnPropChanged(cmb);
        }
    }
}
