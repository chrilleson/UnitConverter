using UnitConverter.Api.Features.Models;

namespace UnitConverter.Api.Features.Services;

public class VolumeConverter : IUnitConverter<Volume>
{
    private readonly Volume[] _volumes = Enum.GetValues<Volume>();
    public Unit CreateUnitToConvertFrom()
    {
        var valueToConvert = new Random().Next(1, 500000);
        var randomValue = _volumes.GetValue(new Random().Next(0, _volumes.Length));

        return new Unit(valueToConvert, randomValue.ToString());
    }

    public Unit CreateUnitToConvertTo(Unit unitToConvertFrom)
    {
        var randomValue = _volumes.GetValue(new Random().Next(0, _volumes.Length));
        while (randomValue.ToString() == unitToConvertFrom.UnitType)
        {
            randomValue = _volumes.GetValue(new Random().Next(0, _volumes.Length));
        }

        return CorrectValue(unitToConvertFrom, Enum.Parse<Volume>(randomValue.ToString()));
    }

    private static Unit CorrectValue(Unit unitToConvertFrom, Volume unitToConvertTo)
    {
        var value = unitToConvertTo switch
        {
            Volume.ml => VolumeUtility.ConvertToMilliliter(Enum.Parse<Volume>(unitToConvertFrom.UnitType), unitToConvertFrom.Value),
            Volume.cl => VolumeUtility.ConvertToCentiliter(Enum.Parse<Volume>(unitToConvertFrom.UnitType), unitToConvertFrom.Value),
            Volume.dl => VolumeUtility.ConvertToDeciliter(Enum.Parse<Volume>(unitToConvertFrom.UnitType), unitToConvertFrom.Value),
            Volume.l => VolumeUtility.ConvertToLiter(Enum.Parse<Volume>(unitToConvertFrom.UnitType), unitToConvertFrom.Value),
            _ => throw new Exception($"No such volume unit exists. {unitToConvertTo}")
        };

        return new Unit(value, unitToConvertTo.ToString());
    }
}