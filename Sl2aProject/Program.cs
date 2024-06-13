using System.Xml.Linq;
using System;

namespace Sl2aProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome the great C# game emporium!!!" +
                "\n\nIf you want to play Snake type snake." +
                "\nIf you want to play tic-tac-toe type tic." +
                "\nIf you want to play druver type driver." +
                "\n\nIf you are done playing type quit.");
            string Game = Console.ReadLine();
            
            switch(Game)
            {
                case "snake":
                case "s":
                    Snake snake = new();
                    snake.Play();
                    break;
                case "tic":
                case "t":

                    break;
                case "driver":
                case "d": 
                    Driver driver = new();
                    driver.Initialize();
                    break;
                case "quit":
                case "q":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Choose a valid option.");
                    break;
            }
        }
    }
}
