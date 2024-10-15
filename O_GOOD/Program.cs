using System.Diagnostics;

namespace O_GOOD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Open/Closed Principle		(OCP)
            Product book = new Book("Book", 100);
            Product food = new Food("Food", 50);

            Console.WriteLine($"Price after discount for Book: {book.GetPriceWithDiscount()}");
            Console.WriteLine($"Price after discount for Food: {food.GetPriceWithDiscount()}");
        }
    }

    // Interface för produkter
    public abstract class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        // Abstrakt metod för att få pris efter rabatt, vilket gör det möjligt att utöka med nya typer av produkter
        public abstract double GetPriceWithDiscount();
    }

    // Klass för bok-produkter, implementerar rabattlogiken för böcker
    class Book : Product
    {
        public Book(string name, double price) : base(name, price) { }

        public override double GetPriceWithDiscount()
        {
            return Price * 0.9; // 10% rabatt för böcker
        }
    }
    // Klass för mat-produkter, implementerar rabattlogiken för mat
    class Food : Product
    {
        public Food(string name, double price) : base(name, price) { }

        public override double GetPriceWithDiscount()
        {
            return Price * 0.8; // 20% rabatt för mat
        }
    }
}