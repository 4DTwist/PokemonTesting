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
    [DataRow("Normal", 100, 100, 100, 100)]
    [DataRow("Fire", 100, 200, 50, 50)]
    [DataRow("Water", 100, 50, 50, 200)]
    [DataRow("Grass", 100, 50, 200, 50)]
    public void Test_DamageTypeModifiers(string type, double damageDealt, double grassExpected, double waterExpected, int fireExpected)
    {
        //Check that a pokemon with a type has different damage modifiers.
        //For reference, each should be resistant to 2, weak to 1 and neutral to normal.

        Bulbasaur grass = new Bulbasaur();  //Weak to fire
        Squirtle water = new Squirtle();    //Weak to grass
        Charmander fire = new Charmander();//Weak to water

        //At the time of writing, TakeDamage does not store damage taken, or
        //return any data. Test is written to expect data.
        //Assert.AreEqual(grassExpected, grass.TakeDamage(type, damageDealt));
        //Assert.AreEqual(waterExpected, water.TakeDamage(type, damageDealt));
        //Assert.AreEqual(grassExpected, fire.TakeDamage(type, damageDealt));

        //Forcing a throw at present to simulate this, given that this is a case
        //where the test needs new functionality, not work on existing methods.
        Assert.IsTrue(false);

    }








}
