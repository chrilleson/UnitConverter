namespace UnitConverter.Api.Features.Models;

public enum Weight
{
    ton,
    kg,
    hg,
    g,
    mg,
}

public static class WeightUtility
{
    public static double ConvertToMilligram(Weight unitToConvertFrom, double valueToConvert)
    {
        return unitToConvertFrom switch
        {
            Weight.g => ConvertFromGram(valueToConvert),
            Weight.hg => ConvertFromHectogram(valueToConvert),
            Weight.kg => ConvertFromKiloGram(valueToConvert),
            Weight.ton => ConvertFromTon(valueToConvert),
            _ => throw new Exception()
        };

        double ConvertFromGram(double value) => value / Math.Pow(10, -3);
        double ConvertFromHectogram(double value) => value / Math.Pow(10, -5);
        double ConvertFromKiloGram(double value) => value / Math.Pow(10, -6);
        double ConvertFromTon(double value) => value / Math.Pow(10, -9);
    }

    public static double ConvertToGram(Weight unitToConvertFrom, double valueToConvert)
    {
        return unitToConvertFrom switch
        {
            Weight.mg => ConvertFromMilligram(valueToConvert),
            Weight.hg => ConvertFromHectogram(valueToConvert),
            Weight.kg => ConvertFromKiloGram(valueToConvert),
            Weight.ton => ConvertFromTon(valueToConvert),
            _ => throw new Exception()
        };

        double ConvertFromMilligram(double value) => value * Math.Pow(10, -3);
        double ConvertFromHectogram(double value) => value / Math.Pow(10, -2);
        double ConvertFromKiloGram(double value) => value * Math.Pow(10, 3);
        double ConvertFromTon(double value) => value * Math.Pow(10, 6);
    }

    public static double ConvertToHectogram(Weight unitToConvertFrom, double valueToConvert)
    {
        return unitToConvertFrom switch
        {
            Weight.mg => ConvertFromMilligram(valueToConvert),
            Weight.g => ConvertFromGram(valueToConvert),
            Weight.kg => ConvertFromKiloGram(valueToConvert),
            Weight.ton => ConvertFromTon(valueToConvert),
            _ => throw new Exception()
        };

        double ConvertFromMilligram(double value) => value * Math.Pow(10, -5);
        double ConvertFromGram(double value) => value * Math.Pow(10, -2);
        double ConvertFromKiloGram(double value) => value * Math.Pow(10, 1);
        double ConvertFromTon(double value) => value * Math.Pow(10, 4);
    }

    public static double ConvertToKilogram(Weight unitToConvertFrom, double valueToConvert)
    {
        return unitToConvertFrom switch
        {
            Weight.mg => ConvertFromMilligram(valueToConvert),
            Weight.g => ConvertFromGram(valueToConvert),
            Weight.hg => ConvertFromHectogram(valueToConvert),
            Weight.ton => ConvertFromTon(valueToConvert),
            _ => throw new Exception()
        };

        double ConvertFromMilligram(double value) => value * Math.Pow(10, -6);
        double ConvertFromGram(double value) => value * Math.Pow(10, -3);
        double ConvertFromHectogram(double value) => value * Math.Pow(10, -1);
        double ConvertFromTon(double value) => value * Math.Pow(10, 3);
    }

    public static double ConvertToTon(Weight unitToConvertFrom, double valueToConvert)
    {
        return unitToConvertFrom switch
        {
            Weight.mg => ConvertFromMilligram(valueToConvert),
            Weight.g => ConvertFromGram(valueToConvert),
            Weight.hg => ConvertFromHectogram(valueToConvert),
            Weight.kg => ConvertFromKiloGram(valueToConvert),
            _ => throw new Exception()
        };

        double ConvertFromMilligram(double value) => value * Math.Pow(10, -9);
        double ConvertFromGram(double value) => value * Math.Pow(10, -6);
        double ConvertFromHectogram(double value) => value * Math.Pow(10, -4);
        double ConvertFromKiloGram(double value) => value * Math.Pow(10, -3);
    }

}