using Microsoft.AspNetCore.Mvc;
using ResultPatternOneOf.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/cars", async ([FromBody] RegisterCarRequest req, ICarService service, CancellationToken ct) =>
{
    var carResult = await service.AddCar(req.Name, ct);
    if (carResult.IsT0)
    {
        var car = carResult.AsT0;
        return Results.Created($"cars/{car.Id}", car);
    }

    // in case of errors
    var errorObj = carResult.AsT1;
    if (errorObj.ErrorType == ResultPatternOneOf.Application.Errors.ErrorType.BusinessRule)
        return Results.Conflict(errorObj);

    return Results.BadRequest(errorObj);

});

app.Run();

public record RegisterCarRequest(string Name);
