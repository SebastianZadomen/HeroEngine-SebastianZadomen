using HeroEngine.Model.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Model.Ability
{
    public class AttackSkills : Skill
    {
        public int Damage { get; set; }

        public AttackSkills(string name, RarityType type, int cost, int pointUse,int damage) : base(name, type, cost, pointUse)
        {
            Damage = damage;
            Type = TypeSkills.Ataque;
        }
        public AttackSkills(string name) : base(name)
        {
            Damage = CalculatedDamage(Rarity);
            Type = TypeSkills.Ataque;
        }

        public override void AbilityActivation(Hero target, Hero caster)
        {
            Console.WriteLine($"Haz decidido usar tu habilidad : {Name}");
            Console.WriteLine($"Daño : {Damage} , Costo Energia : {Cost} , Usos : {PointsUse}/{PointUseBase}");
            
            target.TakeDamage(Damage);
            PointsUse -= 1;

            if (caster is IEnergy energyUser)
            {
                energyUser.Energy -= Cost;
            }
            else if (caster is Mage mg)
            {
                mg.Mana -= Cost;

            }

        }
        public override string GetSkillEffect()
        {
            return $"Damage: {Damage}";
        }

        public int CalculatedDamage(RarityType rarity)
        {
            var random = new Random();
            int damage = 10;
            if (rarity == RarityType.Legendario) return damage = random.Next(30,41);
            if (rarity == RarityType.Raro) return damage = random.Next(20, 31);
            if (rarity == RarityType.Epico) return damage = random.Next(15, 21);
            return damage = 10;

        }
    }
}
