using UnitConverter.Api.Features.Models;

namespace UnitConverter.Test.UtilityTests;

public class LengthUtilityTests
{
    [Theory]
    [InlineData(Length.cm, 1, 10)]
    [InlineData(Length.dm, 1, 100)]
    [InlineData(Length.m, 1, 1000)]
    [InlineData(Length.km, 1, 0.000001)]
    [InlineData(Length.mil, 1, 0.0000001)]
    public void ConvertToMillimeter(Length lengthToConvertFrom, double valueToConvert, double expectedValue)
    {
        var actual = LenghtUtility.ConvertToMillimeter(lengthToConvertFrom, valueToConvert);

        Assert.Equal(expectedValue, actual);
    }

    [Theory]
    [InlineData(Length.mm, 10, 1)]
    [InlineData(Length.dm, 1, 10)]
    [InlineData(Length.m, 1, 100)]
    [InlineData(Length.km, 1, 0.00001)]
    [InlineData(Length.mil, 1, 0.000001)]
    public void ConvertToCentimeter(Length lengthToConvertFrom, double valueToConvert, double expectedValue)
    {
        var actual = LenghtUtility.ConvertToCentimeter(lengthToConvertFrom, valueToConvert);

        Assert.Equal(expectedValue, actual);
    }

    [Theory]
    [InlineData(Length.mm, 100, 1)]
    [InlineData(Length.cm, 10, 1)]
    [InlineData(Length.m, 1, 10)]
    [InlineData(Length.km, 1, 0.0001)]
    [InlineData(Length.mil, 1, 0.00001)]
    public void ConvertToDecimeter(Length lengthToConvertFrom, double valueToConvert, double expectedValue)
    {
        var actual = LenghtUtility.ConvertToDecimeter(lengthToConvertFrom, valueToConvert);

        Assert.Equal(expectedValue, actual);
    }

    [Theory]
    [InlineData(Length.mm, 1000, 1)]
    [InlineData(Length.cm, 100, 1)]
    [InlineData(Length.dm, 10, 1)]
    [InlineData(Length.km, 1, 0.001)]
    [InlineData(Length.mil, 1, 0.0001)]
    public void ConvertToMeter(Length lengthToConvertFrom, double valueToConvert, double expectedValue)
    {
        var actual = LenghtUtility.ConvertToMeter(lengthToConvertFrom, valueToConvert);

        Assert.Equal(expectedValue, actual);
    }

    [Theory]
    [InlineData(Length.mm, 1000000, 1)]
    [InlineData(Length.cm, 100000, 1)]
    [InlineData(Length.dm, 10000, 1)]
    [InlineData(Length.m, 1000, 1)]
    [InlineData(Length.mil, 1, 10)]
    public void ConvertToKilometer(Length lengthToConvertFrom, double valueToConvert, double expectedValue)
    {
        var actual = LenghtUtility.ConvertToKilometer(lengthToConvertFrom, valueToConvert);

        Assert.Equal(expectedValue, actual);
    }

    [Theory]
    [InlineData(Length.mm, 10000000, 1)]
    [InlineData(Length.cm, 1000000, 1)]
    [InlineData(Length.dm, 100000, 1)]
    [InlineData(Length.m, 10000, 1)]
    [InlineData(Length.km, 10, 1)]
    public void ConvertToMil(Length lengthToConvertFrom, double valueToConvert, double expectedValue)
    {
        var actual = LenghtUtility.ConvertToMil(lengthToConvertFrom, valueToConvert);

        Assert.Equal(expectedValue, actual);
    }
}