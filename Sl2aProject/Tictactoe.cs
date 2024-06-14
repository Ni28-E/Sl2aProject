using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sl2aProject
{
    internal class Tictactoe
    {
        string[,] players =
        {
            {"First player", "x", "Cyan", "0" },
            {"Second player", "o", "Yellow", "0" }
        };

        char activeplayer;
        int playerInput, turns;
        char[,] patterns;


        public Tictactoe()
        {
            Initialize();
            Display();
            while(true)
            {
                main();
            }
        }
         public void Initialize()
        {
            this.patterns = Patterns();
            this.activeplayer = char.Parse(this.players[0,1]);
            this.playerInput = 0;
            this.turns = 0;
        }

        void Display()
        {
            Console.Clear();
            Console.WriteLine("\n");
            DisplayMessage(this.patterns[0, 0]);
            Console.Write("|");
            DisplayMessage(this.patterns[0, 1]);
            Console.Write("|");
            DisplayMessage(this.patterns[0, 2]);

            Console.Write("\n-----|-----|-----");

            DisplayMessage(this.patterns[1, 0]);
            Console.Write("|");
            DisplayMessage(this.patterns[1, 1]);
            Console.Write("|");
            DisplayMessage(this.patterns[1, 2]);

            Console.Write("\n-----|-----|-----");

            DisplayMessage(this.patterns[2, 0]);
            Console.Write("|");
            DisplayMessage(this.patterns[2, 1]);
            Console.Write("|");
            DisplayMessage(this.patterns[2, 2]);

            DisplayMessage(' ', "\n\nAttempt: " + this.turns + ",");
            DisplayMessage(' ', "remaining" + this.turns + "\nl");
        }

        void main()
        {
            Console.WriteLine("\nmain");
            Console.ReadKey();
        }

        public void DisplayMessage(char patternsChar, string message = "")
        {
            string stringPatternsChar = char.ToString(patternsChar);
            
            if(message.Equals(""))
            {
                message = " " + patternsChar + " ";
            }

            Console.WriteLine(message);

            bool status = int.TryParse(stringPatternsChar, out int number);

            if(!status)
            {
                
                for(int i = 0; i < this.players.GetLength(0); i++) 
                {
                    if (stringPatternsChar.Equals(this.players[i, 1]))
                    {
                        
                        PlayerTextColor(this.players[i, 2]);
                        break;
                    }
                }
            }

            Console.Write(message);
            Console.ResetColor();
        }

        void PlayerTextColor(string color)
        {
            switch(color.ToLower())
            {
                case "cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "default":
                    Console.ForegroundColor = ConsoleColor.Gray; 
                    break;
            }
        }

        char[,] Patterns()
        {
            return new char[,]
            {
              {'1', '2', '3' },
              {'4', '5', '6' },
              {'7', '8', '9' }
            };
        }
    }
}
