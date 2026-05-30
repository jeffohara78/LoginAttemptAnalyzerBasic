using System;

namespace LoginAttemptAnalyzer
{
    // Represents one login attempt.
    public class LoginAttempt
    {
        public string Username { get; set; }

        public bool WasSuccessful { get; set; }

        public DateTime AttemptTime { get; set; }

        public LoginAttempt(string username, bool wasSuccessful)
        {
            Username = username;
            WasSuccessful = wasSuccessful;

            // Automatically records when the attempt was added.
            AttemptTime = DateTime.Now;
        }
    }
}