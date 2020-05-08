using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomNumberGuessingAppConsole
{
    class Program
    {
        static Random rng = new Random();
        static int answer;
        static int userGuess;
        static int numberOfTries;
        static string userAnswer;
        static int upperBound;
        static void Main(string[] args)
        {
            //Variables
            bool playGame = true;

            while (playGame)
            {
                Console.Clear();

                Console.WriteLine("Welcome to the Random Number Game!");
                Console.WriteLine("Choose your difficulty: Easy, Normal, or Hard");
                userAnswer = Console.ReadLine().ToLower();
                GetDifficulty();

                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Choose a number between 1 and {upperBound}.");
                    Console.WriteLine($"Number of guesses left: {numberOfTries}");
                    CheckUserGuess(out userGuess);

                    if (userGuess == answer)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You are correct!");
                    }
                    else
                    {
                        if (numberOfTries > 1)
                        {
                            numberOfTries--;
                            if (userGuess > answer)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Too high, guess again");
                            }
                            else 
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Too low, guess again");
                            }

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You lose! Game Over!");
                            break;
                        }
                    }
                } while (userGuess != answer);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Play again?");
                playGame = PlayAgain();
            }

        }

        private static void GetDifficulty()
        {
            switch (userAnswer)
            {
                case "easy":
                    answer = rng.Next(1, 11);
                    numberOfTries = 7;
                    upperBound = 10;
                    break;
                case "normal":
                    answer = rng.Next(1, 51);
                    numberOfTries = 5;
                    upperBound = 50;
                    break;
                case "hard":
                    answer = rng.Next(1, 101);
                    numberOfTries = 3;
                    upperBound = 100;
                    break;
                default:
                    answer = rng.Next(1, 51);
                    numberOfTries = 5;
                    upperBound = 50;
                    break;
            }
        }

        private static bool PlayAgain()
        {
            string userAnswer = Console.ReadLine().ToLower();
            if (userAnswer == "no")
            {
                return false;
            }
            return true;
        }

        private static void CheckUserGuess(out int userGuess)
        {
            while (!int.TryParse(Console.ReadLine(), out userGuess))
            { Console.WriteLine("Please choose a valid number"); }
        }
    }
}
