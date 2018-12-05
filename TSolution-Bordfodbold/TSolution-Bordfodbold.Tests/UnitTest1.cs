using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TSolution_Bordfodbold.Abstract;
using TSolution_Bordfodbold.Controllers;
using TSolution_Bordfodbold.Entities;

namespace TSolution_Bordfodbold.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Indhold_Af_Spillere()
        {
            //Arrange
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(x => x.Spillere).Returns(new Spiller[] {
                new Spiller("Ane", 0),
                new Spiller("Ruben", 0),
                new Spiller("Stok", 0)
            });

            SpillerController controller = new SpillerController(mock.Object);

            //Act
            Spiller[] result = ((IEnumerable<Spiller>)controller.Spillere().ViewData.Model).ToArray();

            //Assert
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual("Ane", result[0].Navn);
            Assert.AreEqual("Ruben", result[1].Navn);
            Assert.AreEqual("Stok", result[2].Navn);
        }

        [TestMethod]
        public void Test_Slet_Spiller()
        {
            //Arrange
            Spiller spiller = new Spiller() { Spiller_ID = 1, Navn = "Hugo" };

            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(x => x.Spillere).Returns(new Spiller[] {
                new Spiller() { Spiller_ID = 2, Navn = "Ane" },
                new Spiller() { Spiller_ID = 3, Navn = "Ruben" },
                new Spiller() { Spiller_ID = 4, Navn = "Stok"  }
            });

            SpillerController controller = new SpillerController(mock.Object);

            //Act
            controller.Slet(spiller.Spiller_ID);

            //Assert
            mock.Verify(x => x.SletSpiller(spiller.Spiller_ID));
        }
    }
}
