using UnitConverter.Api.Features.Models;

namespace UnitConverter.Test.UtilityTests;

public class VolumeUtilityTests
{
    [Theory]
    [InlineData(Volume.cl, 1, 10)]
    [InlineData(Volume.dl, 1, 100)]
    [InlineData(Volume.l, 1, 1000)]
    public void ConvertToMilliliter(Volume unitToConvertFrom, double valueToConvert, double expectedValue)
    {
        var actual = VolumeUtility.ConvertToMilliliter(unitToConvertFrom, valueToConvert);

        Assert.Equal(expectedValue, actual);
    }

    [Theory]
    [InlineData(Volume.ml, 10, 1)]
    [InlineData(Volume.dl, 1, 10)]
    [InlineData(Volume.l, 1, 100)]
    public void ConvertToCentiliter(Volume unitToConvertFrom, double valueToConvert, double expectedValue)
    {
        var actual = VolumeUtility.ConvertToCentiliter(unitToConvertFrom, valueToConvert);

        Assert.Equal(expectedValue, actual);
    }

    [Theory]
    [InlineData(Volume.ml, 100, 1)]
    [InlineData(Volume.cl, 10, 1)]
    [InlineData(Volume.l, 1, 10)]
    public void ConvertToDeciliter(Volume unitToConvertFrom, double valueToConvert, double expectedValue)
    {
        var actual = VolumeUtility.ConvertToDeciliter(unitToConvertFrom, valueToConvert);

        Assert.Equal(expectedValue, actual);
    }

    [Theory]
    [InlineData(Volume.ml, 1000, 1)]
    [InlineData(Volume.cl, 100, 1)]
    [InlineData(Volume.dl, 10, 1)]
    public void ConvertToLiter(Volume unitToConvertFrom, double valueToConvert, double expectedValue)
    {
        var actual = VolumeUtility.ConvertToLiter(unitToConvertFrom, valueToConvert);

        Assert.Equal(expectedValue, actual);
    }
}