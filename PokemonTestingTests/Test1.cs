using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using PokemonTesting;
using static PokemonTesting.PokemonMonsters;


namespace PokemonTestingTests;

[TestClass]
public sealed class Test1
{
    /// <summary>
    /// Check the base damage handler returns the value input.
    /// </summary>
    [TestMethod]
    [DataRow(-99)]
    [DataRow(-25)]
    [DataRow(0)]
    [DataRow(80)]
    [DataRow(100)]
    public void Test_BaseDamageHandler(double inputInt)
    {
        double outputInt = inputInt;
        if (outputInt < 0)
        {
            outputInt = 0;
        }
        //Expectations at this stage:
        //Return the same number. It is being multiplied by 1 inside the method.
        //There will be further tests as the complexity of the system increases.

        //Test adjusted to use double as that's what I used down in the DamageHandler class.

        var x = new Mechanics.DamageHandler();

        Assert.AreEqual(outputInt, x.DamageCheck("Grass", inputInt));
    }




    [TestMethod]
    [DataRow("Grass", 70)]
    [DataRow("Fire", 70)]
    [DataRow("Water", 70)]
    [DataRow("Normal", 70)]
    [DataRow("Null", 70)]
    [DataRow(null, 70)]
    [DataRow("", 70)]

    public void Test_AllTypesDamageHandler(string type, double inputInt)
    {
        //Expected output is identical.
        //Any unexpected should be considered typeless, and deal damage with no modifier.
        //NOTE: The base DamageHandler is NOT the same as normal type.
        //The difference is that Normal type is weak to Fighting, which is not
        //used yet.
        var x = new Mechanics.DamageHandler();

        Assert.AreEqual(inputInt, x.DamageCheck(type, inputInt));
    }


    [TestMethod]
    [DataRow(null, 100, 100, 100, 100)]
    [DataRow("", 100, 100, 100, 100)]
    [DataRow("non-existant type", 100, 100, 100, 100)]
    [DataRow("normal", 100, 100, 100, 100)]
    [DataRow("grass", 100, 50, 200, 50)]
    [DataRow("water", 100, 50, 50, 200)]
    [DataRow("fire", 100, 200, 50, 50)]
    public void Test_DamageTypeModifiers(string type, double damageDealt, double grassExpected, double waterExpected, int fireExpected)
    {
        //Check that a pokemon with a type has different damage modifiers.
        //Normal, Undefined are expected to treat the multiplier as 1, so stay the same.

        //For reference Fire, Water and Grass each should be resistant to 2, weak to 1 and neutral to normal.

        Bulbasaur grass = new Bulbasaur();  //Weak to fire
        Squirtle water = new Squirtle();    //Weak to grass
        Charmander fire = new Charmander(); //Weak to water

        //Check that each Pokemon took the expected damage from this type.
        Assert.AreEqual(grassExpected, grass.TakeDamage(type, damageDealt));
        Assert.AreEqual(waterExpected, water.TakeDamage(type, damageDealt));
        Assert.AreEqual(fireExpected, fire.TakeDamage(type, damageDealt));
    }








}
