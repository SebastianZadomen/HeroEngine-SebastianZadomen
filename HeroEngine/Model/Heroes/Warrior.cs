using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Model.Heroes
{
    public class Warrior : Hero
    {
        public const int ArmorBase = 3;
        public int Armor => ArmorBase + (ArmorBase * Level );
        public Warrior(string name) : base(name)
        {
        }

        public Warrior(string name, int level) : base(name, level)
        {
        }
        public override bool Attack(Hero target)
        {
            if (!base.Attack(target))
            {
                return false;
            }

            Console.WriteLine("Grito de batalla: «¡Por Bytecroft! ¡Mi código compila a la primera!»");
            Console.Write($"{Name} ataca !!, ");
            target.TakeDamage(DamageCritical());
            return true; 
        }
        public override bool TakeDamage(int damage)
        {
            if (!base.TakeDamage(damage))
            {
                return false;
            }


            Health -= Math.Max(0, damage - Armor);
            Console.WriteLine($"{Name} has recibido {damage} de daño pero tu armadura te ha protegido {Armor} de daño\nHP : {Health}/{HealthMax}");
            return true;
        }
        public override string ToString()
        {
            return base.ToString() + $" Armor : {Armor} ";
        }
    }
}
