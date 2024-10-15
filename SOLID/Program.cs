using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;

namespace SOLID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User("John Doe", "john.doe@example.com");
            user.SaveToFile();
        }
    }

    // Explanation:
    // Violation: The User class has two responsibilities:
    // managing user data and saving data to a file.
    // Expected behavior: Each class should have only one responsibility.
    // The file-saving logic should be handled by another class,
    // like a UserRepository (mer om detta senare) or FileManager.
    class User
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        // This method violates the SRP by handling file operations
        public void SaveToFile()
        {
            string filePath = @"user.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Name: {Name}");
                writer.WriteLine($"Email: {Email}");
            }
            Console.WriteLine("User saved to file.");
        }
    }
}