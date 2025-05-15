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
    public void Test_BaseDamageHandler(int inputInt)
    {
        int outputInt = inputInt;
        if (outputInt < 0)
        {
            outputInt = 0;
        }
        //Expectations at this stage:
        //ABS the number. Anything below 0 should be treated as 0.
        //Return the same number. It is being multiplied by 1 inside the method.
        //There will be further tests as the complexity of the system increases.
        //We may run into issues using an Int as our numeric data type. Consider Double/Decimal etc. Probably Decimal.

        var x = new Mechanics.DamageHandler();
        Assert.AreEqual(outputInt, x.DamageCheck("Grass", inputInt));
    }
}
