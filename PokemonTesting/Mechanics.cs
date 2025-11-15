using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Formats.Tar;

namespace PokemonTesting;

public class Mechanics
{
    /// <summary>
    /// Handles damage susceptability
    /// </summary>

    public static class TypeMatchupChart
    {
        static TypeMatchupChart()
        {
            InitialiseLists();
        }

        public static Dictionary<Tuple<string, string>, decimal> matchupDictionary = new Dictionary<Tuple<string, string>, decimal>();//Populated in InitialiseLists, due to the size of it.

        public static List<string> types = new List<string>()
        {
        "normal",
        "fire",
        "water",
        "grass",
        "electric",
        "ice",
        "fighting",
        "poison",
        "ground",
        "flying",
        "psychic",
        "bug",
        "rock",
        "ghost",
        "dragon",
        "dark",
        "steel",
        "fairy"
        };

        //Initialises the global base type list.
        public static void InitialiseLists()
        {
            //Built the official list up in a Google Doc, then used some string formatting to generate the add functions.
            //Easy to edit over there and import back into here. 
            //https://docs.google.com/spreadsheets/d/1FOkYsqQs1zDdVWggiSG3pbfjZmIqVb7aTMoqBraxUMI/edit?usp=sharing

            //It would be trivial to store this data in a different structure and import it into memory.
            //It would also be easy to store it in a database and retrieve it, but seeing as it is a lot of data that doesn't change much
            //nor *need* to change much, a list like this will do for now.

            //As a rough example, I've provided some linq pseudocode that could be used to do so. It aims to get the table from the DB with LINQ quickly, and then process it without holding a DB connection.
            //Assume the table contains "ID" as Guid, "Source" and "Target" as string, and "Multiplier" as a float.

            //List<T> dbTypesData;
            //using(var database = new DatabaseContext())
            //{
            //dbTypesData = database.TypeChart().ReadOnly().ToList(); //Assuming a DBContext exists, will get the data from that table.
            //} //Close the using as soon as we're done with it.

            //foreach(var dbRecord in typesData)
            //{
            //AddType(dbRecord.Source, dbRecord.Target, dbRecord.Multiplier);
            //}
AddType("normal","normal",1m);	AddType("normal","fire",1m);	AddType("normal","water",1m);	AddType("normal","grass",1m);	AddType("normal","electric",1m);	AddType("normal","ice",1m);	AddType("normal","fighting",1m);	AddType("normal","poison",1m);	AddType("normal","ground",1m);	AddType("normal","flying",1m);	AddType("normal","psychic",1m);	AddType("normal","bug",1m);	AddType("normal","rock",0.5m);	AddType("normal","ghost",0m);	AddType("normal","dragon",1m);	AddType("normal","dark",1m);	AddType("normal","steel",0.5m);	AddType("normal","fairy",1m);	AddType("normal","base",1m);
AddType("fire","normal",1m);	AddType("fire","fire",0.5m);	AddType("fire","water",0.5m);	AddType("fire","grass",2m);	AddType("fire","electric",1m);	AddType("fire","ice",2m);	AddType("fire","fighting",1m);	AddType("fire","poison",1m);	AddType("fire","ground",1m);	AddType("fire","flying",1m);	AddType("fire","psychic",1m);	AddType("fire","bug",2m);	AddType("fire","rock",0.5m);	AddType("fire","ghost",1m);	AddType("fire","dragon",0.5m);	AddType("fire","dark",1m);	AddType("fire","steel",2m);	AddType("fire","fairy",1m);	AddType("fire","base",1m);
AddType("water","normal",1m);	AddType("water","fire",2m);	AddType("water","water",0.5m);	AddType("water","grass",0.5m);	AddType("water","electric",1m);	AddType("water","ice",1m);	AddType("water","fighting",1m);	AddType("water","poison",1m);	AddType("water","ground",2m);	AddType("water","flying",1m);	AddType("water","psychic",1m);	AddType("water","bug",1m);	AddType("water","rock",2m);	AddType("water","ghost",1m);	AddType("water","dragon",0.5m);	AddType("water","dark",1m);	AddType("water","steel",1m);	AddType("water","fairy",1m);	AddType("water","base",1m);
AddType("grass","normal",1m);	AddType("grass","fire",0.5m);	AddType("grass","water",2m);	AddType("grass","grass",0.5m);	AddType("grass","electric",1m);	AddType("grass","ice",1m);	AddType("grass","fighting",1m);	AddType("grass","poison",0.5m);	AddType("grass","ground",2m);	AddType("grass","flying",0.5m);	AddType("grass","psychic",1m);	AddType("grass","bug",0.5m);	AddType("grass","rock",2m);	AddType("grass","ghost",1m);	AddType("grass","dragon",0.5m);	AddType("grass","dark",1m);	AddType("grass","steel",1m);	AddType("grass","fairy",1m);	AddType("grass","base",1m);
AddType("electric","normal",1m);	AddType("electric","fire",1m);	AddType("electric","water",2m);	AddType("electric","grass",0.5m);	AddType("electric","electric",0.5m);	AddType("electric","ice",1m);	AddType("electric","fighting",1m);	AddType("electric","poison",1m);	AddType("electric","ground",0m);	AddType("electric","flying",2m);	AddType("electric","psychic",1m);	AddType("electric","bug",1m);	AddType("electric","rock",1m);	AddType("electric","ghost",1m);	AddType("electric","dragon",0.5m);	AddType("electric","dark",1m);	AddType("electric","steel",1m);	AddType("electric","fairy",1m);	AddType("electric","base",1m);
AddType("ice","normal",1m);	AddType("ice","fire",0.5m);	AddType("ice","water",0.5m);	AddType("ice","grass",2m);	AddType("ice","electric",1m);	AddType("ice","ice",0.5m);	AddType("ice","fighting",1m);	AddType("ice","poison",1m);	AddType("ice","ground",2m);	AddType("ice","flying",2m);	AddType("ice","psychic",1m);	AddType("ice","bug",1m);	AddType("ice","rock",1m);	AddType("ice","ghost",1m);	AddType("ice","dragon",2m);	AddType("ice","dark",1m);	AddType("ice","steel",0.5m);	AddType("ice","fairy",1m);	AddType("ice","base",1m);
AddType("fighting","normal",2m);	AddType("fighting","fire",1m);	AddType("fighting","water",1m);	AddType("fighting","grass",1m);	AddType("fighting","electric",1m);	AddType("fighting","ice",2m);	AddType("fighting","fighting",1m);	AddType("fighting","poison",0.5m);	AddType("fighting","ground",1m);	AddType("fighting","flying",0.5m);	AddType("fighting","psychic",0.5m);	AddType("fighting","bug",0.5m);	AddType("fighting","rock",2m);	AddType("fighting","ghost",0m);	AddType("fighting","dragon",1m);	AddType("fighting","dark",2m);	AddType("fighting","steel",2m);	AddType("fighting","fairy",0.5m);	AddType("fighting","base",1m);
AddType("poison","normal",1m);	AddType("poison","fire",1m);	AddType("poison","water",1m);	AddType("poison","grass",2m);	AddType("poison","electric",1m);	AddType("poison","ice",1m);	AddType("poison","fighting",1m);	AddType("poison","poison",0.5m);	AddType("poison","ground",0.5m);	AddType("poison","flying",1m);	AddType("poison","psychic",1m);	AddType("poison","bug",1m);	AddType("poison","rock",0.5m);	AddType("poison","ghost",0.5m);	AddType("poison","dragon",1m);	AddType("poison","dark",1m);	AddType("poison","steel",0m);	AddType("poison","fairy",2m);	AddType("poison","base",1m);
AddType("ground","normal",1m);	AddType("ground","fire",2m);	AddType("ground","water",1m);	AddType("ground","grass",0.5m);	AddType("ground","electric",2m);	AddType("ground","ice",1m);	AddType("ground","fighting",1m);	AddType("ground","poison",2m);	AddType("ground","ground",1m);	AddType("ground","flying",0m);	AddType("ground","psychic",1m);	AddType("ground","bug",0.5m);	AddType("ground","rock",2m);	AddType("ground","ghost",1m);	AddType("ground","dragon",1m);	AddType("ground","dark",1m);	AddType("ground","steel",0.5m);	AddType("ground","fairy",1m);	AddType("ground","base",1m);
AddType("flying","normal",1m);	AddType("flying","fire",1m);	AddType("flying","water",1m);	AddType("flying","grass",2m);	AddType("flying","electric",0.5m);	AddType("flying","ice",1m);	AddType("flying","fighting",2m);	AddType("flying","poison",1m);	AddType("flying","ground",1m);	AddType("flying","flying",1m);	AddType("flying","psychic",1m);	AddType("flying","bug",2m);	AddType("flying","rock",0.5m);	AddType("flying","ghost",1m);	AddType("flying","dragon",1m);	AddType("flying","dark",1m);	AddType("flying","steel",0.5m);	AddType("flying","fairy",1m);	AddType("flying","base",1m);
AddType("psychic","normal",1m);	AddType("psychic","fire",1m);	AddType("psychic","water",1m);	AddType("psychic","grass",1m);	AddType("psychic","electric",1m);	AddType("psychic","ice",1m);	AddType("psychic","fighting",2m);	AddType("psychic","poison",2m);	AddType("psychic","ground",1m);	AddType("psychic","flying",1m);	AddType("psychic","psychic",0.5m);	AddType("psychic","bug",1m);	AddType("psychic","rock",1m);	AddType("psychic","ghost",1m);	AddType("psychic","dragon",1m);	AddType("psychic","dark",0m);	AddType("psychic","steel",0.5m);	AddType("psychic","fairy",1m);	AddType("psychic","base",1m);
AddType("bug","normal",1m);	AddType("bug","fire",0.5m);	AddType("bug","water",1m);	AddType("bug","grass",2m);	AddType("bug","electric",1m);	AddType("bug","ice",1m);	AddType("bug","fighting",0.5m);	AddType("bug","poison",0.5m);	AddType("bug","ground",1m);	AddType("bug","flying",0.5m);	AddType("bug","psychic",2m);	AddType("bug","bug",1m);	AddType("bug","rock",1m);	AddType("bug","ghost",0.5m);	AddType("bug","dragon",1m);	AddType("bug","dark",2m);	AddType("bug","steel",0.5m);	AddType("bug","fairy",0.5m);	AddType("bug","base",1m);
AddType("rock","normal",1m);	AddType("rock","fire",2m);	AddType("rock","water",1m);	AddType("rock","grass",1m);	AddType("rock","electric",1m);	AddType("rock","ice",2m);	AddType("rock","fighting",0.5m);	AddType("rock","poison",1m);	AddType("rock","ground",0.5m);	AddType("rock","flying",2m);	AddType("rock","psychic",1m);	AddType("rock","bug",2m);	AddType("rock","rock",1m);	AddType("rock","ghost",1m);	AddType("rock","dragon",1m);	AddType("rock","dark",1m);	AddType("rock","steel",0.5m);	AddType("rock","fairy",1m);	AddType("rock","base",1m);
AddType("ghost","normal",0m);	AddType("ghost","fire",1m);	AddType("ghost","water",1m);	AddType("ghost","grass",1m);	AddType("ghost","electric",1m);	AddType("ghost","ice",1m);	AddType("ghost","fighting",1m);	AddType("ghost","poison",1m);	AddType("ghost","ground",1m);	AddType("ghost","flying",1m);	AddType("ghost","psychic",2m);	AddType("ghost","bug",1m);	AddType("ghost","rock",1m);	AddType("ghost","ghost",2m);	AddType("ghost","dragon",1m);	AddType("ghost","dark",0.5m);	AddType("ghost","steel",1m);	AddType("ghost","fairy",1m);	AddType("ghost","base",1m);
AddType("dragon","normal",1m);	AddType("dragon","fire",1m);	AddType("dragon","water",1m);	AddType("dragon","grass",1m);	AddType("dragon","electric",1m);	AddType("dragon","ice",1m);	AddType("dragon","fighting",1m);	AddType("dragon","poison",1m);	AddType("dragon","ground",1m);	AddType("dragon","flying",1m);	AddType("dragon","psychic",1m);	AddType("dragon","bug",1m);	AddType("dragon","rock",1m);	AddType("dragon","ghost",1m);	AddType("dragon","dragon",2m);	AddType("dragon","dark",1m);	AddType("dragon","steel",0.5m);	AddType("dragon","fairy",0m);	AddType("dragon","base",1m);
AddType("dark","normal",1m);	AddType("dark","fire",1m);	AddType("dark","water",1m);	AddType("dark","grass",1m);	AddType("dark","electric",1m);	AddType("dark","ice",1m);	AddType("dark","fighting",1m);	AddType("dark","poison",0.5m);	AddType("dark","ground",1m);	AddType("dark","flying",1m);	AddType("dark","psychic",2m);	AddType("dark","bug",1m);	AddType("dark","rock",1m);	AddType("dark","ghost",2m);	AddType("dark","dragon",1m);	AddType("dark","dark",0.5m);	AddType("dark","steel",1m);	AddType("dark","fairy",0.5m);	AddType("dark","base",1m);
AddType("steel","normal",1m);	AddType("steel","fire",0.5m);	AddType("steel","water",0.5m);	AddType("steel","grass",1m);	AddType("steel","electric",0.5m);	AddType("steel","ice",2m);	AddType("steel","fighting",1m);	AddType("steel","poison",1m);	AddType("steel","ground",1m);	AddType("steel","flying",1m);	AddType("steel","psychic",1m);	AddType("steel","bug",1m);	AddType("steel","rock",2m);	AddType("steel","ghost",1m);	AddType("steel","dragon",1m);	AddType("steel","dark",1m);	AddType("steel","steel",0.5m);	AddType("steel","fairy",2m);	AddType("steel","base",1m);
AddType("fairy","normal",1m);	AddType("fairy","fire",0.5m);	AddType("fairy","water",1m);	AddType("fairy","grass",1m);	AddType("fairy","electric",1m);	AddType("fairy","ice",1m);	AddType("fairy","fighting",1m);	AddType("fairy","poison",2m);	AddType("fairy","ground",0.5m);	AddType("fairy","flying",1m);	AddType("fairy","psychic",1m);	AddType("fairy","bug",1m);	AddType("fairy","rock",1m);	AddType("fairy","ghost",1m);	AddType("fairy","dragon",2m);	AddType("fairy","dark",2m);	AddType("fairy","steel",0.5m);	AddType("fairy","fairy",1m);	AddType("fairy","base",1m);
AddType("base","normal",1m);	AddType("base","fire",1m);	AddType("base","water",1m);	AddType("base","grass",1m);	AddType("base","electric",1m);	AddType("base","ice",1m);	AddType("base","fighting",1m);	AddType("base","poison",1m);	AddType("base","ground",1m);	AddType("base","flying",1m);	AddType("base","psychic",1m);	AddType("base","bug",1m);	AddType("base","rock",1m);	AddType("base","ghost",1m);	AddType("base","dragon",1m);	AddType("base","dark",1m);	AddType("base","steel",1m);	AddType("base","fairy",1m);	AddType("base","base",1m);


        }

