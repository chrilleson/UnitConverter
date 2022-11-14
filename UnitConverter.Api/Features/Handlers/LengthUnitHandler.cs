using MediatR;
using UnitConverter.Api.Features.Models;
using UnitConverter.Api.Features.Models.Enums;
using UnitConverter.Api.Features.Requests;
using UnitConverter.Api.Features.Services;

namespace UnitConverter.Api.Features.Handlers;

public class LengthUnitHandler : IRequestHandler<LengthUnitRequest, UnitModel>
{
    private readonly IUnitConverter<Length> _unitConverter;

    public LengthUnitHandler(IUnitConverter<Length> unitConverter)
    {
        _unitConverter = unitConverter;
    }

    public async Task<UnitModel> Handle(LengthUnitRequest request, CancellationToken cancellationToken)
    {
        var unitToConvertFrom = _unitConverter.CreateUnitToConvertFrom();
        var unitToConvertTo = _unitConverter.CreateUnitToConvertTo(unitToConvertFrom);

        return new UnitModel(unitToConvertFrom, unitToConvertTo);
    }
}