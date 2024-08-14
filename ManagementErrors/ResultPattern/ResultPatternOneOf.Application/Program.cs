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

    /*With match*/
    return carResult.Match(
        car => Results.Created($"cars/{car.Id}", car),
        error =>
        {
            if (error.ErrorType == ResultPatternOneOf.Application.Errors.ErrorType.BusinessRule)
                return Results.Conflict(error);

            return Results.BadRequest(error);
        });



    /* Without Match
    if (carResult.IsSuccess())
    {
        var car = carResult.GetSuccessResult();
        return Results.Created($"cars/{car.Id}", car);
    }

    // in case of errors
    var errorObj = carResult.GetErrorResult();
    if (errorObj.ErrorType == ResultPatternOneOf.Application.Errors.ErrorType.BusinessRule)
        return Results.Conflict(errorObj);

    return Results.BadRequest(errorObj);
    */

});

app.Run();

public record RegisterCarRequest(string Name);
