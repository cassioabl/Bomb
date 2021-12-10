using Bomb.Application.Interfaces;
using Bomb.Domain.Interfaces;
using Bomb.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Bomb.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IDisarmAttemptRepository, DisarmAttemptRepository>();
            services.AddScoped<IDisarmAttemptAppService, DisarmAttemptAppService>();
        }
    }
}
