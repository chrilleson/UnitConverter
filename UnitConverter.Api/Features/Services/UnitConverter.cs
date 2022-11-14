using UnitConverter.Api.Features.Models;

namespace UnitConverter.Api.Features.Services;

public class UnitConverter<T> : IUnitConverter<T> where T : Enum
{
    public Unit CreateUnitToConvertTo(Unit unitToConvertFrom)
    {
        var values = Enum.GetValues(typeof(T));
        var randomValue = (T)values.GetValue(new Random().Next(0, values.Length));
        while (randomValue.ToString() == unitToConvertFrom.UnitType)
        {
            randomValue = (T)values.GetValue(new Random().Next(0, values.Length));
        }

        return new Unit(null, randomValue.ToString());
    }

    public Unit CreateUnitToConvertFrom()
    {
        var valueToConvert = new Random().Next(1, 500000);
        var values = Enum.GetValues(typeof(T));
        var randomValue = (T)values.GetValue(new Random().Next(0, values.Length));

        return new Unit(valueToConvert, randomValue.ToString());
    }
}