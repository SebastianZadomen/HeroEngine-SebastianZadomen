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

        pj1.Attack(pj2);
    }
}
