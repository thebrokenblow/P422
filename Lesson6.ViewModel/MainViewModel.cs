using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lesson6.ViewModel;

public class MainViewModel : INotifyPropertyChanged
{
    private int _countClick;
    public int CountClick 
    {
        get => _countClick;
        set
        {
            _countClick = value;

            //Оповещаем об изменении свойства CountClick. View обнови по братски значение CountClick
            //так как оно сейчас хранит новое значение
            OnPropertyChanged();
        }
    }

    public RelayCommand IncrementCommand { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    public MainViewModel()
    {
        IncrementCommand = new RelayCommand(Increment);
    }

    public void Increment() 
    {
        CountClick++;        
    }

    public void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
