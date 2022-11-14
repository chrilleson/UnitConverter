using UnitConverter.Api.Features.Models;

namespace UnitConverter.Api.Features.Services;

public interface IUnitConverter<T>  where T : Enum
{
    Unit CreateUnitToConvertTo(Unit unitToConvertFrom);
    Unit CreateUnitToConvertFrom();
}