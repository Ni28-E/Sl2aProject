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
            {"Seconf player", "o", "Yellow", "0" }
        };

        char actibeplayer;
        public Tictactoe()
        {
            initialize();
            display();
            while(true)
            {
                main();
            }
        }
        void initialize()
        {

        }

        void display()
        {
            Console.WriteLine("Main");
        }

        void main()
        {
            Console.WriteLine("main");
            Console.ReadKey();
        }















    }
}
