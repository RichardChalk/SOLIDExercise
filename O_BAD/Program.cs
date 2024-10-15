using System;

namespace O_BAD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product book = new Product("Book", 100);
            Product food = new Product("Food", 50);

            DiscountCalculator calculator = new DiscountCalculator();
            Console.WriteLine($"Price after discount for Book: {calculator.ApplyDiscount(book)}");
            Console.WriteLine($"Price after discount for Food: {calculator.ApplyDiscount(food)}");
        }
    }

    // Klass som representerar en produkt
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }

    // Klass som hanterar rabatter, men bryter mot OCP
    // Förklaring:
    // Bryter mot OCP:
    // Varje gång vi vill lägga till en ny produkt,
    // som t.ex. "Clothes", måste vi gå in och ändra i ApplyDiscount-metoden.
    // Det betyder att vi bryter mot OCP eftersom koden inte är "stängd
    // för ändringar" utan måste modifieras varje gång vi utökar systemet
    // med nya produkter.

    // LÖS DETTA MED EN ABSTRACT CLASS
    class DiscountCalculator
    {
        public double ApplyDiscount(Product product)
        {
            // Här måste vi ändra metoden varje gång vi lägger till en ny typ av produkt
            if (product.Name == "Book")
            {
                return product.Price * 0.9; // 10% rabatt för böcker
            }
            else if (product.Name == "Food")
            {
                return product.Price * 0.8; // 20% rabatt för mat
            }
            else
            {
                return product.Price; // Ingen rabatt för andra produkter
            }
        }
    }
}