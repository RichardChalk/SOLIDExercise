namespace I_GOOD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Interface Segregation Principle	(ISP)
            MultifunctionalPrinter multifunctionalPrinter = new MultifunctionalPrinter();
            multifunctionalPrinter.Print();
            multifunctionalPrinter.Scan();

            OldPrinter oldPrinter = new OldPrinter();
            oldPrinter.Print();
            // OldPrinter behöver inte implementera Scan längre
        }
    }

    // Ett separat interface för utskrift
    interface IPrinter
    {
        void Print();
    }

    // Ett separat interface för skanning
    interface IScanner
    {
        void Scan();
    }

    // Klass som implementerar både utskrift och skanning
    class MultifunctionalPrinter : IPrinter, IScanner
    {
        public void Print()
        {
            Console.WriteLine("Printing...");
        }

        public void Scan()
        {
            Console.WriteLine("Scanning...");
        }
    }

    // Klass som representerar en gammal skrivare, nu implementerar den bara IPrinter
    class OldPrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Printing...");
        }
    }

}