using System.Xml.Linq;

namespace Sl2aProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome the great C# game emporium!!!");
            Console.WriteLine("If you want to play Snake type snake");
            Console.WriteLine("If you want to play tic-tac-toe type tic");
            Console.WriteLine("If you want to play druver type driver");
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
                default:
                    Console.WriteLine("Choose a valid option.");
                    break;
            }
        }
    }
}
