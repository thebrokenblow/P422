using Lesson4.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lesson4.ViewModel;

public class CalculateViewModel : INotifyPropertyChanged
{
    private string result = string.Empty;
    public string Result 
    {
        get => result;
        set
        {
            result = value;
            OnPropertyChange();
        }
    }

    public string A { get; set; } = string.Empty;
    public string B { get; set; } = string.Empty;

    public RelayCommand AddCommand { get; }

    public CalculateViewModel()
    {
        AddCommand = new(CalculateSum);
    }

    private void CalculateSum(object? parametr)
    {
        var sum = CalculateModel.Sum(A, B);
        Result = sum.ToString();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChange([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}