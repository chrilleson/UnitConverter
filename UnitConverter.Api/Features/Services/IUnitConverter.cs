using UnitConverter.Api.Features.Models;

namespace UnitConverter.Api.Features.Services;

public interface IUnitConverter<T>  where T : Enum
{
    Unit CreateUnitToConvertFrom();

    Unit CreateUnitToConvertTo(Unit unitToConvertFrom);
}