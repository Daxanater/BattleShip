using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class BattleShip
    {

        public int tiles;
        public string name;
        bool isDestroyed;

        public BattleShip(int tiles, string name)
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
