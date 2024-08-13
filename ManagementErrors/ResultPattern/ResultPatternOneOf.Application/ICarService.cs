using OneOf;
using ResultPatternOneOf.Application.Errors;

namespace ResultPatternOneOf.Application;

public interface ICarService
{
    public Task<OneOf<Car, AppError>> AddCar(string name, CancellationToken ct);
}