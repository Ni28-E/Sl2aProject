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
            display();
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

        void display()
        {
            Console.Clear();
            Console.WriteLine("\n");
            DisplayMessage(this.patterns[0, 0]);
            DisplayMessage(this.patterns[0, 1]);
            DisplayMessage(this.patterns[0, 2]);

            DisplayMessage(this.patterns[1, 0]);
            DisplayMessage(this.patterns[1, 1]);
            DisplayMessage(this.patterns[1, 2]);

            DisplayMessage(this.patterns[2, 0]);
            DisplayMessage(this.patterns[2, 1]);
            DisplayMessage(this.patterns[2, 2]);
        }

        void main()
        {
            Console.WriteLine("\nmain");
            Console.ReadKey();
        }

        public void DisplayMessage(char patternschar, string message = "")
        {
            string stringpatternsChar = char.ToString(patternschar);
            
            if(message.Equals(""))
            {
                message = " " + patternschar + " ";
            }

            Console.WriteLine(message);

            bool status = int.TryParse(stringpatternsChar, out int number);

            if(!status)
            {
                Console.WriteLine(this.players.GetLength(0));
                for(int i = 0; i < this.players.GetLength(0); i++) 
                {

                }
            }
        }

        char[,] Patterns()
        {
            return new char[,]
            {
              {'1','2','3' },
              {'4','5','6' },
              {'7','8','9' },
            };
        }
    }
}
