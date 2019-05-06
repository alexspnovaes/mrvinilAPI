using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Command.Inputs;
using Domain.Interfaces;
using Moq;

namespace Domain.Entities.Tests
{

    [TestClass()]
    public class ClientTests
    {
        [TestMethod()]
        [TestCategory("Client")]
        public void NewClientWithAllParams()
        {
            Mock<IClientRepository>  _mock = new Mock<IClientRepository>();
            NewClient cli = new NewClient
            {
                Name = "alexandre",
                UserName = "testealex",
                Email = "alexandresp_novaes@hotmail.com",
                Password = "123456",
                Clienteuniqueid = "35718362866"
            };

            Assert.IsTrue(cli.IsValid(_mock.Object));
        }

        [TestMethod()]
        [TestCategory("Client")]
        public void NewClientWithExistentUserName()
        {
            Mock<IClientRepository> _mock = new Mock<IClientRepository>();

            Client client = new Client("test", "testealex", "teste@teste.com", "123456", "12345678911");

            _mock.Setup(x => x.GetByUsername("testealex")).Returns(client);


            NewClient cli = new NewClient
            {
                Name = "alexandre",
                UserName = "testealex",
                Email = "alexandresp_novaes@hotmail.com",
                Password = "123456",
                Clienteuniqueid = "35718362866"
            };

            Assert.IsFalse(cli.IsValid(_mock.Object));
        }

    }
}