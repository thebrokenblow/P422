using Lesson5.Model;
using System.Collections.ObjectModel;

namespace Lesson5.ViewModel;

public class MainViewModel
{
    public ObservableCollection<ProductViewModel> Products { get; init; } = [];

    public string Name { get; set; }

    public MainViewModel()
    {
        var products = ProductRepository.GetProduct();
        GetProductsViewModel(products);
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
}
