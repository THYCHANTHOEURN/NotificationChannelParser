using NotificationChannelParser.Services;

namespace NotificationChannelParser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Notification Channel Parser!");
            Console.WriteLine("Please enter notification title (or 'exit' to quit):");

            INotificationParser parser = new NotificationParser();

            while (true)
            {
                string? input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || input.ToLower() == "exit")
                    break;

                string result = parser.Parse(input);
                Console.WriteLine(result);
                Console.WriteLine("\nEnter another title (or 'exit' to quit):");
            }

            Console.WriteLine("Thank you for using Notification Channel Parser!");
        }
    }
}