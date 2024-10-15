using System;
using System.IO;

namespace _5_D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PasswordManager passwordManager = new PasswordManager();
            passwordManager.SavePassword("MySecretPassword123");
        }
    }

    // Förklaring:
    // Bryter mot DIP: PasswordManager är direkt beroende av den
    // 'konkreta' klassen FileStore, vilket bryter mot DIP eftersom
    // högre nivåer(som PasswordManager) inte ska vara beroende av
    // konkreta implementationer.
    //
    // Detta gör koden mindre flexibel om vi skulle vilja byta ut
    // sättet att spara lösenord, till exempel till en databas istället
    // för en fil.
    // Resultat: Om vi vill byta sätt att spara lösenord måste vi ändra
    // koden i PasswordManager, vilket gör att programmet blir svårare
    // att underhålla och utöka.
    class PasswordManager
    {
        private FileStore _fileStore;

        public PasswordManager()
        {
            // Programmet är direkt beroende av en konkret klass (FileStore)
            _fileStore = new FileStore();
        }

        public void SavePassword(string password)
        {
            _fileStore.Save(password);
        }
    }

    // Klass som sparar lösenord i en fil
    class FileStore
    {
        public void Save(string data)
        {
            File.WriteAllText("password.txt", data);
            Console.WriteLine("Password saved to file.");
        }
    }
}