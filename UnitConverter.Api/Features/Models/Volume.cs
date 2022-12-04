namespace UnitConverter.Api.Features.Models;

public enum Volume
{
    l,
    dl,
    cl,
    ml,
}

public static class VolumeUtility
{
    internal static double ConvertToMilliliter(Volume unitToConvertFrom, double valueToConvert)
    {
        return unitToConvertFrom switch
        {
            Volume.cl => ConvertFromCentiliter(valueToConvert),
            Volume.dl => ConvertFromDeciliter(valueToConvert),
            Volume.l => ConvertFromLiter(valueToConvert),
            _ => throw new Exception()
        };

        double ConvertFromCentiliter(double value) => value / Math.Pow(10, -1);
        double ConvertFromDeciliter(double value) => value / Math.Pow(10, -2);
        double ConvertFromLiter(double value) => value / Math.Pow(10, -3);
    }

    internal static double ConvertToCentiliter(Volume unitToConvertFrom, double valueToConvert)
    {
        return unitToConvertFrom switch
        {
            Volume.ml => ConvertFromMilliliter(valueToConvert),
            Volume.dl => ConvertFromDeciliter(valueToConvert),
            Volume.l => ConvertFromLiter(valueToConvert),
            _ => throw new Exception()
        };

        double ConvertFromMilliliter(double value) => value * Math.Pow(10, -1);
        double ConvertFromDeciliter(double value) => value / Math.Pow(10, -1);
        double ConvertFromLiter(double value) => value / Math.Pow(10, -2);
    }

    internal static double ConvertToDeciliter(Volume unitToConvertFrom, double valueToConvert)
    {
        return unitToConvertFrom switch
        {
            Volume.ml => ConvertFromMilliliter(valueToConvert),
            Volume.cl => ConvertFromCentiliter(valueToConvert),
            Volume.l => ConvertFromLiter(valueToConvert),
            _ => throw new Exception()
        };

        double ConvertFromMilliliter(double value) => value * Math.Pow(10, -2);
        double ConvertFromCentiliter(double value) => value * Math.Pow(10, -1);
        double ConvertFromLiter(double value) => value / Math.Pow(10, -1);
    }

    internal static double ConvertToLiter(Volume unitToConvertFrom, double valueToConvert)
    {
        return unitToConvertFrom switch
        {
            Volume.ml => ConvertFromMilliliter(valueToConvert),
            Volume.cl => ConvertFromCentiliter(valueToConvert),
            Volume.dl => ConvertFromDeciliter(valueToConvert),
            _ => throw new Exception()
        };

        double ConvertFromMilliliter(double value) => value * Math.Pow(10, -3);
        double ConvertFromCentiliter(double value) => value * Math.Pow(10, -2);
        double ConvertFromDeciliter(double value) => value * Math.Pow(10, -1);
    }

}