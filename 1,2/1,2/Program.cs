using System;

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int ProductionYear { get; set; }

    public Product(string name, decimal price, int productionYear)
    {
        Name = name;
        Price = price;
        ProductionYear = productionYear;
    }

    // Function 1: Determine how many years ago the product was produced
    public int GetYearsSinceProduction()
    {
        return DateTime.Now.Year - ProductionYear;
    }

    // Function 2: Increase price by 20% if name contains "TV"
    public void IncreasePriceIfTV()
    {
        if (Name.Contains("TV", StringComparison.OrdinalIgnoreCase))
        {
            Price *= 1.20m;
        }
    }

    public override string ToString()
    {
        return $"Наименование: {Name}, Цена: {Price:N2} руб., Год выпуска: {ProductionYear}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create some test products
        Product[] products = new Product[]
        {
            new Product("Samsung TV", 1000m, 2020),
            new Product("Laptop", 800m, 2021),
            new Product("Smart TV LG", 1500m, 2022)
        };

        // Test the functionality for each product
        foreach (var product in products)
        {
            Console.WriteLine("\nИнформация о товаре:");
            Console.WriteLine(product);

            int yearsSinceProduction = product.GetYearsSinceProduction();
            Console.WriteLine($"Лет с момента выпуска: {yearsSinceProduction}");

            product.IncreasePriceIfTV();
            Console.WriteLine("\nИнформация о товаре после проверки цены:");
            Console.WriteLine(product);
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}
