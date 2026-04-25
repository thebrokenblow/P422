using System.Collections.ObjectModel;
using System.Windows;

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private List<Product> products = [];
    
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }

    public MainWindow()
    {
        InitializeComponent();
        AddSampleProducts();

        ProductsListBox.ItemsSource = products;
    }

    private void AddSampleProducts()
    {
        products.Add(new Product { Id = 1, Name = "Ноутбук", Category = "Электроника", Price = 45000 });
        products.Add(new Product { Id = 2, Name = "Мышь", Category = "Электроника", Price = 1500 });
        products.Add(new Product { Id = 3, Name = "Книга", Category = "Обучение", Price = 800 });
        products.Add(new Product { Id = 4, Name = "Ручка", Category = "Канцтовары", Price = 50 });
        products.Add(new Product { Id = 4, Name = "Ручка", Category = "Канцтовары", Price = 50 });
        products.Add(new Product { Id = 4, Name = "Ручка", Category = "Канцтовары", Price = 50 });
        products.Add(new Product { Id = 4, Name = "Ручка", Category = "Канцтовары", Price = 50 });
        products.Add(new Product { Id = 4, Name = "Ручка", Category = "Канцтовары", Price = 50 });
        products.Add(new Product { Id = 4, Name = "Ручка", Category = "Канцтовары", Price = 50 });
        products.Add(new Product { Id = 4, Name = "Ручка", Category = "Канцтовары", Price = 50 });
    }
}