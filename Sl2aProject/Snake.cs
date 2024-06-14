using static System.Formats.Asn1.AsnWriter;

namespace Sl2aProject
{
    
    internal class Snake 
    {
        int[] X = new int[50];
        int[] Y = new int[50];
        int BoardHeight = 20; //this variable determines the height of the generated board
        int BoardWidth = 40; //this variable determines the width of the generated board
        int appleX;
        int appleY;
        int parts = 3;
        char key = 's';
        bool keepPlaying = true;
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        Random rand = new Random();
        public Snake()
        {
            X[0] = 5;//is the head
            Y[0] = 5;
            Console.CursorVisible = false;//we hide the cursor
            appleX = rand.Next(2, (BoardWidth - 2));
            appleY = rand.Next(2, (BoardHeight - 2));
        }

        public void Play()
        {
            LaunchScreen();
            while (keepPlaying)
            {
                MakeBoard(BoardHeight, BoardWidth);
                Input();
                Logic();
            }
            Console.Clear();


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

        public void WriteLocationSnake(int x, int y)//this is where we set the coordinates of the snake
        { 
            Console.SetCursorPosition(x, y);
            Console.Write("#");
        }
        static public void WriteLocationApple(int x, int y)//this is where we set the coordinates of the apple
        {
            Console.SetCursorPosition(x, y);
            Console.Write("A");
        }

        public void Logic()//in this function we process the game logic
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
            for (int i = 1; i<parts;i++ ){//this is the code for the snake tail collision
                if ((X[0] == X[i])&& (Y[0] == Y[i]))
                {
                    GameOver();
                    
                }
            }
            if (X[0] == BoardWidth || Y[0] == (BoardHeight+1) || X[0] == 2 || Y[0] == 1) {//this statement is in charge of checking the wall collision
                GameOver();
                
            }


            Thread.Sleep(100);
        }

        public void GameOver()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Game Over");
            keepPlaying = false;

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

        internal void LaunchScreen()
        {
            Console.Clear();
            Console.WriteLine("This is a snake game.\n\n" +
                "Collect the Apples and dont hit your own tail!\n\n" +
                "Use W, A, S and D to control your movement.\n\n" +
                "Press [enter] to start...");
            PressEnterToContinue();
        }

    }
}
