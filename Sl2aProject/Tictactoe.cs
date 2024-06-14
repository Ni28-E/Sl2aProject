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

            for (int i = 0; i < this.players.GetLength(0); i++)
            {
                string message = this.players[i, 0] + "(" + this.players[i, 1] + "): "  + this.players[i, 3] + ",";
                
                if(i != (this.players.GetLength(1) - 1))
                {
                    message += ", ";
                }
                
                
                DisplayMessage(char.Parse(this.players[i, 0]), message);
            }

            DisplayMessage(' ', "\n--------------------");
        }

        void main()
        {
            GetPlayerInput();
            ReplaceByPlayerCharacter();

            Display();

            WinningCondition();
            SwitchActivePlayer();

            Console.WriteLine("\nmain");
            Console.ReadKey();
        }


        void GetPlayerInput()
        {
            PlayerMessage("\nPlayer " + this.activeplayer + "Choose your field! =>", false);

            try
            {
                this.playerInput = Convert.ToInt32(Console.ReadLine());

                if ( !(this.playerInput > 0 && this.playerInput < 10 ) )
                {
                    ErrorMessage("The input field must be between 1 and 9.");
                    GetPlayerInput();
                } else if (! CarPlayerInputCharacter())
                {
                    ErrorMessage("The Input field has already been taken");
                    GetPlayerInput();
                }
            } catch
            {
                ErrorMessage("The input field must be a number.");
                GetPlayerInput();
            }
        }


        void PlayerMessage(string message, bool newline =true)
        {
            int activePlayerIndex = 0;

            for (int i = 0;i < this.players.GetLength(0);i++)
            { 
                if(this.activeplayer == char.Parse(this.players[i, 1]))
                {
                    activePlayerIndex = i;
                    break;
                }
            }

            PlayerTextColor(this.players[activePlayerIndex, 2]);

            if(newline)
            {
                Console.WriteLine(message);
            } else
            {
                Console.Write(message);
            }

            Console.ResetColor();
        }    


        void ReplaceByPlayerCharacter()
        {
            switch(this.playerInput)
            {
                case 1: this.patterns[0, 0] = this.activeplayer; PlayersTurnupdate(); break;
                case 2: this.patterns[0, 1] = this.activeplayer; PlayersTurnupdate(); break;
                case 3: this.patterns[0, 2] = this.activeplayer; PlayersTurnupdate(); break;
                case 4: this.patterns[1, 0] = this.activeplayer; PlayersTurnupdate(); break;
                case 5: this.patterns[1, 1] = this.activeplayer; PlayersTurnupdate(); break;
                case 6: this.patterns[1, 2] = this.activeplayer; PlayersTurnupdate(); break;
                case 7: this.patterns[2, 0] = this.activeplayer; PlayersTurnupdate(); break;
                case 8: this.patterns[2, 1] = this.activeplayer; PlayersTurnupdate(); break;
                case 9: this.patterns[2, 2] = this.activeplayer; PlayersTurnupdate(); break;
               
            }
        }

        void WinningCondition()
        {
            int[,,] windPatterns = winningPatterns();
            int PlayersRow = this.players.GetLength(0);
        }

        void SwitchActivePlayer()
        {
            for (int i = 0; i < this.players.GetLength(0); i++)
            {
                if(this.activeplayer == char.Parse(this.players[i, 1]))
                {
                    int nextPlayerIndex = i + 1;

                    if(nextPlayerIndex == this.players.GetLength(0))
                    {
                           nextPlayerIndex = 0;
                    }

                    this.activeplayer = char.Parse(this.players[nextPlayerIndex, 1]);
                    break;

                }
            }
        }

        void PlayersTurnupdate()
        {
            for (int i = 0; i < this.players.GetLength(0); i++)
            {
                if (this.players[i,1].Equals(char.ToString(this.activeplayer)))
                {
                    if (int.TryParse(this.players[i,3], out int playersTurn))
                    {
                        playersTurn++;
                        this.players[i,3] = playersTurn.ToString(); 
                    }
                }
            }
        }

        bool CarPlayerInputCharacter()
        {
            char[,] defaultPatterns = Patterns();
            bool status = false;


            switch (this.playerInput)
            {
                case 1: status = this.patterns[0, 0] == defaultPatterns[0, 0]; break;
                case 2: status = this.patterns[0, 0] == defaultPatterns[0, 1]; break;
                case 3: status = this.patterns[0, 0] == defaultPatterns[0, 2]; break;

                case 4: status = this.patterns[0, 0] == defaultPatterns[1, 0]; break;
                case 5: status = this.patterns[0, 0] == defaultPatterns[1, 1]; break;
                case 6: status = this.patterns[0, 0] == defaultPatterns[1, 2]; break;

                case 7: status = this.patterns[0, 0] == defaultPatterns[2, 0]; break;
                case 8: status = this.patterns[0, 0] == defaultPatterns[2, 1]; break;
                case 9: status = this.patterns[0, 0] == defaultPatterns[2, 2]; break;

                default: status = false; break;
            }

            return status;
        }

        public void DisplayMessage(char patternsChar, string message = "")
        {
            string stringPatternsChar = char.ToString(patternsChar);
            
            if(message.Equals(""))
            {
                message = " " + patternsChar + " ";
            }

            

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


        void ErrorMessage(string message, bool newline = true) 
        { 
            Console.ForegroundColor = ConsoleColor.Red;

            if(newline)
            {        
                Console.WriteLine(message);
            } else 
            {           
                Console.WriteLine(message); 
            }

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


        int[,,] winningPatterns()
        {
            return new int[,,]
            {
                { { 0, 0 }, { 0, 1 }, { 0, 2 } },
                { { 1, 0 }, { 1, 1 }, { 1, 2 } },
                { { 2, 0 }, { 2, 1 }, { 2, 2 } },
                { { 0, 0 }, { 1, 1 }, { 2, 2 } },
                { { 0, 0 }, { 1, 1 }, { 2, 2 } },
                { { 0, 0 }, { 1, 1 }, { 2, 2 } },
                { { 0, 0 }, { 1, 1 }, { 2, 2 } },
                { { 0, 0 }, { 1, 1 }, { 2, 2 } },
            };
    }

}
