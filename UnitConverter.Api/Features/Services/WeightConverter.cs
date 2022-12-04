using UnitConverter.Api.Features.Models;

namespace UnitConverter.Api.Features.Services;

public class WeightConverter : IUnitConverter<Weight>
{
    private readonly Weight[] _weights = Enum.GetValues<Weight>();
    public Unit CreateUnitToConvertFrom()
    {
        var valueToConvert = new Random().Next(1, 500000);
        var randomValue = _weights.GetValue(new Random().Next(0, _weights.Length));

        return new Unit(valueToConvert, randomValue.ToString());
    }

    public Unit CreateUnitToConvertTo(Unit unitToConvertFrom)
    {
        var randomValue = _weights.GetValue(new Random().Next(0, _weights.Length));
        while (randomValue.ToString() == unitToConvertFrom.UnitType)
        {
            randomValue = _weights.GetValue(new Random().Next(0, _weights.Length));
        }

        return CorrectValue(unitToConvertFrom, Enum.Parse<Weight>(randomValue.ToString()));
    }

    private static Unit CorrectValue(Unit unitToConvertFrom, Weight unitToConvertTo)
    {
        var value = unitToConvertTo switch
        {
            Weight.mg => WeightUtility.ConvertToMilligram(Enum.Parse<Weight>(unitToConvertFrom.UnitType), unitToConvertFrom.Value),
            Weight.g => WeightUtility.ConvertToGram(Enum.Parse<Weight>(unitToConvertFrom.UnitType), unitToConvertFrom.Value),
            Weight.hg => WeightUtility.ConvertToHectogram(Enum.Parse<Weight>(unitToConvertFrom.UnitType), unitToConvertFrom.Value),
            Weight.kg => WeightUtility.ConvertToKilogram(Enum.Parse<Weight>(unitToConvertFrom.UnitType), unitToConvertFrom.Value),
            Weight.ton => WeightUtility.ConvertToTon(Enum.Parse<Weight>(unitToConvertFrom.UnitType), unitToConvertFrom.Value),
            _ => throw new Exception($"No such weight unit exists. {unitToConvertTo}")
        };

        return new Unit(value, unitToConvertTo.ToString());
    }
}