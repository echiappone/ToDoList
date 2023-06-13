using ToDoList.Services;
using ToDoList.Repository;
using ToDoList.Domain.Services;
using ToDoList.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using ToDoList.Repository.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ToDoList.IOC
{
    public static class Injection
    {
        public static IServiceCollection Inject(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("connection");
            services.AddDbContext<ToDoListDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOpt =>
                {
                    sqlOpt.MigrationsAssembly("ToDoList.Repository");
                });
            });

            services.AddScoped<ITaskItemRepository, TaskItemRepository>();
            services.AddScoped<ITaskItemService, TaskItemService>();

            return services;
        }
    }
}