using System;
using static PokemonTesting.Mechanics;

namespace PokemonTesting;


/// <summary>
/// Ensures all classes can do a basic attack and take damage
/// </summary>
interface IBasePokemonType
{
    void BaseTypeAttack(); //Base type attack. Not to be confused with the "Normal" type, which has some resistances.
    void TakeDamage(string Type, double damage); //Multiplies incoming damage based on weaknesses or strengths.
    void Cry(); //Returns a string that the pokemon would say.
}

//The most basic Pokemon class. All pokemon should be able to make a basic attack and take damage, so the DamageHandler is here.
//If we do anything with dealing damage, it will be introduced at this level also.
//Inherits the Interface IBasePokemonType to ensure it has the bits it needs.
public abstract class BasePokemonType : IBasePokemonType
{
    private DamageHandler damageHandler = new DamageHandler();
    public void BaseTypeAttack()
    {
        Console.WriteLine("Basic Tackle!");
    }

    //Passes the damage and type to its internal DamageHandler object.
    public void TakeDamage(string Type, double damage)
    {
        damageHandler.DamageCheck(Type, damage);
    }

    public virtual void Cry()
    {
        Console.WriteLine("Cry: Pokemon!");
    }
}



public abstract class GrassType : BasePokemonType
{
    public void GrassTypeAttack()
    {
        Console.WriteLine("Razor Leaf!");
    }
}

public abstract class FireType : BasePokemonType
{
    public void FireTypeAttack()
    {
        Console.WriteLine("Ember!");
    }
}

public abstract class WaterType : BasePokemonType
{
    public void WaterTypeAttack()
    {
        Console.WriteLine("Water Gun!");
    }
}
