using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class BattleShipGame
    {
       
        Ship frigate, attackboat, dingy;
        public Random rancord = new Random();
        Ship[] ship;
        string gamer;
        public string[,] map;

        public BattleShipGame(string gamer)
        {
            this.gamer = gamer;
            frigate = new Ship(3, "Frigate");
            attackboat = new Ship(2, "Attack_Boat");
            dingy = new Ship(1, "Dingy");
             map = new string[5, 5]
            {   {"0","0","0","0","0"},
                {"0","0","0","0","0"},
                {"0","0","0","0","0"},
                {"0","0","0","0","0"},
                {"0","0","0","0","0"} };
        }


        public void shipPlacement()
        {

            ship = new Ship[3];
            ship[0] = frigate;
            ship[1] = attackboat;
            ship[2] = dingy;

            

            for (int j = 0; j < ship.Length; j++)
            {
                checkSpaceAvailable(ship[j]);

            }

        }

        public void mapReset()
        {
            map = new string[5, 5]
               {{"0","0","0","0","0"},
                {"0","0","0","0","0"},
                {"0","0","0","0","0"},
                {"0","0","0","0","0"},
                {"0","0","0","0","0"} };
            ship = new Ship[3];
            ship[0] = frigate;
            ship[1] = attackboat;
            ship[2] = dingy;

            for (int j = 0; j < ship.Length; j++)
            {
                checkSpaceAvailable(ship[j]);
            }

        }

        public void checkSpaceAvailable(Ship ship)
        {
            bool locationFound = false;
            bool cordInUse = true;
            Tuple<int, int>[] tupleArray;
           
            while (!locationFound && cordInUse)
            {
                int xcord = rancord.Next(0, 4);
                int ycord = rancord.Next(0, 4);

                int shipLength = ship.getTiles();

                int maxCord = ycord + shipLength - 1;

                
                if (maxCord <=4)
                {
                    if(ship.getName() == "Frigate")
                    {
                        tupleArray = new Tuple<int, int>[3]
                        {
                            Tuple.Create(xcord, ycord),
                            Tuple.Create(xcord, ycord + 1),
                            Tuple.Create(xcord,ycord + 2),
                        };

                        cordInUse = isNewCordsValidlocation(tupleArray);

                        if (!cordInUse)
                        {
                            for (int j = 0; j < tupleArray.Length; j++)
                            {
                                Tuple<int, int> currentTuple = tupleArray[j];
                                Ship.tilesInUse[currentTuple.Item1, currentTuple.Item2] = 1;
                                map[currentTuple.Item1, currentTuple.Item2] = "F";

                            }
                        }



                    }
                    else if (ship.getName() == "Attack_Boat")
                    {
                        tupleArray = new Tuple<int, int>[2]
                       {
                            Tuple.Create(xcord, ycord),
                            Tuple.Create(xcord, ycord + 1),
                       };
                        cordInUse = isNewCordsValidlocation(tupleArray);


                        if (!cordInUse)
                        {
                            for (int j = 0; j < tupleArray.Length; j++)
                            {
                                Tuple<int, int> currentTuple = tupleArray[j];
                                Ship.tilesInUse[currentTuple.Item1, currentTuple.Item2] = 1;
                                map[currentTuple.Item1, currentTuple.Item2] = "A";

                            }
                        }


                    }
                    else if (ship.getName() == "Dingy")
                    {
                        tupleArray = new Tuple<int, int>[1]
                       {
                            Tuple.Create(xcord, ycord),
                       };
                        cordInUse = isNewCordsValidlocation(tupleArray);

                        if (!cordInUse)
                        {
                            for (int j = 0; j < tupleArray.Length; j++)
                            {
                                Tuple<int, int> currentTuple = tupleArray[j];
                                Ship.tilesInUse[currentTuple.Item1, currentTuple.Item2] = 1;
                                map[currentTuple.Item1, currentTuple.Item2] = "D";

                            }
                        }
                    }
                    else
                    {
                        //
                    }


                }
                else
                {

                }

            }
        }

        public bool isNewCordsValidlocation(Tuple<int, int>[] newcords)
        {

            bool isOccupied = false;



            for(int j = 0; j < newcords.Length; j++)
            {
                Tuple<int, int> currentTuple = newcords[j];

                if ( Ship.tilesInUse[currentTuple.Item1, currentTuple.Item2] != 0)
                {

                    isOccupied = true;
                }

                else
                {

                }

            }
        

            return isOccupied;
        }

        public void printGrid()
        {
            string[,] arr = map;
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
        }

        public bool evaluate(int x, int y)
        {
            bool isGameStatus = true;
            if(map[x, y] == "F")
            {
                Console.WriteLine("{0} hit the target", gamer);
                for (int j = 0; j <= 4; j++)
                {
                    if(map[x,j] == "F")
                        map[x, j] = "X";
                }

                isGameStatus = checkMap();
                

            }
            else if (map[x, y] == "A")
            {

                Console.WriteLine("{0} hit the target", gamer);
                for (int j = 0; j <= 4; j++)
                {
                    if (map[x, j] == "A")
                        map[x, j] = "X";
                }
                isGameStatus = checkMap();
            }
            else if (map[x, y] == "D")
            {

                Console.WriteLine("{0} hit the target", gamer);
                for (int j = 0; j <= 4; j++)
                {
                    if (map[x, j] == "D")
                        map[x, j] = "X";
                }
                isGameStatus = checkMap();
            }
            else if(map[x,y] != "D" || map[x, y] != "A" || map[x, y] != "F")
            {
                map[x, y] = "M";
                Console.WriteLine("\n{0} has missed", gamer);
                isGameStatus = false;
            }

            return isGameStatus;

        }
        public bool checkMap()
        {
            bool isGameOver = true;
            for(int i = 0; i<= 4; i++)
            {
                for(int j= 0; j<= 4; j++)
                {
                    if (map[i, j] == "F" || map[i, j] == "A" || map[i, j] == "D")
                    {
                        isGameOver = false;
                    }
                    else
                    { /// 
                    }
                }
            }
            return isGameOver;
        }


    }
}
