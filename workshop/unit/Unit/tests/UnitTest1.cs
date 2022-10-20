using src;

namespace tests;

public class UnitTest1
{
    [Fact]
    public void TestWithRandom5()
    {
        // Arrange
        GenerateNumber g = new GenerateNumber();
        // Act
        string actualResult = g.getResult();
        // Assert
        Assert.Equal("No5", actualResult);
    }


}
