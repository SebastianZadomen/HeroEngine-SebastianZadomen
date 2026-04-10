using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Model.Heroes
{
    public class Rogue : Hero , IEnergy
    {
        
        public const int SneakAttackScale = 5;
        public const int Multiplier = 2;
        public const int EnergyBase = 100;
        public const int EnergyScaled = 10;


        public int Dagas { get; set; }
        public int SneakAttack => SneakAttackScale * Level ;
        public int Energy { get; set; }
        public int EnergyMax => EnergyBase + (EnergyScaled * Level);
        public Rogue(string name) : base(name)
        {
            Energy = EnergyMax;
        }

        public Rogue(string name, int level) : base(name, level)
        {
            Energy = EnergyMax;
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

            Health -= Math.Max(0, damage - Defense);
            Console.WriteLine($"{Name} has recibido {damage} de daño. \nHP : {Health}/{HealthMax}");
            Defense = 0;
            return true;
        }
        public override string ToString()
        {
            return base.ToString() + $" SneakAttack : {SneakAttack} | N.Dagas : {Dagas} ";
        }
    }
}
