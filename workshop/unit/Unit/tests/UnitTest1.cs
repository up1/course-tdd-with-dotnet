using src;

namespace tests;

public class UnitTest1
{
    [Fact]
    public void TestWithRandom5()
    {
        // Arrange
        var random = new StubRandom();

        GenerateNumber g = new GenerateNumber(random); // Constructor Injection
        // Act
        string actualResult = g.getResult();
        // Assert
        Assert.Equal("No5", actualResult);
    }


}

class StubRandom : Random
{
    public override int Next(int maxValue)
    {
        return 5;
    }
}
