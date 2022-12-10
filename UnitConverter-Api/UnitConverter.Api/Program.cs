using MediatR;
using UnitConverter.Api.Features.Handlers;
using UnitConverter.Api.Features.Models;
using UnitConverter.Api.Features.Requests;
using UnitConverter.Api.Features.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton(typeof(IUnitConverter<Length>), typeof(LengthConverter));
builder.Services.AddSingleton(typeof(IUnitConverter<Weight>), typeof(WeightConverter));
builder.Services.AddSingleton(typeof(IUnitConverter<Volume>), typeof(VolumeConverter));

builder.Services.AddMediatR(typeof(Program).Assembly);

builder.Services.AddScoped(typeof(IRequestHandler<LengthUnitRequest, IEnumerable<UnitModel>>), typeof(LengthUnitRequestHandler));
builder.Services.AddScoped(typeof(IRequestHandler<WeightUnitRequest, IEnumerable<UnitModel>>), typeof(WeightUnitRequestHandler));
builder.Services.AddScoped(typeof(IRequestHandler<VolumeUnitRequest, IEnumerable<UnitModel>>), typeof(VolumeUnitRequestHandler));
builder.Services.AddScoped(typeof(IRequest<IEnumerable<UnitModel>>), typeof(LengthUnitRequest));
builder.Services.AddScoped(typeof(IRequest<IEnumerable<UnitModel>>), typeof(WeightUnitRequest));
builder.Services.AddScoped(typeof(IRequest<IEnumerable<UnitModel>>), typeof(VolumeUnitRequest));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/", () => "Unit Converter is ready to convert some units!");
app.MapGet("/length", async (IMediator mediator) => await mediator.Send(LengthUnitRequest.Instance));
app.MapGet("/weight", async (IMediator mediator) => await mediator.Send(WeightUnitRequest.Instance));
app.MapGet("/volume", async (IMediator mediator) => await mediator.Send(VolumeUnitRequest.Instance));

app.Run();