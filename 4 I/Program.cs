using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace _4_I
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MultifunctionalPrinter multifunctionalPrinter = new MultifunctionalPrinter();
            multifunctionalPrinter.Print();
            multifunctionalPrinter.Scan();

            OldPrinter oldPrinter = new OldPrinter();
            oldPrinter.Print();
            // OldPrinter tvingas implementera Scan, trots att den inte kan skanna
            oldPrinter.Scan(); // Detta kommer inte att fungera som förväntat
        }
    }

    // Ett interface som tvingar alla skrivare att implementera alla funktioner
    interface IPrinter
    {
        void Print();
        void Scan();
    }

    // Klass som implementerar alla funktioner
    class MultifunctionalPrinter : IPrinter
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

    // Klass som representerar en gammal skrivare, men tvingas implementera Scan
    class OldPrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Printing...");
        }

        // Förklaring:
        // Bryter mot ISP: Interfacet IPrinter tvingar alla klasser
        // som implementerar det att definiera både Print() och Scan(),
        // även om vissa skrivare, som OldPrinter, inte kan skanna.
        //
        // Detta bryter mot ISP eftersom klasser inte ska behöva
        // implementera metoder de inte använder.
        // Resultat: OldPrinter måste hantera en funktion som den inte
        // kan utföra, vilket leder till dålig design och potentiella
        // problem i koden.
        public void Scan()
        {
            throw new NotSupportedException("Old printers cannot scan.");
        }
    }
}