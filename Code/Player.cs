using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceINF.GameResources.Code
{
     class Player
    {
        int life;
        int cash;
        int wave;

        public Player(int life, int cash, int wave) : base()
        {
            this.life = life;
            this.cash = cash;
            this.wave = wave;
        }
    }
}
