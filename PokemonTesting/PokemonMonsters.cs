using System;

namespace PokemonTesting;

public class PokemonMonsters
{
    //Lastly (For now) creating a pokemon. At this point it is built off a small stack of classes.
    public class Bulbasaur : GrassType
    {
        public override void Cry()
        {
            Console.WriteLine("Bulbasaur!");
        }
    }


    public class Charmander : FireType
    {
        public override void Cry()
        {
            Console.WriteLine("Charmander!");
        }
    }

    public class Squirtle : WaterType
    {
        public override void Cry()
        {
            Console.WriteLine("Squirtle!");
        }
    }
}
