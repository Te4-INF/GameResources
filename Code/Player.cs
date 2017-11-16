using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceINF.GameResources.Code
{
     class Player
    {
        int life = 10;
        int cash = 25;
        int wave = 1;

        public Player(int life, int cash, int wave)
        {
            this.life = life;
            this.cash = cash;
            this.wave = wave;
        }
    }
}
