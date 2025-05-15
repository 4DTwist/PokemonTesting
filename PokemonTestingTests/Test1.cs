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
    public void Test_BaseDamageHandler()
    {
        var x = new Mechanics.DamageHandler();
        Assert.AreEqual(1, x.DamageCheck("Grass",1));
    }
}
