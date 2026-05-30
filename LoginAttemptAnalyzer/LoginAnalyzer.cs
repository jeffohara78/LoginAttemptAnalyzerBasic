using System;
using System.Collections.Generic;

namespace LoginAttemptAnalyzer
{
    // Handles adding login attempts and analyzing suspicious activity.
    public class LoginAnalyzer
    {
        private List<LoginAttempt> attempts = new List<LoginAttempt>();

        public void AddLoginAttempt()
        {
            Console.WriteLine("\n=== Add Login Attempt ===");
            Console.WriteLine("Use this to simulate a login event.");
            Console.WriteLine("Example username: jsmith, admin, analyst1\n");

            Console.Write("Username: ");
            string username = Console.ReadLine();

            bool wasSuccessful = GetLoginResult();

            LoginAttempt attempt = new LoginAttempt(username, wasSuccessful);

            attempts.Add(attempt);

            Console.WriteLine("Login attempt added.");
        }

        public void ViewAllAttempts()
        {
            Console.WriteLine("\n=== All Login Attempts ===");

            if (attempts.Count == 0)
            {
                Console.WriteLine("No login attempts have been added yet.");
                return;
            }

            foreach (LoginAttempt attempt in attempts)
            {
                DisplayAttempt(attempt);
            }
        }

        public void ViewFailedAttempts()
        {
            Console.WriteLine("\n=== Failed Login Attempts ===");

            bool found = false;

            foreach (LoginAttempt attempt in attempts)
            {
                if (!attempt.WasSuccessful)
                {
                    DisplayAttempt(attempt);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No failed login attempts found.");
            }
        }

        public void ViewSecuritySummary()
        {
            Console.WriteLine("\n=== Security Summary ===");

            int successfulCount = 0;
            int failedCount = 0;

            foreach (LoginAttempt attempt in attempts)
            {
                if (attempt.WasSuccessful)
                {
                    successfulCount++;
                }
                else
                {
                    failedCount++;
                }
            }

            Console.WriteLine($"Total Attempts: {attempts.Count}");
            Console.WriteLine($"Successful Attempts: {successfulCount}");
            Console.WriteLine($"Failed Attempts: {failedCount}");

            if (failedCount >= 5)
            {
                Console.WriteLine("Alert: High number of failed login attempts detected.");
            }
            else if (failedCount >= 3)
            {
                Console.WriteLine("Warning: Multiple failed login attempts detected.");
            }
            else
            {
                Console.WriteLine("Status: Login activity appears normal.");
            }
        }

        public void CheckUserRisk()
        {
            Console.WriteLine("\n=== Check User Risk ===");
            Console.Write("Enter username to review: ");

            string username = Console.ReadLine().ToLower();

            int failedCount = 0;
            int successfulCount = 0;

            foreach (LoginAttempt attempt in attempts)
            {
                if (attempt.Username.ToLower() == username)
                {
                    if (attempt.WasSuccessful)
                    {
                        successfulCount++;
                    }
                    else
                    {
                        failedCount++;
                    }
                }
            }

            Console.WriteLine($"\nUser: {username}");
            Console.WriteLine($"Successful Attempts: {successfulCount}");
            Console.WriteLine($"Failed Attempts: {failedCount}");

            if (failedCount >= 3)
            {
                Console.WriteLine("Risk Level: Elevated");
                Console.WriteLine("Recommendation: Review account activity and consider password reset or MFA verification.");
            }
            else
            {
                Console.WriteLine("Risk Level: Normal");
                Console.WriteLine("Recommendation: No immediate action needed.");
            }
        }

        private bool GetLoginResult()
        {
            while (true)
            {
                Console.WriteLine("\nWas the login successful?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                Console.Write("Choose 1 or 2: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    return true;
                }
                else if (choice == "2")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please choose 1 or 2.");
                }
            }
        }

        private void DisplayAttempt(LoginAttempt attempt)
        {
            string result = attempt.WasSuccessful ? "Success" : "Failed";

            Console.WriteLine($"\nUsername: {attempt.Username}");
            Console.WriteLine($"Result: {result}");
            Console.WriteLine($"Time: {attempt.AttemptTime}");
        }
    }
}