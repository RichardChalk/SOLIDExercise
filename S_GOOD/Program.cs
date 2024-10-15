namespace S_GOOD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Single Responsibility Principle(SRP)
            User user = new User("John Doe", "john.doe@example.com");
            FileManager fileManager = new FileManager();
            fileManager.SaveUserToFile(user);
        }
    }

    // Class that only handles user information
    class User
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }

    // Class that only handles file operations
    class FileManager
    {
        public void SaveUserToFile(User user)
        {
            string filePath = @"user.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Name: {user.Name}");
                writer.WriteLine($"Email: {user.Email}");
            }
            Console.WriteLine("User saved to file.");
        }
    }

}