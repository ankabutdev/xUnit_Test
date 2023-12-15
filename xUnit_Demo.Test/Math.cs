using xUnit_Demo.MathExtensions;

namespace xUnit_Demo.Test;

public class Math
{
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    public void ReturnFalseWhenNumberIsLessThen2(int number)
    {
        Assert.False(MathExtension.IsPrime(number), $"{number} Prime");
    }

    [Theory]
    [InlineData(4)]
    [InlineData(111)]
    [InlineData(9)]
    [InlineData(15)]
    public void ReturnFalseWhenNotPrimeNumberGiven(int number)
    {
        Assert.False(MathExtension.IsPrime(number), $"{number} is not Prime");
    }

    [Fact]
    public void ReturnsTrueWhenGiven2()
    {
        Assert.True(MathExtension.IsPrime(2));
    }
}