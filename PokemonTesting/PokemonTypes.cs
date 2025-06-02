using System;
using static PokemonTesting.Mechanics;

namespace PokemonTesting;


/// <summary>
/// Ensures all classes can do a basic attack and take damage
/// </summary>
interface IBasePokemonType
{
    double BaseTypeAttack(); //Base type attack. Not to be confused with the "Normal" type, which has some resistances.
    double TakeDamage(string Type, double damage); //Multiplies incoming damage based on weaknesses or strengths.
    void Cry(); //Returns a string that the pokemon would say.
}

//The most basic Pokemon class. All pokemon should be able to make a basic attack and take damage, so the DamageHandler is here.
//If we do anything with dealing damage, it will be introduced at this level also.
//Inherits the Interface IBasePokemonType to ensure it has the bits it needs.
public abstract class BasePokemonType : IBasePokemonType
{
    public DamageHandler damageHandler = new DamageHandler();
    public double BaseTypeAttack()
    {
        Console.WriteLine("Basic Tackle!");
        return 100;
    }

    //Passes the damage and type to its internal DamageHandler object.
    public double TakeDamage(string Type, double damage)
    {
        return damageHandler.DamageCheck(Type, damage);
    }

    public virtual void Cry()
    {
        Console.WriteLine("Cry: Pokemon!");
    }
}



public abstract class GrassType : BasePokemonType
{
    public GrassType()
    {
        var x = new Dictionary<string, double>();
        x.Add("fire", 2);
        x.Add("water",0.5);
        x.Add("grass", 0.5);

        damageHandler.MergeDamageMultipliers(x);
    }

    public void GrassTypeAttack()
    {
        Console.WriteLine("Razor Leaf!");
    }
}

public abstract class FireType : BasePokemonType
{
    public FireType()
    {
        var x = new Dictionary<string, double>();
        x.Add("fire", 0.5);
        x.Add("water",2);
        x.Add("grass", 0.5);

        base.damageHandler.MergeDamageMultipliers(x);
    }

    public void FireTypeAttack()
    {
        Console.WriteLine("Ember!");
    }
}

public abstract class WaterType : BasePokemonType
{
    public WaterType()
    {
        var x = new Dictionary<string, double>();
        x.Add("fire", 0.5);
        x.Add("water",0.5);
        x.Add("grass", 2);

        base.damageHandler.MergeDamageMultipliers(x);
    }

    public void WaterTypeAttack()
    {
        Console.WriteLine("Water Gun!");
    }
}
