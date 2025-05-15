using Microsoft.VisualStudio.TestPlatform.TestHost;
using PokemonTesting;


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
    [DataRow("",70)]
    
    public void Test_AllTypesDamageHandler(string type, double inputInt)
    {
        //Expected output is identical.
        //Any unexpected should be considered typeless, and deal damage with no modifier.
        var x = new Mechanics.DamageHandler();

        Assert.AreEqual(inputInt, x.DamageCheck(type, inputInt));
    }




}
