using System.Diagnostics.Metrics;
using System;

namespace _3_L
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bird bird = new Bird();
            bird.Fly();

            // Här förväntar vi oss att en pingvin ska kunna användas som en fågel
            Bird penguin = new Penguin();
            penguin.Fly(); // Detta kommer att orsaka problem
        }
    }

    // Klass som representerar en allmän fågel
    class Bird
    {
        public virtual void Fly()
        {
            Console.WriteLine("The bird is flying.");
        }
    }

    // Klass som representerar en pingvin men bryter mot LSP
    // Förklaring:
    // Bryter mot LSP: Här har vi en basklass Bird med en metod Fly,
    // som förväntas fungera för alla fåglar.
    // Men när vi introducerar en subklass Penguin som inte kan flyga,
    // bryter vi mot LSP eftersom subklassen inte kan ersätta basklassen
    // utan att orsaka oväntat beteende(i detta fall ett undantag).
    // Resultat: När vi använder en pingvin som en fågel och försöker
    // anropa Fly()-metoden får vi en krasch eller fel,
    // vilket bryter förväntningarna på basklassen.
    // OBS: LÖS DETTA MED INTERFACE
    class Penguin : Bird
    {
        // Pingviner kan inte flyga, vilket bryter mot basklassens förväntningar
        public override void Fly()
        {
            throw new NotSupportedException("Penguins can't fly.");
        }
    }
}