using MediatR;
using UnitConverter.Api.Features.Models;
using UnitConverter.Api.Features.Models.Enums;
using UnitConverter.Api.Features.Requests;
using UnitConverter.Api.Features.Services;

namespace UnitConverter.Api.Features.Handlers;

public class VolumeUnitRequestHandler : IRequestHandler<VolumeUnitRequest, UnitModel>
{
    private readonly IUnitConverter<Volume> _unitConverter;

    public VolumeUnitRequestHandler(IUnitConverter<Volume> unitConverter)
    {
        _unitConverter = unitConverter;
    }

    public async Task<UnitModel> Handle(VolumeUnitRequest request, CancellationToken cancellationToken)
    {
        var unitToConvertFrom = _unitConverter.CreateUnitToConvertFrom();
        var unitToConvertTo = _unitConverter.CreateUnitToConvertTo(unitToConvertFrom);

        return new UnitModel(unitToConvertFrom, unitToConvertTo);
    }
}