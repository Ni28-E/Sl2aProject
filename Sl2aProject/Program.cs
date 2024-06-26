﻿using System.Xml.Linq;
using System;

namespace Sl2aProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome the great C# game emporium!!!" +
                    "\n\nIf you want to play Snake write snake." +
                    "\nIf you want to play tic-tac-toe write tic." +
                    "\nIf you want to play driver write driver." +
                    "\n\nIf you are done playing write quit.");
                string Game = Console.ReadLine().ToLower();

                switch (Game)
                {
                    case "snake":
                    case "s":
                        Snake snake = new();
                        snake.Play();
                        break;
                    case "tic":
                    case "t":
                        Tictactoe tictactoe = new();
                        tictactoe.Initialize();
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
}
