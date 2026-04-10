using HeroEngine.Model.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Model.Enemy
{
    public abstract class Enemy : Hero
    {
        public int ExperienceReward { get; set; }
        public int[] AbilityCooldowns { get; set; } = new int[4];

        public Enemy(string name) : base(name)
        {
        }
        public Enemy(string name, int level) : base(name, level)
        {

        }
        public bool DropKey()
        {
            return new Random().Next(0, 8) == 4;
        }
        public abstract void ActionsPerTurn(Hero[] teamPlayer);
        

    }
}