        public static void AddType(string Source, string Target, decimal Multiplier)
        {
            matchupDictionary.Add(new Tuple<string, string>(Source, Target), Multiplier);
        }

        public static decimal GetMulti(string Source, string Target)
        {
            return matchupDictionary[new Tuple<string, string>(Source, Target)];
        }



        public static decimal CalculateMultiplier(List<string> Source, List<string> Target)
        {
            //Unless a 0 is found, this will calculate every combination contained.
            decimal Multi = 1;

            foreach (string sourceType in Source)
            {
                foreach (string targetType in Target)
                {
                    if (Multi == 0) return 0; //Will go to, and stay at 0.
                    var interactionMultiplier = GetMulti(sourceType, targetType);
                    if (interactionMultiplier != 1) Multi = Multi * interactionMultiplier;
                }
            }
            return Multi;
        }
    }



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

            //Due to mechanical changes, values of 1 can be removed.
            //Leaving here for now for readability, once type management is
            //more mature, shall remove.
            DamageMultipliers.Add("normal", 1);
            DamageMultipliers.Add("fire", 1);
            DamageMultipliers.Add("water", 1);
            DamageMultipliers.Add("grass", 1);
        }

        //Multiplies each record against its counterpart.
        //If counterpart does not exist, add.
        //If result is 1, remove.
        public void MergeDamageMultipliers(Dictionary<string, double> incMultis)
        {
            foreach (var x in incMultis.Keys)
            {
                if (DamageMultipliers.ContainsKey(x))
                {
                    //If exists, multiply together
                    DamageMultipliers[x] *= incMultis[x];
                }
                else
                {
                    //If not, add.
                    DamageMultipliers.Add(x, incMultis[x]);
                }
                if (DamageMultipliers[x] == 1)
                {
                    //If the record now == 1, remove it.
                    //1 is handled as a direct pass-through.
                    DamageMultipliers.Remove(x);
                }
            }
        }

        //Overrides specified damage multipliers.
        //Could be merged with the above via a selector variable since it is
        // a very similar loop, but readability would suffer a lot.
        public void OverrideDamageMultipliers(Dictionary<string, double> incMultis)
        {
            foreach (var x in incMultis.Keys)
            {
                if (DamageMultipliers.ContainsKey(x))
                {
                    //If exists, override.
                    DamageMultipliers[x] = incMultis[x];
                }
                else
                {
                    //If not, add.
                    DamageMultipliers.Add(x, incMultis[x]);
                }
                if (DamageMultipliers[x] == 1)
                {
                    //If the record now == 1, remove it.
                    //1 is handled as a direct pass-through.
                    DamageMultipliers.Remove(x);
                }
            }
        }

        public double DamageCheck(string damageType, double damage)
        {
            //If 0 or less damage, return 0.
            if (damage < 0)
            {
                return 0;
            }

            if (damageType == null)
            {
                return damage;
            }

            //Does the requested damage type exist?
            if (DamageMultipliers.ContainsKey(damageType) == false)
            {
                //Assume typeless, return raw damage.
                //If we ever have a "Null" or "Void" type, we'll want it to have resistance like anything else.
                return damage;
            }

            //Multiply by the types modifier.
            return damage * (DamageMultipliers[damageType]);
        }
    }
}
