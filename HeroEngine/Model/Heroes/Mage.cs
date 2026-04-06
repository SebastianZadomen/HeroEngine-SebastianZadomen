using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Model.Heroes
{
    public class Mage : Hero
    {
        public const int ManaBase = 60;
        public const int ManaScale = 20;

        public int ArcaneLevel => Level * 2;
        public int ManaMax => ManaBase + ManaScale * Level;

        private int _mana;
        public int Mana { get { return _mana; }  set {
                _mana = StatsControl(value, ManaMax);  
            }
        }
        public Mage(string name, int level) : base(name, level)
        {
            Mana = ManaMax;
        }
        public Mage(string name) : base(name)
        {
            
        }

       
        public override bool Attack(Hero target)
        {
            if (!base.Attack(target))
            {
                return false;
            }
            if (Mana.Equals(0))
            {
                Console.WriteLine("No tienes mana....");
                return false;
            }
            if (Mana < 20)
            {
                Console.WriteLine("No tienes suficiente mana");
                return false;
            }
                Mana -= 20;
                Console.Write($"{Name} Lanza un encantamiento !!, ");
                target.TakeDamage(DamageCritical());
                return true;
            
        }
        public override bool TakeDamage(int damage)
        {
            if (!base.TakeDamage(damage))
            {
                return false;
            }


            Health -= Math.Max(0, damage);
            Console.WriteLine($"{Name} has recibido {damage} de daño. \nHP : {Health}/{HealthMax}");
            return true;
        }
        public override string ToString()
        {
            return base.ToString() + $" | Mana : {Mana}/{ManaMax} | Arcane Level : {ArcaneLevel} ";
        }

    }
}
