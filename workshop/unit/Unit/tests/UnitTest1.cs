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

    [Fact]
    public void xxx()
    {
        // Arrange
        var spy = new SpyRandom();

        GenerateNumber g = new GenerateNumber(spy); // Constructor Injection
        // Act
        g.getResult();
        // Assert
        Assert.True(spy.Verify(1));
    }


}

class SpyRandom : Random
{
    private int _count;
    public bool Verify(int called)
    {
        return this._count == called;
    }
    public override int Next(int maxValue)
    {
        _count++;
        return 5;
    }
}

class StubRandom : Random
{
    public override int Next(int maxValue)
    {
        return 5;
    }
}
