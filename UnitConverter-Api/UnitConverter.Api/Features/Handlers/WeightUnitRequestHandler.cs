using MediatR;
using UnitConverter.Api.Features.Models;
using UnitConverter.Api.Features.Requests;
using UnitConverter.Api.Features.Services;

namespace UnitConverter.Api.Features.Handlers;

public class WeightUnitRequestHandler : IRequestHandler<WeightUnitRequest, IEnumerable<UnitModel>>
{
    private readonly IUnitConverter<Weight> _unitConverter;

    public WeightUnitRequestHandler(IUnitConverter<Weight> unitConverter)
    {
        _unitConverter = unitConverter;
    }

    public async Task<IEnumerable<UnitModel>> Handle(WeightUnitRequest request, CancellationToken cancellationToken)
    {
        var nrOfUnits = new Random().Next(1, 5);
        var units = new List<UnitModel>();
        for (int i = 0; i < nrOfUnits; i++)
        {
            var unitToConvertFrom = _unitConverter.CreateUnitToConvertFrom();
            var unitToConvertTo = _unitConverter.CreateUnitToConvertTo(unitToConvertFrom);
            units.Add(new UnitModel(unitToConvertFrom, unitToConvertTo));
        }

        return units;
    }
}