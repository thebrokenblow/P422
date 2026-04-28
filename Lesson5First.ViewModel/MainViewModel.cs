using Lesson5.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lesson5.ViewModel;

public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<ProductViewModel> Products { get; init; } = [];

    private ProductViewModel _selectedProduct;
    public ProductViewModel SelectedProduct
    {
        get => _selectedProduct;
        set
        {
            _selectedProduct = value;
            OnPropertyChanged();
        }
    }

    public string Name { get; set; }

    public RelayCommand SaveEditedProductCommand { get; set; }
    public RelayCommand DeleteProductCommand { get; set; }

    public MainViewModel()
    {
        DeleteProductCommand = new(DeleteProduct);
        SaveEditedProductCommand = new(SaveEditedProduct);

        var products = ProductRepository.GetProduct();
        GetProductsViewModel(products);
    }

    private void SaveEditedProduct(object? parametr)
    {
        SelectedProduct = null;
    }

    private void DeleteProduct(object? parametr)
    {
        if (parametr is not int id)
        {
            return;
        }

        var product = Products.FirstOrDefault(x => x.Id == id);
        if (product != null)
        {
            Products.Remove(product);
        }
    }

    private void GetProductsViewModel(List<Product> products)
    {
        foreach (var product in products)
        {
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category,
                Price = product.Price,
            };

            Products.Add(productViewModel);
        }
    }

    public void AddProduct()
    {
        
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
