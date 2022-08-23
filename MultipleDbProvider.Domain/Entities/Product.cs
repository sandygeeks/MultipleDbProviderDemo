namespace MultipleDbProvider.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public Product(string name, double price)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Price = price;
    }
}
