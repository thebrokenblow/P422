using Lesson4.ViewModel;
using System.Windows;

namespace Lesson4;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private CalculateViewModel calculateViewModel = new();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = calculateViewModel;
    }
}