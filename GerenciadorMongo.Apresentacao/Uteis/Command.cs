using System;
using System.Windows.Input;

namespace GerenciadorMongo.Apresentacao.Uteis
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action Action { get; set; }
        public string DisplayName { get; set; }
        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                if (CanExecuteChanged != null)
                    CanExecuteChanged(this, EventArgs.Empty);
            }
        }
        public Command(Action action)
        {
            Action = action;
        }
        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }
        public void Execute(object parameter)
        {
            Action?.Invoke();
        }
    }
    public class Command<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action<T> Action { get; set; }
        public string DisplayName { get; set; }
        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public Command(Action<T> action)
        {
            Action = action;
        }
        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }
        public void Execute(object parameter)
        {
            if (Action != null && parameter is T)
                Action((T)parameter);
        }
    }
}
