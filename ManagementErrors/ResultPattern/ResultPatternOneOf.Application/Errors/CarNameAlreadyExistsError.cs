namespace ResultPatternOneOf.Application.Errors;

public record CarNameAlreadyExistsError() : AppError("Car name already exists", ErrorType.BusinessRule);