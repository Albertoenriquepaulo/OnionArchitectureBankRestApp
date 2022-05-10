using Application.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repository;
using System.Reflection;

namespace Persistence
{
    public static class ServiceExtensions
    {
        // to group the injections of 3rd parties and our services
        public static void AddPersistenceInfraestructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b=> b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                ));

            #region Repositories
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(MyRepositoryAsync<>));
            #endregion

        }
    }
}
