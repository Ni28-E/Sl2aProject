using static System.Formats.Asn1.AsnWriter;

namespace Sl2aProject
{
    //To do: Write wall collission & make playable with arrows
    internal class Snake
    {
        int[] X = new int[50];
        int[] Y = new int[50];
        int BoardHeight = 20; //this variable determines the height of the generated board
        int BoardWidth = 30; //this variable determines the width of the generated board
        int appleX;
        int appleY;
        int parts = 3;
        char key = 'w';
        bool gameActive = true;
        bool keepPlaying = true;
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        Random rand = new Random();
        public Snake()
        {
            X[0] = 5;
            Y[0] = 5;
            Console.CursorVisible = false;//we hide the cursor
            appleX = rand.Next(2, (BoardWidth - 2));
            appleY = rand.Next(2, (BoardHeight - 2));
        }

        public void Play()
        {
            Console.Clear();//here we clear all the previous inputs from the console



            while (gameActive)
            {
                MakeBoard(BoardHeight, BoardWidth);
                Input();
                Logic();
            }
            Console.ReadKey();

        }

        public static void MakeBoard(int BoardHeight, int BoardWidth)
        {

            Console.Clear();
            for (int i = 1; i <= (BoardWidth + 2); i++)//in these for loops we generate the borders of the board
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("-");
            }
            for (int i = 1; i <= (BoardWidth + 2); i++)
            {
                Console.SetCursorPosition(i, (BoardHeight + 2));
                Console.Write("-");
            }
            for (int i = 1; i <= (BoardHeight + 1); i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("|");
            }
            for (int i = 1; i <= (BoardHeight + 1); i++)
            {
                Console.SetCursorPosition((BoardWidth + 2), i);
                Console.Write("|");
            }

        }

        public void Input()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.KeyChar;
            }
        }

        static public void WriteLocationSnake(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("#");
        }
        static public void WriteLocationApple(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("A");
        }

        public void Logic()
        {

            

            if (X[0] == appleX && Y[0] == appleY)//this code checks the collision with the apple
            {
                    parts++;
                    appleX = rand.Next(2, (BoardWidth - 2));//we *know where the walls are by checking the board width and height and subtracting 2
                    appleY = rand.Next(2, (BoardHeight - 2));
            }
            for (int i = parts; i > 1; i--)
            {
                X[i - 1] = X[i - 2];
                Y[i - 1] = Y[i - 2];

            }
            switch (key)//this is where we define the inputs
            {
                case 'w':
                    Y[0]--;
                    break;
                case 'a':
                    X[0]--;
                    break;
                case 's' :
                    Y[0]++;
                    break;
                case 'd':
                    X[0]++;
                    break;
            }
            for (int i = 0; i <= (parts - 1); i++)
            {
                WriteLocationSnake(X[i], Y[i]);
                WriteLocationApple(appleX, appleY);
            }
            for (int i = 1; i<parts;i++ ){//snake tail collision
                if ((X[0] == X[i])&& (Y[0] == Y[i]))
                {
                    gameActive = false;
                }
            }
            Thread.Sleep(100);
        }

        void GameOverScreen()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Game Over");
            Console.WriteLine("Play Again (Y/N)?");
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

        public void PressEnterToContinue()
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
