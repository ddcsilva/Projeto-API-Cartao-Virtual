using ApiCartao.Domain.Commands.Inputs;
using ApiCartao.Domain.Handlers;
using ApiCartao.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiCartao.Tests.HandlerTests
{
    [TestClass]
    public class GerarCartaoVirtualHandlerTests
    {
        [TestMethod]
        public void Dado_Email_Invalido_Deve_Retornar_Email_Invalido()
        {
            var command = new GerarCartaoVirtualCommand();
            command.Email = "testeEmail.com";

            var handler = new GerarCartaoVirtualHandler(new FakeRepository());
            var result = handler.Handle(command);

            Assert.AreEqual("Email Inválido", result.Message);
        }

        [TestMethod]
        public void DeveRetornarSucesso()
        {
            var command = new GerarCartaoVirtualCommand();
            command.Email = "teste@gmail.com";

            var handler = new GerarCartaoVirtualHandler(new FakeRepository());
            var result = handler.Handle(command);

            Assert.AreEqual(true, result.Success);
        }
    }
}
