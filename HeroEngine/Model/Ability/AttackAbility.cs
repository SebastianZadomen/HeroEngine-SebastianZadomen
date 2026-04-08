using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Model.Ability
{
    public class AttackAbility : Ability
    {
        public AttackAbility(string name, RarityType type, int cost, int pointUse) : base(name, type, cost, pointUse)
        {
        }
        public AttackAbility(string name) : base(name)
        {
            
        }

        public override void AbilityActivation()
        {
            throw new NotImplementedException();
        }
    }
}
