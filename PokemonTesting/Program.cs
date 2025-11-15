using System.Collections;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using Microsoft.VisualBasic;
using static PokemonTesting.EnumeratorTestingClass;
using static PokemonTesting.Mechanics;
using static PokemonTesting.PokemonMonsters;


namespace PokemonTesting;

public class PokemonApp
{

    static void IntroText()
    {
        Console.WriteLine("Pokemon Type quiz!");
        Console.WriteLine("In Pokemon, there are 18 types, and Pokemon can have 1 or 2...");
        Console.WriteLine("What if they had 3? Or 5?");
        Console.WriteLine("And what if attacks had up to 5 types mixed in?");
        Console.WriteLine();
    }

    static int GetUserAttackCount()
    {
        int typesInAttacks = 0;
        bool loopControl = true;
        while (loopControl)
        {
            Console.WriteLine("How many types do you want your attacks to have? (Between 1 and 5)");
            string? input = Console.ReadLine();
            Console.WriteLine();

            //Predicted outcomes:
            //Null or white space
            //Could not parse
            //Too high
            //Too low
            //In range



            if (string.IsNullOrWhiteSpace(input))    //Null/blank check
            {
                Console.WriteLine("Whoops! Looks like you didn't type anything.");
                continue;
            }


            try //todo: Configure this as a tryparse instead.
            {
                typesInAttacks = Convert.ToInt32(input);
            }
            catch
            {
                Console.WriteLine("Whoops! Please enter your number as digits.");
                continue;
            }

            if (typesInAttacks == 0)
            {
                Console.WriteLine(typesInAttacks + "0? I don't think there are any types or monster that are truly typeless. You'll need to give me a number between 1 and 5.");
                continue;
            }

            if (typesInAttacks < 0)
            {

                Console.WriteLine(typesInAttacks + " ? I don't know how I could do negative typing... Would that invert the strengths and weaknesses? You'll need to give me a number between 1 and 5.");
                continue;
            }

            if (typesInAttacks > 5)
            {
                Console.WriteLine(typesInAttacks + "? Wow, that's ambitious, but I need to have a limit somewhere. For now, that limit is 5 so I'll set you to that.");
                typesInAttacks = 5;
                loopControl = false;
                continue;
            }

            if (typesInAttacks < 6 && typesInAttacks > 0)
            {
                Console.WriteLine("OK, " + typesInAttacks + " attack types it is!");
                loopControl = false;
                continue;
            }
        }
        return typesInAttacks;
    }

static int GetUserDefenceCount()
    {
        int typesInDefences = 0;
        bool loopControl = true;
        while (loopControl)
        {
            Console.WriteLine("How many types do you want your targets to have? (Between 1 and 5)");
            string? input = Console.ReadLine();
            Console.WriteLine();

            //Predicted outcomes:
            //Null or white space
            //Could not parse
            //Too high
            //Too low
            //In range



            if (string.IsNullOrWhiteSpace(input))    //Null/blank check
            {
                Console.WriteLine("Whoops! Looks like you didn't type anything.");
                continue;
            }


            try //todo: Configure this as a tryparse instead.
            {
                typesInDefences = Convert.ToInt32(input);
            }
            catch
            {
                Console.WriteLine("Whoops! Please enter your number as digits.");
                continue;
            }

            if (typesInDefences == 0)
            {
                Console.WriteLine(typesInDefences + "0? I don't think there are any monsters that are truly typeless. You'll need to give me a number between 1 and 5.");
                continue;
            }

            if (typesInDefences < 0)
            {

                Console.WriteLine(typesInDefences + " ? I don't know how I could do negative typing... Would that invert the strengths and weaknesses? You'll need to give me a number between 1 and 5.");
                continue;
            }

            if (typesInDefences > 5)
            {
                Console.WriteLine(typesInDefences + "? Wow, that's ambitious, but I need to have a limit somewhere. For now, that limit is 5 so I'll set you to that.");
                typesInDefences = 5;
                loopControl = false;
                continue;
            }

            if (typesInDefences < 6 && typesInDefences > 0)
            {
                Console.WriteLine("OK, " + typesInDefences + " target types it is!");
                loopControl = false;
                continue;
            }
        }
        return typesInDefences;
    }








