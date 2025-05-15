using System.Collections;
using Microsoft.VisualBasic;

public class PokemonApp
{
    static void Main(string[] args)
    {

        //Create a pokemon and run some of its methods.
        var x = new Bulbasaur();
        x.Cry();
        x.GrassTypeAttack();
        x.BaseTypeAttack();
        x.Cry();

        Console.WriteLine();

        //Create a pokemon and run some of its methods.
        var y = new Charmander();
        y.Cry();
        y.FireTypeAttack();
        y.BaseTypeAttack();
        y.Cry();

        Console.WriteLine();

        //Throw these 2 pokemon into a list, using a shared base type.
        var party = new List<BasePokemonType>();
        party.Add(x);
        party.Add(y);

        foreach (BasePokemonType poke in party)
        {
            //Use methods on each pokemon.
            poke.Cry();
            poke.BaseTypeAttack();
            Console.WriteLine();
        }




        //var builder = WebApplication.CreateBuilder(args);
        //var app = builder.Build();
        //app.MapGet("/", () => "Hello World!");
        //app.Run();
    }




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
    abstract class BasePokemonType : IBasePokemonType
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

    class GrassType : BasePokemonType
    {
        public void GrassTypeAttack()
        {
            Console.WriteLine("Razor Leaf!");
        }
    }

    class FireType : BasePokemonType
    {
        public void FireTypeAttack()
        {
            Console.WriteLine("Ember!");
        }
    }

    class WaterType : BasePokemonType
    {
        public void WaterTypeAttack()
        {
            Console.WriteLine("Water Gun!");
        }
    }


    //Lastly (For now) creating a pokemon. At this point it is built off a small stack of classes.
    class Bulbasaur : GrassType
    {
        public override void Cry()
        {
            Console.WriteLine("Bulbasaur!");
        }
    }


    class Charmander : FireType
    {
        public override void Cry()
        {
            Console.WriteLine("Charmander!");
        }
    }

    class Squirtle : FireType
    {
        public override void Cry()
        {
            Console.WriteLine("Squirtle!");
        }
    }





    /// <summary>
    /// Handles damage susceptability
    /// </summary>
    public class DamageHandler
    {
        //Dictionary that will hold the type of incoming damage and a multiplier.
        //Multiplying incoming damage by this value = expected damage.
        private Dictionary<string, double> DamageMultipliers;

        public DamageHandler()
        {
            DamageMultipliers = new Dictionary<string, double>();

            //Everything defaults to 1.

            //Accounting for both dual-types and immunities, I expect a resistance to be one of...
            //0     -   1 type is immune to this. If 1 type is immune and the other is weak to, assume immunity.
            //0.25  -   Both types resist this
            //0.5   -   1 type resists this
            //1     -   No resistance
            //2     -   1 type is weak to this
            //4     -   Both types are weak to this

            //A resistance will half damage taken, a weakness will double.

            //In the wider scope of the games mechanics, there are also abilities, items, attacks that can
            //further reduce or increase the damage taken, some on the attack and some on the defence.
            //As a few examples...

            //Barrier: halves damage
            //Focus Sash: Ensures the pokemon survives the hit on 1 HP
            //There is an ability that removes immunities, replacing them with neutral damage

            DamageMultipliers.Add("Normal", 1);
            DamageMultipliers.Add("Fire", 1);
            DamageMultipliers.Add("Water", 1);
            DamageMultipliers.Add("Grass", 1);
        }

        public double DamageCheck(string damageType, double damage)
        {
            return damage * (DamageMultipliers[damageType]);
        }
    }


}
