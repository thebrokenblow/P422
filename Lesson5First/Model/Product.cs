namespace Lesson5.Model;

public class Product
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required string Category { get; init; }
    public required decimal Price { get; init; }
}