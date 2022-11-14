
using MediatR;
using UnitConverter.Api.Features.Handlers;
using UnitConverter.Api.Features.Models.Enums;
using UnitConverter.Api.Features.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton(typeof(IUnitConverter<Length>), typeof(UnitConverter<Length>));
builder.Services.AddSingleton(typeof(IUnitConverter<Weight>), typeof(UnitConverter<Weight>));
builder.Services.AddSingleton(typeof(IUnitConverter<Volume>), typeof(UnitConverter<Volume>));

builder.Services.AddMediatR(typeof(Program).Assembly);

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

app.MapGet("/randomizer", () => app.Services.GetService<Mediator>()?.Send(UnitRequest.Instance));

app.Run();