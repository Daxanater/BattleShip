using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            BattleShipGame Player = new BattleShipGame("\nPlayer");
            BattleShipGame Opponent = new BattleShipGame("\nOpponent");
            Player.shipPlacement();
            Opponent.shipPlacement();
            int counter = 0;
            bool gameOver = false;
            int Ammo = 15;
            bool seeBoard = false;

            Console.WriteLine("Would you like to see grids?[y/n]");
            string input = Console.ReadLine();

            if(input == "Y" || input == "y")
            {
                Console.WriteLine("Opponent Board");
                Program.PrintGrid(Player);

                Console.WriteLine("Player Board");
                Program.PrintGrid(Opponent);

                seeBoard = true;
            }

            //see why this doesn't work.

            /*Console.WriteLine("Would you like to generate a new grid?[y/n]");
            string input2 = Console.ReadLine();
            if (input2 == "y" || input == "Y")
            {
                while (true)
                {
                    Console.WriteLine("Player Board");
                    Opponent.mapReset();
                    Opponent.printGrid();

                    Console.WriteLine("\nWould you like to generate a new grid?[y/n]");
                    string input3 = Console.ReadLine();
                    if (input3 == "y" || input == "Y")
                    {
                        Opponent.mapReset();
                        Opponent.printGrid();
                    }
                    else
                    {
                        break;
                    }
                }
            }*/

            while (seeBoard)
            {
                if (counter % 2 == 0)
                {
                    Console.WriteLine("Enter X- cordinate: ");
                    int xcord = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Y- coordinate: ");
                    int ycord = int.Parse(Console.ReadLine());

                    gameOver = Player.evaluate(xcord, ycord);

                    if (gameOver)
                    {
                        Console.WriteLine("You won!");
                        break;
                    }
                    if(Ammo == 0)
                    {
                        Console.WriteLine("You have ran out of ammo, you have lost!");
                        break;
                    }
                }
                if(counter % 2 != 0)
                {
                    Random rancord = new Random();

                    int randomx = rancord.Next(0, 4);
                    int randomy = rancord.Next(0, 4);

                    gameOver = Opponent.evaluate(randomx, randomy);

                    Console.WriteLine("Ammunition: {0}", Ammo--);
                    Console.WriteLine("Player");
                    Opponent.printGrid();

                    Console.WriteLine("Opponent");
                    Player.printGrid();
                    if (gameOver)
                    {
                        Console.WriteLine("Computer won!");
                        break;
                    }
                    
                }
                else { }
                counter++;

            }
            while (!seeBoard)
            {
                if (counter % 2 == 0)
                {
                    Console.WriteLine("Enter X- cordinate: ");
                    int xcord = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Y- coordinate: ");
                    int ycord = int.Parse(Console.ReadLine());

                    gameOver = Player.evaluate(xcord, ycord);

                    if (gameOver)
                    {
                        Console.WriteLine("You won!");
                        break;
                    }
                    if (Ammo == 0)
                    {
                        Console.WriteLine("You have ran out of ammo, you have lost!");
                        break;
                    }
                }
                if (counter % 2 != 0)
                {
                    Random rancord = new Random();

                    int randomx = rancord.Next(0, 4);
                    int randomy = rancord.Next(0, 4);

                    gameOver = Opponent.evaluate(randomx, randomy);

                    Console.WriteLine("Ammunition: {0}", Ammo--);
 
                    if (gameOver)
                    {
                        Console.WriteLine("Computer won!");
                        break;
                    }

                }
                else { }
                counter++;

            }

            Console.ReadKey();



        }

        static void PrintGrid(BattleShipGame grid)
        {

            string [,] arr = grid.map;
            int rowLength = arr.GetLength(0);
            int colLength = arr.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", arr[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.ReadLine();
        }

    }
}
