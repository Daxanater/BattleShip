using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Ship
    {

        public int tiles;
        public string name;
        bool isDestroyed;
        public static int[,] tilesInUse = new int[5, 5] {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0} };


        public Ship(int tiles, string name)
        {
            this.tiles = tiles;
            this.name = name;
            isDestroyed = false;
            

        }

        public int getTiles()
        {
            return tiles;
        }

        public string getName()
        {
            return name;
        }

        public bool getisDestroyed()
        {
            return isDestroyed;

        }

        public void setisDestroyed( bool isDestroyed)
        {
            this.isDestroyed = isDestroyed;


        }


    }
}
