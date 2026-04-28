using System.Windows.Input;

namespace Lesson6.ViewModel;

public class RelayCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;

    private Action _execute;
    public RelayCommand(Action execute)
    {
        _execute = execute;
    }

    public void Execute(object? parameter)
    {
        _execute.Invoke();
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }
}
