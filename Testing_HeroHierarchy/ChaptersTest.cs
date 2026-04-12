using System.Threading;
using Xunit;
using static System.Net.Mime.MediaTypeNames;
using HeroEngine.Model;
using HeroEngine.Model.Heroes;
using HeroEngine.Model.Ability;
using HeroEngine.Model.Enemy;

namespace Testing_HeroEnginner
{
    public class HeroCreationTests_Chapter_HeroHierarchy
    {
        [Fact]
        public void Warrior_ValidationOfCreation()
        {
            string expectedName = "Garen";
            int expectedLevel = 1;
            int energy = 100;
            Warrior warrior = new Warrior(expectedName, expectedLevel);

            Assert.Equal(expectedName, warrior.Name);
            Assert.Equal(expectedLevel, warrior.Level);
            Assert.True(warrior.Health > 0);
            Assert.True(warrior.Armor > 0);
        }

        [Fact]
        public void Mage_ValidationOfCreation()
        {
            string expectedName = "Lux";
            int expectedLevel = 5;

            Mage mage = new Mage(expectedName, expectedLevel);

            Assert.Equal(expectedName, mage.Name);
            Assert.Equal(expectedLevel, mage.Level);
            Assert.True(mage.Mana > 0);
        }

        [Fact]
        public void Rogue_ValidationOfCreation()
        {
            string expectedName = "Talon";
            int expectedLevel = 3;


            var rogue = new Rogue(expectedName, expectedLevel);

            Assert.Equal(expectedName, rogue.Name);
            Assert.Equal(expectedLevel, rogue.Level);
        }
    }
    public class HeroTests_Chapter_AbilitySystem
    {
        [Fact]
        public void AttackSkill_AbilityActivation_ReducesTargetHealth()
        {

            Warrior attacker = new Warrior("Garen", 1);
            Mage target = new Mage("Lux", 1);



            AttackSkills slash = new AttackSkills("Corte Básico", RarityType.Comun, 10, 10, 20);
            int resultHealth = target.Health - slash.Damage;


            slash.AbilityActivation(target, attacker);

            Assert.Equal(resultHealth, target.Health);
        }
        [Fact]
        public void SupportSkills_AbilityActivation_IncreaseTargetHealth()
        {

            Warrior target = new Warrior("Garen", 1);
            Mage lux = new Mage("Lux", 1);



            AttackSkills slash = new AttackSkills("Corte Básico", RarityType.Comun, 10, 10, 20);
            SupportSkills healer = new SupportSkills("Oración de sanación", RarityType.Comun, 10, 10, 15);

            int resultHealth = lux.Health - slash.Damage;
            lux.TakeDamage(slash.Damage);


            slash.AbilityActivation(target, lux);

            Assert.Equal(resultHealth, lux.Health);
        }
        [Fact]
        public void DefenseSkills_AbilityActivation_ProtectionTarget()
        {

            Rogue talon = new Rogue("Talon", 1);
            Mage lux = new Mage("Lux", 1);


            AttackSkills slash = new AttackSkills("Corte Básico", RarityType.Comun, 10, 10, 20);
            DefenseSkills defense = new DefenseSkills("Proteccion Lunar", RarityType.Comun, 12, 15, 10);

            int resultHealth = talon.Health - (slash.Damage - defense.Defense);

            defense.AbilityActivation(lux, talon);
            talon.TakeDamage(slash.Damage);

            Assert.Equal(resultHealth, talon.Health);
        }
    }
    public class EnemyTests_Chapter
    {
        [Fact]
        public void Enemy_Health_UseAttacktSkills()
        {
            Boss boss = new Boss("Rey Demonio", 5);
            Mage target = new Mage("Lux", 1);


            AttackSkills slash = new AttackSkills("Corte Letal", RarityType.Comun, 10, 10, 30);
            boss.Skills[0] = slash;
            boss.AbilityCooldowns[0] = 0;

            int resultHealth = target.Health - slash.Damage;

            boss.EnemyUseSkills(target);

            Assert.Equal(resultHealth, target.Health);
        }

        [Fact]
        public void Enemy_Health_UseSupportSkills()
        {
            Boss boss = new Boss("Rey Demonio", 5);
            Warrior target = new Warrior("Garen", 1);

            boss.Health = 10;

            SupportSkills heal = new SupportSkills("Poción Oscura", RarityType.Comun, 10, 10, 25);
            boss.Skills[0] = heal;
            boss.AbilityCooldowns[0] = 0;

            int resultHealth = boss.Health + 25;

            boss.EnemyUseSkills(target);

            Assert.Equal(resultHealth, boss.Health);
        }

    }
}