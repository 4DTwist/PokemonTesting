using System.Collections;
using Microsoft.VisualBasic;
using static PokemonTesting.EnumeratorTestingClass;
using static PokemonTesting.PokemonMonsters;


namespace PokemonTesting;

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



        PokemonList<BasePokemonType> listOfPokes = new PokemonList<BasePokemonType>();

        //listOfPokes.Add(x);
        listOfPokes.AddRange([x, y]);





        foreach (BasePokemonType pokeInLoop in listOfPokes)
        {
            pokeInLoop.Cry();
        }



        Console.WriteLine(listOfPokes.ExtendedMethodExample());










        //var builder = WebApplication.CreateBuilder(args);
        //var app = builder.Build();
        //app.MapGet("/", () => "Hello World!");
        //app.Run();
    }
}
