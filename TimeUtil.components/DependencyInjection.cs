using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace TimeUtil.Components
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTimeUtilComponents(this IServiceCollection services)
        {
            services.AddMudServices();

            return services;
        }
    }
}
