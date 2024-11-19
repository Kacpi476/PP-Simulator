using Simulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 0, 10, 5)]
    [InlineData(-5, 0, 10, 0)]
    [InlineData(15, 0, 10, 10)]
    public void Limiter_ShouldLimitValueCorrectly(int value, int min, int max, int expected)
    {
        Assert.Equal(expected, Validator.Limiter(value, min, max));
    }

    [Theory]
    [InlineData("test", 5, 10, '*', "test*****")]  // Padding
    [InlineData("toolongstring", 5, 10, '*', "toolongs")] // Trimming
    [InlineData("fit", 3, 6, '*', "fit")]  // Within range
    public void Shortener_ShouldAdjustStringCorrectly(string value, int min, int max, char placeholder, string expected)
    {
        Assert.Equal(expected, Validator.Shortener(value, min, max, placeholder));
    }
}