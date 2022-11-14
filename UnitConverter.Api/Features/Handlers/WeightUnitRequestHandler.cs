using MediatR;
using UnitConverter.Api.Features.Models;
using UnitConverter.Api.Features.Models.Enums;
using UnitConverter.Api.Features.Requests;
using UnitConverter.Api.Features.Services;

namespace UnitConverter.Api.Features.Handlers;

public class WeightUnitRequestHandler : IRequestHandler<WeightUnitRequest, UnitModel>
{
    private readonly IUnitConverter<Weight> _unitConverter;

    public WeightUnitRequestHandler(IUnitConverter<Weight> unitConverter)
    {
        _unitConverter = unitConverter;
    }

    public async Task<UnitModel> Handle(WeightUnitRequest request, CancellationToken cancellationToken)
    {
        var unitToConvertFrom = _unitConverter.CreateUnitToConvertFrom();
        var unitToConvertTo = _unitConverter.CreateUnitToConvertTo(unitToConvertFrom);

        return new UnitModel(unitToConvertFrom, unitToConvertTo);
    }
}