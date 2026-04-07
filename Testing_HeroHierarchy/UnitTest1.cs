using System.Threading;
using Xunit;
using static System.Net.Mime.MediaTypeNames;
using HeroEngine.Model;
using HeroEngine.Model.Heroes;

namespace Testing_HeroHierarchy
{
    public class HeroCreationTests
    {
        [Fact]
        public void Warrior_ValidationOfCreation()
        {
            string expectedName = "Garen";
            int expectedLevel = 1;

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
}