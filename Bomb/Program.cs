using System;
using Bomb.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bomb
{
    class Program
    {
        static void Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args).UseStartup<Startup>();

            var disarmAttemptAppService = host.Services.GetRequiredService<IDisarmAttemptAppService>();

            while(true)
            {
                Execute(disarmAttemptAppService);
            }

        }

        static void Execute(IDisarmAttemptAppService disarmAttemptAppService)
        {
            Console.WriteLine("Digite 1 para desarmar a bomba ou 2 para exibir a lista de tentativas");

            var option = Console.ReadLine();
            Console.WriteLine();

            switch (option)
            {
                case "1":
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

                    break;
                case "2":
                    var attempts = disarmAttemptAppService.GetDisarmAttempts();

                    foreach (var attempt in attempts)
                    {
                        Console.WriteLine(attempt);
                    }

                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
                
            }
            Console.WriteLine();
        }
    }
}
