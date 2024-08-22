using Application.Features.LeaveTypes.Requests.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationServicesRegistration
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            // services.AddAutoMapper(typeof(MappingProfile));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetLeaveTypeListRequest).Assembly));
        }
    }
}
