namespace Isthmus.Domain.Entities;

public class Product
{
    private Product(string code, string name, string description, decimal price)
    {
        Code = code;
        Name = name;
        Description = description;
        Price = price;
    }

    public int Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public bool IsActive { get; set; } = true;

    public static Product Create(string code, string name, string description, decimal price)
    {
        return new Product(code, name, description, price);
    }

    public void Update(string code, string name, string description, decimal price)
    {
        Code = code;
        Name = name;
        Description = description;
        Price = price;
        IsActive = true;
    }

    public void Inactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }
}