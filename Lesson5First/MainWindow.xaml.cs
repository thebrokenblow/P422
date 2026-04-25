using Lesson5.ViewModel;
using System.Windows;

namespace Lesson5;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();

        DataContext = new MainViewModel();
    }
}