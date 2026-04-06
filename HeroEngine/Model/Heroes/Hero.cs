using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Model.Heroes
{
    public abstract class Hero
    {
        public const int DamageBase = 5;
        public const int HealthBase = 100;
        public const int HealthScale = 25;


        private string _name;
        public string Name { get { return _name; } set {
                _name = ValidateName(value);
            
            }
        }
       
        public int Level { get; set; }

        private int _health;
        public int Health { get { return _health; } set {
                _health = StatsControl(value, HealthMax);         
            }
        }

        protected int HealthMax => HealthBase + HealthScale * Level;


        public bool IsAlive => Health > 0;
        public int Damage => DamageBase + DamageBase * Level;

        public Hero(string name, int level )
        {
            Name = name;
            Level = level;
            Health = HealthMax;

        }
        public Hero(string name) : this(name, 0)
        {
            
        }

        public virtual bool Attack(Hero target)
        {
            if (!IsAlive)
            {
                Console.WriteLine($"{Name} está muerto y no puede atacar.");
                return false;
            }
            return true;
        }
        public virtual bool TakeDamage(int damage)
        {
            if (!IsAlive)
            {
                Console.WriteLine($"{Name} está muerto y no puede recibir daño.");
                return false;
            }
            return true;
        }
        
        public int DamageCritical()
        {
            var random = new Random();
            

            int damageCritical = random.Next(0, 2) == 1 ? Damage * 2 : Damage;

            Console.WriteLine(damageCritical.Equals(Damage)?$"Inflige {damageCritical} de daño.(Golpe normal)" : $"Inflige {damageCritical} de daño.(GolpeCritico)");
            return damageCritical;

        }
        

        protected int StatsControl(int valueInput, int maxValue)
        {
            return Math.Clamp(valueInput, 0, maxValue);

        }
        protected string ValidateName(string name)
        {
       
            string result = "";
            foreach (char i in name)
            {

                if (i >= 'a' && i <= 'z' || i >= 'A' && i <= 'Z')
                {
                    result += i;
                }
            }
            if (result.Equals("") || result.Equals(" "))
            {
                Console.WriteLine("Nombre no valido , Registrado como NoName");
                result = "NoName";
            }
            else
            {
                result = result.Substring(0, 1).ToUpper() + result.Substring(1, result.Length - 1).ToLower();
            }
            return result;
            
        }
        public override string ToString()
        {
            return $"[{GetType().Name}] Name : {Name} | Level : {Level} | Health : {Health}/{HealthMax}  | Damage : {Damage}";
        }
    }
}
