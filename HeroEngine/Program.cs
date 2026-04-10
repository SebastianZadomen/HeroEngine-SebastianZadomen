using HeroEngine.Model.Ability;
using HeroEngine.Model.Heroes;
using System;
public class HeroEngineProgram
{
    public static void Main()
    {
        Warrior pj1 = new Warrior("Esteban");
        Warrior pj2 = new Warrior("David");

        Console.WriteLine(pj1.ToString());
        Console.WriteLine(pj2.ToString());

        AttackSkills atk1 = new AttackSkills("Ataque cortante");
        AttackSkills atk2 = new AttackSkills("ataquemaximo");
        AttackSkills atk3 = new AttackSkills("Ataque sangriento");
        AttackSkills atk4 = new AttackSkills("Ataque laser");

        atk1.Rarity = RarityType.Legendario;
        atk2.Rarity = RarityType.Comun;
        atk3.Rarity = RarityType.Epico;
        atk4.Rarity = RarityType.Raro;

        pj1.AddSkill(atk2);
        pj1.AddSkill(atk4);
        pj1.AddSkill(atk3);
        pj1.AddSkill(atk1);

   


        pj1.Attack(pj2);
        pj1.ShowSkills();
    }
}
