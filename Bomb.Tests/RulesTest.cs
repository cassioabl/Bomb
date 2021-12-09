using Bomb.Application.Exceptions;
using Bomb.Application.Interfaces;
using Bomb.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bomb.Tests
{
    [TestClass]
    public class RulesTest
    {
        private readonly IDisarmeAttemptAppService _service;
        
        //[TestInitialize]
        //public void DI()
        //{
        //    _service = GetServiceByDI();
        //}

        [TestMethod]
        public void IfCutWhiteWireCantCutWhiteWire()
        {
            var service = new DisarmeAttemptAppService();

            Assert.ThrowsException<BombExplodedException>(() => service.TryDisarm("Branco, Branco"));
        }

        [TestMethod]
        public void IfCutWhiteWireCantCutBlackWire()
        {
            var service = new DisarmeAttemptAppService();

            Assert.ThrowsException<BombExplodedException>(() => service.TryDisarm("Branco, Preto"));
        }

        [TestMethod]
        public void IfCutRedWireShouldCutGreenkWire()
        {
            var service = new DisarmeAttemptAppService();

            service.TryDisarm("Vermelho, Verde");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void IfCutBlackWireCantCutWhiteWire()
        {
            var service = new DisarmeAttemptAppService();

            Assert.ThrowsException<BombExplodedException>(() => service.TryDisarm("Preto, Branco"));
        }

        [TestMethod]
        public void IfCutBlackWireCantCutGreenWire()
        {
            var service = new DisarmeAttemptAppService();

            Assert.ThrowsException<BombExplodedException>(() => service.TryDisarm("Preto, Verde"));
        }

        [TestMethod]
        public void IfCutBlackWireCantCutOrangeWire()
        {
            var service = new DisarmeAttemptAppService();

            Assert.ThrowsException<BombExplodedException>(() => service.TryDisarm("Preto, Laranja"));
        }

        [TestMethod]
        public void IfCutOrangeWireShouldCutRedWire()
        {
            var service = new DisarmeAttemptAppService();
            
            service.TryDisarm("Laranja, Vermelho");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void IfCutOrangeWireShouldCutBlackWire()
        {
            var service = new DisarmeAttemptAppService();

            service.TryDisarm("Laranja, Preto");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void IfCutGreenWireShouldCutOrangeWire()
        {
            var service = new DisarmeAttemptAppService();

            service.TryDisarm("Verde, Laranja");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void IfCutGreenWireShouldCutWhiteWhite()
        {
            var service = new DisarmeAttemptAppService();

            service.TryDisarm("Verde, Branco");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void IfCutPurpleWireCantCutPurpleWire()
        {
            var service = new DisarmeAttemptAppService();

            Assert.ThrowsException<BombExplodedException>(() => service.TryDisarm("Roxo, Roxo"));
        }

        [TestMethod]
        public void IfCutPurpleWireCantCutGreenWire()
        {
            var service = new DisarmeAttemptAppService();

            Assert.ThrowsException<BombExplodedException>(() => service.TryDisarm("Roxo, Verde"));
        }

        [TestMethod]
        public void IfCutPurpleWireCantCutOrangeWire()
        {
            var service = new DisarmeAttemptAppService();

            Assert.ThrowsException<BombExplodedException>(() => service.TryDisarm("Roxo, Laranja"));
        }

        [TestMethod]
        public void IfCutPurpleWireCantCutBrancoWire()
        {
            var service = new DisarmeAttemptAppService();

            Assert.ThrowsException<BombExplodedException>(() => service.TryDisarm("Roxo, Branco"));
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
