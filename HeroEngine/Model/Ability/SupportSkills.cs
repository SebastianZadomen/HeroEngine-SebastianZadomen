using HeroEngine.Model.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HeroEngine.Model.Ability
{
    public class SupportSkills : Skill
    {
        public int Healing { get; set; }
        public SupportSkills(string name, RarityType type, int cost, int pointUse, int healing) : base(name, type, cost, pointUse)
        {
            Healing = healing;
            Type = TypeSkills.Soporte;

        }
        public SupportSkills(string name) : base(name)
        {
            Healing = CalculatedRandomHealing();
            Type = TypeSkills.Soporte;
        }

        public override void AbilityActivation(Hero target, Hero caster)
        {
            Console.WriteLine($"Haz decidido usar tu habilidad : {Name}");
            Console.WriteLine($"Curacion : {Healing} , Costo Energia : {Cost} , Usos : {PointsUse}/{PointUseBase}");

            caster.Health += Healing;
            PointsUse -= 1;
        }

        public override string GetSkillEffect()
        {
            return $"Curacion: {Healing}";
        }
        public int CalculatedRandomHealing()
        {
            var numRandom = new Random();

            return numRandom.Next(10, 20); 
        }
    }
}
