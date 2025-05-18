using System;

namespace PokemonTesting;

public class Mechanics
{
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
