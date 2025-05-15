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

            DamageMultipliers.Add("Normal", 1);
            DamageMultipliers.Add("Fire", 1);
            DamageMultipliers.Add("Water", 1);
            DamageMultipliers.Add("Grass", 1);
        }

        public double DamageCheck(string damageType, double damage)
        {
            if (damage < 0)
            {
                damage = 0;
            }
            return damage * (DamageMultipliers[damageType]);
        }
    }
}
