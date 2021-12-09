using System;
using System.Threading.Tasks;
using Bomb.Application.Interfaces;
using Bomb.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bomb
{
    class Program
    {
        static void Main(string[] args)
        {
            var disarmAttemptAppService = GetServiceByDI();
            
            Console.WriteLine("Desarma a bomba");
            Console.WriteLine("Envie a lista de cores de fios.");

            var wires = Console.ReadLine();

            try
            {
                disarmAttemptAppService.TryDisarm(wires);
                Console.WriteLine("Bomba desarmada");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static IDisarmeAttemptAppService GetServiceByDI()
        {
            var serviceCollection = new ServiceCollection();
            NativeInjectorBootStrapper.RegisterServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider.GetService<IDisarmeAttemptAppService>();
        }
    }
}
