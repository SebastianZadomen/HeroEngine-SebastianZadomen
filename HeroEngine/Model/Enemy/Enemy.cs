using HeroEngine.Model.Ability;
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
        public virtual bool DropKey()
        {
            return new Random().Next(0, 12) == 4;
        }
        public abstract void ActionsPerTurn(Hero[] teamPlayer);

        public bool ControlPositionAbilityCooldowns(int positionUse)
        {
            int index = positionUse - 1;
            if (index < 0 || index >= Skills.Length || Skills[index] == null)
            {
                Console.WriteLine("No hay ninguna habilidad en este espacio.");
                return false;
            }
            if (AbilityCooldowns[index] == 0)
            {
                string rarity = Skills[index].Rarity.ToString();
                switch (rarity)
                {
                    case "Legendario":
                        AbilityCooldowns[index] = 3;
                        break;
                    case "Epico":
                        AbilityCooldowns[index] = 2;
                        break;
                    case "Raro":
                        AbilityCooldowns[index] = 1;
                        break;
                    default:
                        AbilityCooldowns[index] = 0; 
                        break;
                }

                return true; 
            }
            else
            {
                Console.WriteLine($"Esta habilidad está en COOLDOWN. Faltan {AbilityCooldowns[index]} turnos.");
                return false;
            }
        }

        public void ReduceCooldowns()
        {
            for (int i = 0; i < AbilityCooldowns.Length; i++)
            {
                if (AbilityCooldowns[i] > 0)
                {
                    AbilityCooldowns[i]--;
                }
            }
        }
        public int ComprovationHpTeamPlayer(Hero[] teamPlayer)
        {
            int positionPlayerTarget = 0;

            for (int i = 0; i < teamPlayer.Length; i++){
                if (teamPlayer[i] != null && teamPlayer[i].IsAlive)
                {
                    positionPlayerTarget = i;
                }
                if (!teamPlayer[positionPlayerTarget].IsAlive || teamPlayer[i].Health < teamPlayer[positionPlayerTarget].Health)
                {
                    positionPlayerTarget = i;
                }

            }
            return positionPlayerTarget;
        }

        public virtual bool EnemyUseSkills(Hero player)
        {
            
            for (int i = Skills.Length - 1; i >= 0; i--)
            {
                if (Skills[i] != null && AbilityCooldowns[i] == 0)
                {
                    if (Skills[i] is AttackSkills atk && player.Health <= atk.Damage)
                    {
                        Console.WriteLine($"¡{Name} ve la oportunidad y remata a {player.Name}!");
                        ControlPositionAbilityCooldowns(i + 1);
                        Skills[i].AbilityActivation(player, this);
                        return true; 
                    }
                }
                
            }

            for (int i = 0; i < Skills.Length; i++)
            {
                if (Skills[i] != null && AbilityCooldowns[i] == 0)
                {
                    Console.WriteLine($"{Name} usa su mejor habilidad disponible: {Skills[i].Name}.");
                    ControlPositionAbilityCooldowns(i + 1);
                    Skills[i].AbilityActivation(player, this);
                    return true; 
                }
            }

            Console.WriteLine($"{Name} no tiene habilidades listas. ¡Se lanza con un ataque básico!");
            this.Attack(player);
            return false;
        }
    }

}