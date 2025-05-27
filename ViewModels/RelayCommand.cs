using System;
using System.Windows.Input;

namespace PDVApp.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _executar;
        private readonly Predicate<object> _podeExecutar;

    public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _executar = executar;
            _podeExecutar = podeExecutar;
        }

        public bool CanExecute(object parameter) => _podeExecutar == null || _podeExecutar(parameter);
        public void Execute(object parameter) => _executar(parameter);
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
