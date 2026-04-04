using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Model
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
                _health = HealthControl(value);         
            }
        }

        private int HealthMax => HealthBase + (HealthScale * Level);
        public bool IsAlive => Health > 0;
        public int Damage => DamageBase + (DamageBase * Level);

        public Hero(string name, int level )
        {
            Name = name;
            Level = level;
            Health = HealthMax;

        }
        public Hero(string name) : this(name, 1)
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
        
       

       

        protected int HealthControl(int health)
        {
            return Math.Clamp(health, 0, HealthMax);

        }
        protected string ValidateName(string name)
        {
       
            string result = "";
            foreach (char i in name)
            {

                if ((i >= 'a' && i <= 'z') || (i >= 'A' && i <= 'Z'))
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
            return $"[{GetType()}] Name : {Name} | Level : {Level} | Damage : {Damage}";
        }
    }
}
