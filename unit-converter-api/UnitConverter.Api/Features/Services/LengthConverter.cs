using UnitConverter.Api.Features.Models;

namespace UnitConverter.Api.Features.Services;

public class LengthConverter : IUnitConverter<Length>
{
    private readonly Length[] _lengthValues = Enum.GetValues<Length>();

    public Unit CreateUnitToConvertFrom()
    {
        var valueToConvert = new Random().Next(1, 500000);
        var randomValue = _lengthValues.GetValue(new Random().Next(0, _lengthValues.Length));

        return new Unit(valueToConvert, randomValue.ToString());
    }

    public Unit CreateUnitToConvertTo(Unit unitToConvertFrom)
    {
        var randomValue = _lengthValues.GetValue(new Random().Next(0, _lengthValues.Length));
        while (randomValue.ToString() == unitToConvertFrom.UnitType)
        {
            randomValue = _lengthValues.GetValue(new Random().Next(0, _lengthValues.Length));
        }

        return CorrectValue(unitToConvertFrom, Enum.Parse<Length>(randomValue.ToString()));
    }

    private static Unit CorrectValue(Unit unitToConvertFrom, Length unitToConvertTo)
    {
        var value = unitToConvertTo switch
        {
            Length.mm => LenghtUtility.ConvertToMillimeter(Enum.Parse<Length>(unitToConvertFrom.UnitType), unitToConvertFrom.Value),
            Length.cm => LenghtUtility.ConvertToCentimeter(Enum.Parse<Length>(unitToConvertFrom.UnitType), unitToConvertFrom.Value),
            Length.dm => LenghtUtility.ConvertToDecimeter(Enum.Parse<Length>(unitToConvertFrom.UnitType), unitToConvertFrom.Value),
            Length.m => LenghtUtility.ConvertToMeter(Enum.Parse<Length>(unitToConvertFrom.UnitType), unitToConvertFrom.Value),
            Length.km => LenghtUtility.ConvertToKilometer(Enum.Parse<Length>(unitToConvertFrom.UnitType), unitToConvertFrom.Value),
            Length.mil => LenghtUtility.ConvertToMil(Enum.Parse<Length>(unitToConvertFrom.UnitType), unitToConvertFrom.Value),
            _ => throw new Exception($"No such length unit exists. {unitToConvertTo}")
        };

        return new Unit(value, unitToConvertTo.ToString());
    }
}