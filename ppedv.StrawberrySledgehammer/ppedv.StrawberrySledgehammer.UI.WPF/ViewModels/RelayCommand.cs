using System;
using System.Diagnostics;
using System.Windows.Input;

namespace ppedv.StrawberrySledgehammer.UI.WPF.ViewModels
{
    public class RelayCommand : ICommand
    {
        #region Fields

        readonly Action<object> execute;
        readonly Predicate<object> canExecute;
        private Func<Action<object>> userWantsToDeleteSelectedInstrument;

        #endregion

        #region Constructors

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public RelayCommand(Func<Action<object>> userWantsToDeleteSelectedInstrument)
        {
            this.userWantsToDeleteSelectedInstrument = userWantsToDeleteSelectedInstrument;
        }
        #endregion

        #region ICommand Members

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        #endregion
    }
}
