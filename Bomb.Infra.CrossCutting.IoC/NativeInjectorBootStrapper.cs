using Bomb.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Bomb.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IDisarmeAttemptAppService, DisarmeAttemptAppService>();
        }
    }
}
