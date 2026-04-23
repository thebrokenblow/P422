using System.Windows.Input;

namespace Lesson4.ViewModel;

public class RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null) : ICommand
{
    public event EventHandler? CanExecuteChanged;

    public void Execute(object? parameter)
    {
        execute.Invoke(parameter);
    }

    public bool CanExecute(object? parameter)
    {
        return canExecute == null || canExecute.Invoke(parameter);
    }

}