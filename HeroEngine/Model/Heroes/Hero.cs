using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using HeroEngine.Model.Ability;


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
        public int Defense { get; set; }
        public Skill[] Skills { get; set; } = new Skill[3];
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
            Defense = 0;

        }
        public Hero(string name) : this(name, 0)
        {
            Defense = 0;
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


        public void ShowSkills()
        {
            int totalSlots = Skills.Length; 

            for (int i = 0; i < totalSlots; i++) Console.Write("╔════════════════════════════╗  ");
            Console.WriteLine();

            for (int i = 0; i < totalSlots; i++) Console.Write($"║           SLOT {i + 1}           ║  ");
            Console.WriteLine();

            for (int i = 0; i < totalSlots; i++) Console.Write("╠════════════════════════════╣  ");
            Console.WriteLine();

            for (int i = 0; i < totalSlots; i++)
            {
                string typeText = Skills[i] != null ? $"[{Skills[i].Type}]" : "[ VACÍO ]";
                Console.Write($"║ {typeText.PadRight(26)} ║  "); 
            }
            Console.WriteLine();

            for (int i = 0; i < totalSlots; i++)
            {
                string nameText = Skills[i] != null ? Skills[i].Name : "Ninguna";
                Console.Write($"║ {nameText.PadRight(26)} ║  ");
            }
            Console.WriteLine();

            for (int i = 0; i < totalSlots; i++)
            {
                string effectText = Skills[i] != null ? Skills[i].GetSkillEffect() : "";
                Console.Write($"║ {effectText.PadRight(26)} ║  ");
            }
            Console.WriteLine();

            for (int i = 0; i < totalSlots; i++)
            {
                string costText = Skills[i] != null ? $"Cost: {Skills[i].CalculatedCost(Skills[i].Rarity)}" : "";
                Console.Write($"║ {costText.PadRight(26)} ║  ");
            }
            Console.WriteLine();

            for (int i = 0; i < totalSlots; i++) Console.Write("╚════════════════════════════╝  ");
            Console.WriteLine();

            Console.WriteLine("\nSeleccione un Slot de Habilidad (1-4): ");
        }

        public void UseSkills(Hero target) {
            ShowSkills();
            int num = 0;
            do
            {
                bool validate = int.TryParse(Console.ReadLine(), out num);

                if (!validate || num < 1 || num > 4)
                {
                    Console.WriteLine("Número incorrecto, elige un slot del 1 al 4...");
                }
                else {
                    num -= 1;
                    if (Skills[num] == null)
                    {
                        Console.WriteLine("Esta vacio, no haces nada");

                    }
                    else
                    {
                        int index = num - 1;
                        Skills[index].AbilityActivation(target, this);
                        /* if ((Skills[num].Type == TypeSkills.Ataque)  && Skills[num] is AttackSkills atk)
                         {
                             target.TakeDamage(atk.Damage);
                         }
                         if ((Skills[num].Type == TypeSkills.Soporte) && Skills[num] is AttackSkills cure)
                         {
                             Health = cure.Cure;
                         }
                         if ((Skills[num].Type == TypeSkills.Defensa) && Skills[num] is AttackSkills def)
                         {
                             Defense = def;
                         }*/
                    }
                }

            }
            while (!(num > 0 && num < 5));
            

        }

        public override string ToString()
        {
            return $"[{GetType().Name}] Name : {Name} | Level : {Level} | Health : {Health}/{HealthMax}  | Damage : {Damage}";
        }
    }
}
