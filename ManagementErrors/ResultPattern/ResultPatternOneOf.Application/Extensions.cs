using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ResultPatternOneOf.Application;

public static class Extensions
{

    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICarService, CarService>();
        services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMemoryDb"));
    }
}