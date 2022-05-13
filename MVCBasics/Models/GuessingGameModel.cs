using System;
using Microsoft.AspNetCore.Http;

namespace MVCBasics.Models
{
    public class GuessingGameModel
    {
        
        public static string WriteMessage()
        {

            return "Try to guess the secret number (1 - 100): ";
        }

        public static string CheckNumber(ISession session, int secretNumber, int guessedNumber)
        {
            Random random = new Random();

            if (guessedNumber == secretNumber)
            {
                secretNumber = random.Next(1, 101);
                session.SetInt32("session", secretNumber);

                return $"You are correct! The number was {guessedNumber}. A new secret number has been generated if you want to continue playing";
            }
            else if (guessedNumber > secretNumber)
            {
                
                return $"Your guess of {guessedNumber} is too hig! Please try again: ";
                
            }
            else if (guessedNumber < secretNumber)
            {
                return $"Your guess of {guessedNumber} is too low! Please try again: ";
     
            }
            return "Invalid input, it should be a number between 1 - 100. Please try again";
        }
    }
}
