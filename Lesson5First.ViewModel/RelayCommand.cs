using System.Windows.Input;

namespace Lesson5.ViewModel;

public class RelayCommand : ICommand
{
    private Action<object?> execute;
    private Func<object?, bool>? canExecute;

    public event EventHandler CanExecuteChanged;
    public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        this.execute = execute;
        this.canExecute = canExecute;
    }

    public void Execute(object? parameter)
    {
        execute.Invoke(parameter);
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }
}