using System;

namespace LoginAttemptAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginAnalyzer analyzer = new LoginAnalyzer();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n================================");
                Console.WriteLine("      LOGIN ATTEMPT ANALYZER");
                Console.WriteLine("================================");
                Console.WriteLine("1. Add login attempt");
                Console.WriteLine("2. View all attempts");
                Console.WriteLine("3. View failed attempts");
                Console.WriteLine("4. View security summary");
                Console.WriteLine("5. Check user risk");
                Console.WriteLine("6. Exit");
                Console.Write("\nChoose an option: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    analyzer.AddLoginAttempt();
                }
                else if (choice == "2")
                {
                    analyzer.ViewAllAttempts();
                }
                else if (choice == "3")
                {
                    analyzer.ViewFailedAttempts();
                }
                else if (choice == "4")
                {
                    analyzer.ViewSecuritySummary();
                }
                else if (choice == "5")
                {
                    analyzer.CheckUserRisk();
                }
                else if (choice == "6")
                {
                    running = false;
                    Console.WriteLine("Exiting Login Attempt Analyzer.");
                }
                else
                {
                    Console.WriteLine("Invalid option. Please choose 1 through 6.");
                }
            }
        }
    }
}