using System.IO;

namespace D_GOOD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Dependency Inversion Principle	(DIP)
            // Vi kan enkelt byta ut lagringsmetoden genom att använda ett
            // interface
            IPasswordStore passwordStore = new FileStore();
            PasswordManager passwordManager = new PasswordManager(passwordStore);
            passwordManager.SavePassword("MySecretPassword123");
        }
    }

    // Interface för lösenordslagring
    interface IPasswordStore
    {
        void Save(string password);
    }

    // Klass som hanterar lösenord, nu beroende av ett abstrakt interface
    class PasswordManager
    {
        private readonly IPasswordStore _passwordStore;

        public PasswordManager(IPasswordStore passwordStore)
        {
            _passwordStore = passwordStore;
        }

        public void SavePassword(string password)
        {
            _passwordStore.Save(password);
        }
    }

    // En implementation som sparar lösenord i en fil
    class FileStore : IPasswordStore
    {
        public void Save(string data)
        {
            File.WriteAllText("password.txt", data);
            Console.WriteLine("Password saved to file.");
        }
    }

    // Vi kan enkelt lägga till en annan implementation som sparar lösenord till en databas
    class DatabaseStore : IPasswordStore
    {
        public void Save(string data)
        {
            // Simulerad databaslagring
            Console.WriteLine("Password saved to database.");
        }
    }

}