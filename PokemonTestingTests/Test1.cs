using Microsoft.VisualStudio.TestPlatform.TestHost;


namespace PokemonTestingTests;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestMethod1()
    {
        var x = new PokemonApp.DamageHandler();

        Assert.AreEqual(1, x.DamageCheck("Grass",1));


    }
}