    static void Main(string[] args)
    {
        IntroText();

        int typesInAttacks = GetUserAttackCount();
        int typesInDefence = GetUserDefenceCount();

        Console.WriteLine("OK! So, your attacks will have " + typesInAttacks + " random types, and your defending target will have " + typesInDefence + " random types.");
        Console.WriteLine("Lets go!");
        Console.WriteLine();



        //Input via a command line for this will suck with either fractions or decimals, but will feel way better once there is a UI on the front of it.
        //Alternatively, I know there are more advanced command line functions that allow for option selection via arrow keys. Those would all allow for a better experience...

        //Briefly speaking, with 5 types we *could* theoretically end up at insane multipliers.
        //If we take the example of 2 attack types that are *both* super effective against *both* target types, then we go straight from 1x to 16x.
        //If the same again happened with 3 types on each side we doulb e9 times, and we end up at 512x!
        
        List<string> validAnswers = new List<string>()
        {
                "1/33554432",
                "1/16777216",
                "1/8388608",
                "1/4194304",
                "1/2097152",
                "1/1048576",
                "1/524288",
                "1/262144",
                "1/131072",
                "1/65536",
                "1/32768",
                "1/16384",
                "1/8192",
                "1/4096",
                "1/2048",
                "1/1024",
                "1/512",
                "1/256",
                "1/128",
                "1/64",
                "1/32",
                "1/16",
                "1/8",
                "1/4",
                "1/2",

                "0",

                "1",
                "2",
                "4",
                "8",
                "16",
                "32",
                "64",
                "128",
                "256",
                "512",
                "1024",
                "2048",
                "4096",
                "8192",
                "16384",
                "32768",
                "65536",
                "131072",
                "262144",
                "524288",
                "1048576",
                "2097152",
                "4194304",
                "8388608",
                "16777216",
                "33554432",
            };


        int round = 1;
        int score = 0;


        while (loopControl)
        {

            List<string> attackTypesToUse = GetTypesList(typesInAttacks);
            List<string> defenceTypesToUse = GetTypesList(typesInDefence);

            attackTypesToUse.Order();
            defenceTypesToUse.Order();

            decimal answer = TypeMatchupChart.CalculateMultiplier(attackTypesToUse, defenceTypesToUse); //Get answer early for debugging.
            Console.WriteLine("ANSWER FOR DEBUGGING: " + answer);


            Console.WriteLine("Round " + round + ", Score: " + score);
            Console.Write("The attack has types: ");
            foreach (string typeToWrite in attackTypesToUse)
            {
                Console.Write(typeToWrite + ", ");
            }
            Console.WriteLine();

            Console.Write("The target has types: ");
            foreach (string typeToWrite in defenceTypesToUse)
            {
                Console.Write(typeToWrite + ", ");
            }
            Console.WriteLine();
            Console.WriteLine("What damage multiplier will the attack have?");


            string validCharacters = "0123456789.";



            string? playerAnswerRaw = Console.ReadLine();

            playerAnswerRaw = Regex.Replace(playerAnswerRaw, @"[^0-9/]", "");

            int firstDot = playerAnswerRaw.IndexOf('.');
            if (firstDot != -1)
            {
                playerAnswerRaw = playerAnswerRaw.Substring(0, firstDot + 1) + playerAnswerRaw.Substring(firstDot + 1).Replace(".", "");
            }

            double playerAnswer = Convert.ToDouble(playerAnswerRaw);

            string stringyAnswer =

            if (answer == playerAnswer)
            {
                Console.WriteLine("That's right! Your score increases by " + (typesInAttacks * typesInDefence));
                score += typesInAttacks * typesInDefence;
            }
            else
            {
                Console.WriteLine("The correct answer was: " + answer);
            }
            round++;

        }







        //  Compare behind the scenes
        //  Ask the user what they reckon
        //  Return success or failure
        //  Summarise what happened
        //
        //
        //
        //


















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

    private static List<string> GetTypesList(int typesInAttacks)
    {
        List<string> attackTypesToUse = new List<string>();

        List<string> typesToSelect = TypeMatchupChart.types.ToList<string>();

        for (int i = 0; i < typesInAttacks; i++)
        {
            int iterator = Convert.ToInt32(Random.Shared.NextInt64(0, typesToSelect.Count));
            attackTypesToUse.Add(typesToSelect[iterator]);
            typesToSelect.RemoveAt(iterator);
        }

        return attackTypesToUse;
    }




    static string formatNumber(decimal input)
    {
        return getFraction(input);
    }


    static string getFraction(decimal input)
    {


        //input = 0.125m;
        int precision = 1000000; // Higher = more accurate
        int numerator = (int)(input * precision);
        int denominator = precision;

        int gcd = GCD(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;

        return numerator + "/" + denominator;

    }


    static int GCD(int a, int b)
    {
        return b == 0 ? a : GCD(b, a % b);
    }




}
