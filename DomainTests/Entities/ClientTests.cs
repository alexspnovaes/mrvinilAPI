using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Command.Inputs;
using Domain.Interfaces;
using Moq;

namespace Domain.Entities.Tests
{
   
    [TestClass()]
    public class ClientTests
    {
        private Mock<IClientRepository> _mock;

        [TestMethod()]
        [TestCategory("Client")]
        public void NewClientWithAllParams()
        {
            _mock = new Mock<IClientRepository>();
            Client cli = new Client("alexandre", "testealex", "alexandresp_novaes@hotmail.com", "123456", "35718362866");

            _mock.Setup(m => m.Add(cli));

            //Assert.IsTrue(cli.IsValid(_clientRepository));
        }


        //[TestMethod()]
        //[TestCategory("Client")]
        //public void NewClientWithoutName()
        //{
        //    Client cli = new Client(null, "12345678911");
        //    Assert.IsTrue(cli.Notifications.Count > 0);
        //}

        //[TestMethod()]
        //[TestCategory("Client")]
        //public void NewClientWithoutUniqueId()
        //{
        //    Client cli = new Client("test", null);
        //    Assert.IsTrue(cli.Notifications.Count > 0);
        //}

        //[TestMethod()]
        //[TestCategory("Client")]
        //public void NewClientWithNameGreaterThanMaxLen()
        //{
        //    Client cli = new Client("alexandreSpreaficoNovaesAlexandreSPreaficoNovaesAlexandreSpreaficoNovaes alexandreSpreaficoNovaesAlexandreSPreaficoNovaesAlexandreSpreaficoNovaes", "12345678911");
        //    Assert.IsTrue(cli.Notifications.Count > 0);
        //}

        //[TestMethod()]
        //[TestCategory("Client")]
        //public void NewClientWithClientIdGreaterThanMaxLen()
        //{
        //    Client cli = new Client("AlexandreSpreaficoNovaes", "123456789101112131415");
        //    Assert.IsTrue(cli.Notifications.Count > 0);
        //}

    }
}