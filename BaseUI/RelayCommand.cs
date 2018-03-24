using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace TestApp.BaseUI
{
    public class RelayCommand : ICommand
    {

        private readonly Action<object> _execute = null;
        private readonly Predicate<object> _canExecute = null;

        #region Constructors

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return _canExecute != null ? _canExecute(parameter) : true;
        }

        public void Execute(object parameter)
        {
            if (_execute != null)
                _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion
    }
}
