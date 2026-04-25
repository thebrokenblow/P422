namespace Lesson5.Model;

public class ProductRepository
{
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
