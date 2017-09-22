using System;
using System.Windows.Input;

namespace JokeDePapa.App.Utils
{
    public class Command : ICommand
    {
        private readonly Func<bool> _canExecuteFunc;
        private readonly Action _execute;

        public Command(Action execute, Func<bool> canExecute = null)
        {
            if (canExecute != null)
                _canExecuteFunc = canExecute;
            else
                _canExecuteFunc = () => true;

            if (execute != null)
                _execute = execute;
            else
                _execute = () => { };
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteFunc.Invoke();
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }

        public event EventHandler CanExecuteChanged;
    }
}