namespace ResultPatternOneOf.Application.Errors;

public record ShouldNotStartWithMError() : AppError("Should not start with M", ErrorType.Validation);
