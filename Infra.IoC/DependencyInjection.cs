using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Infra.IoC;

public class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMongoDB(configuration.GetConnectionString("DefaultConnection"), "Task-Manager"));


        var applicationAssembly = AppDomain.CurrentDomain.Load("Task-Manager");

        return services;
    }
}