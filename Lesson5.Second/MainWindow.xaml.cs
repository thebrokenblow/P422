using System.Windows;

namespace Lesson5.Second;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        listProducts.ItemsSource = GetProduct();
    }

    public static List<Product> GetProduct()
    {
        return
        [
            new() { Id = 1, Name = "Ноутбук", Category = "Электроника", Price = 45000 },
            new() { Id = 2, Name = "Мышь", Category = "Электроника", Price = 1500 },
            new() { Id = 3, Name = "Книга", Category = "Обучение", Price = 800 },
            new() { Id = 4, Name = "Ручка", Category = "Канцтовары", Price = 50 }
        ];
    }
}