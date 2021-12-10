using Bomb.Application.Exceptions;
using Bomb.Application.Interfaces;
using Bomb.Domain.Interfaces;
using Bomb.Domain.Models;
using Bomb.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Bomb.Tests
{
    [TestClass]
    public class RulesTest
    {
        private IDisarmAttemptAppService _service;

        public RulesTest()
        {
            var mock = new Mock<IDisarmAttemptRepository>();
            mock.Setup(p => p.Add(It.IsAny<DisarmAttempt>()));

            _service = new DisarmAttemptAppService(mock.Object);
        }

        [TestMethod]
        public void IfCutWhiteWireCantCutWhiteWire()
        {
            Assert.ThrowsException<BombExplodedException>(() => _service.TryDisarm("Branco, Branco"));
        }

        [TestMethod]
        public void IfCutWhiteWireCantCutBlackWire()
        {
            Assert.ThrowsException<BombExplodedException>(() => _service.TryDisarm("Branco, Preto"));
        }

        [TestMethod]
        public void IfCutRedWireShouldCutGreenkWire()
        {
            _service.TryDisarm("Vermelho, Verde");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void IfCutBlackWireCantCutWhiteWire()
        {
            Assert.ThrowsException<BombExplodedException>(() => _service.TryDisarm("Preto, Branco"));
        }

        [TestMethod]
        public void IfCutBlackWireCantCutGreenWire()
        {
            Assert.ThrowsException<BombExplodedException>(() => _service.TryDisarm("Preto, Verde"));
        }

        [TestMethod]
        public void IfCutBlackWireCantCutOrangeWire()
        {
            Assert.ThrowsException<BombExplodedException>(() => _service.TryDisarm("Preto, Laranja"));
        }

        [TestMethod]
        public void IfCutOrangeWireShouldCutRedWire()
        {
            _service.TryDisarm("Laranja, Vermelho");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void IfCutOrangeWireShouldCutBlackWire()
        {
            _service.TryDisarm("Laranja, Preto");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void IfCutGreenWireShouldCutOrangeWire()
        {
            _service.TryDisarm("Verde, Laranja");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void IfCutGreenWireShouldCutWhiteWhite()
        {
            _service.TryDisarm("Verde, Branco");

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void IfCutPurpleWireCantCutPurpleWire()
        {
            Assert.ThrowsException<BombExplodedException>(() => _service.TryDisarm("Roxo, Roxo"));
        }

        [TestMethod]
        public void IfCutPurpleWireCantCutGreenWire()
        {
            Assert.ThrowsException<BombExplodedException>(() => _service.TryDisarm("Roxo, Verde"));
        }

        [TestMethod]
        public void IfCutPurpleWireCantCutOrangeWire()
        {
            Assert.ThrowsException<BombExplodedException>(() => _service.TryDisarm("Roxo, Laranja"));
        }

        [TestMethod]
        public void IfCutPurpleWireCantCutBrancoWire()
        {
            Assert.ThrowsException<BombExplodedException>(() => _service.TryDisarm("Roxo, Branco"));
        }
    }
}
