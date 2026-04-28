using Lesson6.ViewModel;
using System.Windows;

namespace Lesson6;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private MainViewModel mainViewModel = new();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = mainViewModel;

        var someClass = new SomeClass
        {
            Property = 1
        };

        var property = someClass.Property;
    }

    public class SomeClass
    {
        public int Property { get; init; }

        public SomeClass()
        {
            Property = 2;
        }
    }
}