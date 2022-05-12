using Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ServiceExtensions
    {
        // to group the injections of 3rd parties and our services
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly()); // to register automatically the mapper in this class library
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // This registers should be done in the startup file of the project, but we are looking for a totallly decouple of our app
            // we should not depend on that. That's why we have installed the dependencyInjection nugget for Automapper, Mediator and FluentValidation
            // These installation allow us to use these out of the startup
        }
    }
}
