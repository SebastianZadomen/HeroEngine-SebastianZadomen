using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Model.Heroes
{
    public class Rogue : Hero
    {
        
        public const int SneakAttackScale = 5;
        public const int Multiplier = 2;

        public int Dagas { get; set; }
        public int SneakAttack => SneakAttackScale * Level ;
        public Rogue(string name) : base(name)
        {
        }

        public Rogue(string name, int level) : base(name, level)
        {
            Dagas = 0;
        }
        public override bool Attack(Hero target)
        {
            if (!base.Attack(target))
            {
                return false;
            }
            
            Console.Write($"{Name} ataca !! Dagas : {Dagas}, ");
            int damage = DamageCritical() + SneakAttack + (Dagas * Multiplier);
            target.TakeDamage(damage);

            if (Dagas < 5)
            {
                Dagas += 1;
            }
            else
            {
                Dagas = 0;
            }

            return true;
        }
        public override bool TakeDamage(int damage)
        {
            if (!base.TakeDamage(damage))
            {
                return false;
            }

            Health -= Math.Max(0, damage );
            Console.WriteLine($"{Name} has recibido {damage} de daño. \nHP : {Health}/{HealthMax}");
            return true;
        }
        public override string ToString()
        {
            return base.ToString() + $" SneakAttack : {SneakAttack} | N.Dagas : {Dagas} ";
        }
    }
}
