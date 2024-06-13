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
            if (Game == "snake")
            {
                Snake snake = new();
                snake.Play();
            }
            else if (Game == "driver")
            {
                Driver driver = new();
                driver.Initialize();
            }
        }
    }
}
