using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
