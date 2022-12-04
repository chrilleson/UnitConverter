namespace UnitConverter.Api.Features.Models;

public enum Length
{
    mil,
    km,
    m,
    dm,
    cm,
    mm,
}

public static class LenghtUtility
{
    internal static double ConvertToMillimeter(Length unitToConvertFrom, double valueToConvert)
    {
        return unitToConvertFrom switch
        {
            Length.cm => ConvertFromCm(valueToConvert),
            Length.dm => ConvertFromDm(valueToConvert),
            Length.m => ConvertFromM(valueToConvert),
            Length.km => ConvertFromKm(valueToConvert),
            Length.mil => ConvertFromMil(valueToConvert),
            _ => throw new Exception()
        };

        double ConvertFromCm(double value) => value / Math.Pow(10, -1);
        double ConvertFromDm(double value) => value / Math.Pow(10, -2);
        double ConvertFromM(double value) => value / Math.Pow(10, -3);
        double ConvertFromKm(double value) => value / Math.Pow(10, 6);
        double ConvertFromMil(double value) => value / Math.Pow(10, 7);
    }

    internal static double ConvertToCentimeter(Length unitToConvertFrom, double valueToConvert)
    {
        return unitToConvertFrom switch
        {
            Length.mm => ConvertFromMm(valueToConvert),
            Length.dm => ConvertFromDm(valueToConvert),
            Length.m => ConvertFromM(valueToConvert),
            Length.km => ConvertFromKm(valueToConvert),
            Length.mil => ConvertFromMil(valueToConvert),
            _ => throw new Exception()
        };

        double ConvertFromMm(double value) => value * Math.Pow(10, -1);
        double ConvertFromDm(double value) => value / Math.Pow(10, -1);
        double ConvertFromM(double value) => value / Math.Pow(10, -2);
        double ConvertFromKm(double value) => value / Math.Pow(10, 5);
        double ConvertFromMil(double value) => value / (10 * Math.Pow(10, 5));
    }

    internal static double ConvertToDecimeter(Length unitToConvertFrom, double valueToConvert)
    {
        return unitToConvertFrom switch
        {
            Length.mm => ConvertFromMm(valueToConvert),
            Length.cm => ConvertFromCm(valueToConvert),
            Length.m => ConvertFromM(valueToConvert),
            Length.km => ConvertFromKm(valueToConvert),
            Length.mil => ConvertFromMil(valueToConvert),
            _ => throw new Exception()
        };

        double ConvertFromMm(double value) => value * Math.Pow(10, -2);
        double ConvertFromCm(double value) => value * Math.Pow(10, -1);
        double ConvertFromM(double value) => value / Math.Pow(10, -1);
        double ConvertFromKm(double value) => value / Math.Pow(10, 4);
        double ConvertFromMil(double value) => value / (10 * Math.Pow(10, 4));
    }

    internal static double ConvertToMeter(Length unitToConvertFrom, double valueToConvert)
    {
        return unitToConvertFrom switch
        {
            Length.mm => ConvertFromMm(valueToConvert),
            Length.cm => ConvertFromCm(valueToConvert),
            Length.dm => ConvertFromDm(valueToConvert),
            Length.km => ConvertFromKm(valueToConvert),
            Length.mil => ConvertFromMil(valueToConvert),
            _ => throw new Exception()
        };

        double ConvertFromMm(double value) => value * Math.Pow(10, -3);
        double ConvertFromCm(double value) => value * Math.Pow(10, -2);
        double ConvertFromDm(double value) => value * Math.Pow(10, -1);
        double ConvertFromKm(double value) => value / Math.Pow(10, 3);
        double ConvertFromMil(double value) => value / (10 * Math.Pow(10, 3));
    }

    internal static double ConvertToKilometer(Length unitToConvertFrom, double valueToConvert)
    {
        return unitToConvertFrom switch
        {
            Length.mm => ConvertFromMm(valueToConvert),
            Length.cm => ConvertFromCm(valueToConvert),
            Length.dm => ConvertFromDm(valueToConvert),
            Length.m => ConvertFromM(valueToConvert),
            Length.mil => ConvertFromMil(valueToConvert),
            _ => throw new Exception()
        };

        double ConvertFromMm(double value) => value * Math.Pow(10, -6);
        double ConvertFromCm(double value) => value * Math.Pow(10, -5);
        double ConvertFromDm(double value) => value * Math.Pow(10, -4);
        double ConvertFromM(double value) => value * Math.Pow(10, -3);
        double ConvertFromMil(double value) => value / Math.Pow(10, -1);
    }

    internal static double ConvertToMil(Length unitToConvertFrom, double valueToConvert)
    {
        return unitToConvertFrom switch
        {
            Length.mm => ConvertFromMm(valueToConvert),
            Length.cm => ConvertFromCm(valueToConvert),
            Length.dm => ConvertFromDm(valueToConvert),
            Length.m => ConvertFromM(valueToConvert),
            Length.km => ConvertFromKm(valueToConvert),
            _ => throw new Exception()
        };

        double ConvertFromMm(double value) => value * Math.Pow(10, -7);
        double ConvertFromCm(double value) => value * Math.Pow(10, -6);
        double ConvertFromDm(double value) => value * Math.Pow(10, -5);
        double ConvertFromM(double value) => value * Math.Pow(10, -4);
        double ConvertFromKm(double value) => value * Math.Pow(10, -1);
    }
}