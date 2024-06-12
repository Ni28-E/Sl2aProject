namespace Sl2aProject
{
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



            while (true)
            {
                MakeBoard(BoardHeight, BoardWidth);
                Input();
                Logic();
            }
            Console.ReadKey();

        }

        public static void MakeBoard(int BoardHeight, int BoardWidth)
        {


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

        public void WriteLocation(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("#");
        }

        public void Logic()
        {

            

            if (X[0] == appleX)
            {
                if (Y[0] == appleY)
                {
                    parts++;
                    appleX = rand.Next(2, (BoardWidth - 2));
                    appleY = rand.Next(2, (BoardHeight - 2));
                }
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
                case 's':
                    Y[0]++;
                    break;
                case 'd':
                    X[0]++;
                    break;
            }
            for (int i = 0; i <= (parts - 1); i++)
            {
                WriteLocation(X[i], Y[i]);//Bugged look for fix
                WriteLocation(appleX, appleY);
            }
            Thread.Sleep(100);
        }

        public void GameOver()
        {

        }
    }
}
