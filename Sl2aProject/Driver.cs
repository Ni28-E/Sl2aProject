using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;


Console.CursorVisible = false;
namespace Sl2aProject
{
    

    public class Driver
    {
        int width = 50;
        int height = 30;

        int WindowHeight;
        int WindowWidth;
        char[,] scene;
        int score = 0;
        int driverPosition;
        int driverVelocity;
        bool gameActive;
        bool keepPlaying = true;
        bool consoleSizeError = false;
        int previousRoadUpdate = 0;

        public void Initialize()
        {
            WindowWidth = Console.WindowWidth;
            WindowHeight = Console.WindowHeight;
            if (OperatingSystem.IsWindows())
            {
                if (WindowWidth < width && OperatingSystem.IsWindows())
                {
                    WindowWidth = Console.WindowWidth = width + 1;
                }
                if (WindowHeight < height && OperatingSystem.IsWindows())
                {
                    WindowHeight = Console.WindowHeight = height + 1;
                }
                Console.BufferWidth = WindowWidth;
                Console.BufferHeight = WindowHeight;
            }
        }

        internal void LaunchScreen()
        {
            Console.Clear();
            Console.WriteLine("This is a driving game.");
            Console.WriteLine();
            Console.WriteLine("Stay on the road!");
            Console.WriteLine();
            Console.WriteLine("Use A, W, and D to control your velocity.");
            Console.WriteLine();
            Console.Write("Press [enter] to start...");
            PressEnterToContinue();
        }

        void InitializeScene()
        {
            const int roadWidth = 15;
            gameActive = true;
            driverPosition = width / 2;
            driverVelocity = 0;
            int leftEdge = (width - roadWidth) / 2;
            int rightEdge = leftEdge + roadWidth + 1;
            scene = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (j < leftEdge || j > rightEdge)
                    {
                        scene[i, j] = '.';
                    }
                    else
                    {
                        scene[i, j] = ' ';
                    }
                }
            }
        }

        void Render()
        {
            StringBuilder stringBuilder = new(width * height);
            for (int i = height - 1; i >= 0; i--)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i is 1 && j == driverPosition)
                    {
                        stringBuilder.Append(
                            !gameActive ? 'X' :
                            driverVelocity < 0 ? '<' :
                            driverVelocity > 0 ? '>' :
                            '^');
                    }
                    else
                    {
                        stringBuilder.Append(scene[i, j]);
                    }
                }
                if (i > 0)
                {
                    stringBuilder.AppendLine();
                }
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(stringBuilder);
        }

        void HandleInput()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.A or ConsoleKey.LeftArrow:
                        driverVelocity = -1;
                        break;
                    case ConsoleKey.D or ConsoleKey.RightArrow:
                        driverVelocity = +1;
                        break;
                    case ConsoleKey.W or ConsoleKey.UpArrow or ConsoleKey.S or ConsoleKey.DownArrow:
                        driverVelocity = 0;
                        break;
                    case ConsoleKey.Escape:
                        gameActive = false;
                        keepPlaying = false;
                        break;
                    case ConsoleKey.Enter:
                        Console.ReadLine();
                        break;
                }
            }
        }

        void GameOverScreen()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Game Over");
            Console.WriteLine($"Score: {score}");
            Console.WriteLine($"Play Again (Y/N)?");
        GetInput:
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.Y:
                    keepPlaying = true;
                    break;
                case ConsoleKey.N or ConsoleKey.Escape:
                    keepPlaying = false;
                    break;
                default:
                    goto GetInput;
            }
        }

        void Update()
        {
            for (int i = 0; i < height - 1; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    scene[i, j] = scene[i + 1, j];
                }
            }
            int roadUpdate =
                Random.Shared.Next(5) < 4 ? previousRoadUpdate :
                Random.Shared.Next(3) - 1;
            if (roadUpdate is -1 && scene[height - 1, 0] is ' ') roadUpdate = 1;
            if (roadUpdate is 1 && scene[height - 1, width - 1] is ' ') roadUpdate = -1;
            switch (roadUpdate)
            {
                case -1: // left
                    for (int i = 0; i < width - 1; i++)
                    {
                        scene[height - 1, i] = scene[height - 1, i + 1];
                    }
                    scene[height - 1, width - 1] = '.';
                    break;
                case 1: // right
                    for (int i = width - 1; i > 0; i--)
                    {
                        scene[height - 1, i] = scene[height - 1, i - 1];
                    }
                    scene[height - 1, 0] = '.';
                    break;
            }
            previousRoadUpdate = roadUpdate;
            driverPosition += driverVelocity;
            if (driverPosition < 0 || driverVelocity >= width || scene[1, driverPosition] is not ' ')
            {
                gameActive = false;
            }
            score++;
        }

        void PressEnterToContinue()
        {
        GetInput:
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.Enter:
                    break;
                case ConsoleKey.Escape:
                    keepPlaying = false;
                    break;
                default: goto GetInput;
            }
        }
    }
}
