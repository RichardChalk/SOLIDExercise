namespace L_GOOD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Liskov Substitution Principle	(LSP)
            Bird bird = new Sparrow();
            bird.Eat();

            IFlyable flyingBird = new Sparrow();
            flyingBird.Fly();

            Bird penguin = new Penguin();
            penguin.Eat();
        }
    }

    // Basklass för alla fåglar som hanterar gemensamma funktioner
    // som inte är beroende av flygförmåga
    class Bird
    {
        public void Eat()
        {
            Console.WriteLine("The bird is eating.");
        }
    }

    // Interface för fåglar som kan flyga
    interface IFlyable
    {
        void Fly();
    }

    // En fågel som kan flyga implementerar både Bird och IFlyable
    class Sparrow : Bird, IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("The sparrow is flying.");
        }
    }

    // En pingvin är en fågel, men behöver inte implementera Fly eftersom den inte kan flyga
    class Penguin : Bird
    {
        // Inga Fly-metoder här eftersom pingviner inte kan flyga
    }
}