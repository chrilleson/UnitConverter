using UnitConverter.Api.Features.Models;

namespace UnitConverter.Test.UtilityTests;

public class WeightUtilityTests
{
    [Theory]
    [InlineData(Weight.g, 0.001, 1)]
    [InlineData(Weight.hg, 0.00001, 1)]
    [InlineData(Weight.kg, 0.000001, 1)]
    [InlineData(Weight.ton, 0.000000001, 1)]
    public void ConvertToMilligram(Weight unitToConvertFrom, double valueToConvert, double expectedValue)
    {
        var actual = WeightUtility.ConvertToMilligram(unitToConvertFrom, valueToConvert);

        Assert.Equal(expectedValue, actual);
    }

    [Theory]
    [InlineData(Weight.mg, 1, 0.001)]
    [InlineData(Weight.hg, 1, 100)]
    [InlineData(Weight.kg, 1, 1000)]
    [InlineData(Weight.ton, 1, 1000000)]
    public void ConvertToGram(Weight unitToConvertFrom, double valueToConvert, double expectedValue)
    {
        var actual = WeightUtility.ConvertToGram(unitToConvertFrom, valueToConvert);

        Assert.Equal(expectedValue, actual);
    }

    [Theory]
    [InlineData(Weight.mg, 1, 0.00001)]
    [InlineData(Weight.g, 1, 0.01)]
    [InlineData(Weight.kg, 1, 10)]
    [InlineData(Weight.ton, 1, 10000)]
    public void ConvertToHectogram(Weight unitToConvertFrom, double valueToConvert, double expectedValue)
    {
        var actual = WeightUtility.ConvertToHectogram(unitToConvertFrom, valueToConvert);

        Assert.Equal(expectedValue, actual);
    }

    [Theory]
    [InlineData(Weight.mg, 1, 0.000001)]
    [InlineData(Weight.g, 1, 0.001)]
    [InlineData(Weight.hg, 1, 0.1)]
    [InlineData(Weight.ton, 1, 1000)]
    public void ConvertToKilogram(Weight unitToConvertFrom, double valueToConvert, double expectedValue)
    {
        var actual = WeightUtility.ConvertToKilogram(unitToConvertFrom, valueToConvert);

        Assert.Equal(expectedValue, actual);
    }

    [Theory]
    [InlineData(Weight.mg, 1, 0.000000001)]
    [InlineData(Weight.g, 1, 0.000001)]
    [InlineData(Weight.hg, 1, 0.0001)]
    [InlineData(Weight.kg, 1, 0.001)]
    public void ConvertToTon(Weight unitToConvertFrom, double valueToConvert, double expectedValue)
    {
        var actual = WeightUtility.ConvertToTon(unitToConvertFrom, valueToConvert);

        Assert.Equal(expectedValue, actual);
    }
}