using MediatR;
using UnitConverter.Api.Features.Models;
using UnitConverter.Api.Features.Requests;
using UnitConverter.Api.Features.Services;

namespace UnitConverter.Api.Features.Handlers;

public class VolumeUnitRequestHandler : IRequestHandler<VolumeUnitRequest, IEnumerable<UnitModel>>
{
    private readonly IUnitConverter<Volume> _unitConverter;

    public VolumeUnitRequestHandler(IUnitConverter<Volume> unitConverter)
    {
        _unitConverter = unitConverter;
    }

    public async Task<IEnumerable<UnitModel>> Handle(VolumeUnitRequest request, CancellationToken cancellationToken)
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