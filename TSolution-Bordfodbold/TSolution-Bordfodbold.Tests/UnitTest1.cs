using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TSolution_Bordfodbold.Abstract;
using TSolution_Bordfodbold.Controllers;
using TSolution_Bordfodbold.Entities;

namespace TSolution_Bordfodbold.Tests {
  [TestClass]
  public class UnitTest1 {
    [TestMethod]
    public void Test_Indhold_Af_Spillere() {
      //Arrange
      Mock<IRepository> mock = new Mock<IRepository>();
      mock.Setup(x => x.Spillere).Returns(new Spiller[] {
                new Spiller("Ane", 0),
                new Spiller("Ruben", 0),
                new Spiller("Stok", 0)
            });

      SpillerController controller = new SpillerController(mock.Object);

      //Act
      Spiller[] result = ((IEnumerable<Spiller>) controller.Spillere().ViewData.Model).ToArray();

      //Assert
      Assert.AreEqual(3, result.Length);
      Assert.AreEqual("Ane", result[0].Navn);
      Assert.AreEqual("Ruben", result[1].Navn);
      Assert.AreEqual("Stok", result[2].Navn);
    }

    [TestMethod]
    public void Test_Slet_Spiller() {
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
    [TestMethod]
    public void TestRediger() {
      //Arrange
      Mock<IRepository> mock = new Mock<IRepository>();
      mock.Setup(m => m.Spillere).Returns(new Spiller[] {
                new Spiller {Spiller_ID = 1, Navn = "Bent",
                             Indkasserede_Maal = 2, Scorede_Maal = 3,
                             Tabte = 4, Uafgjorte= 5, Vundne=6, WS=7,
                             Administrator = 0},
                new Spiller {Spiller_ID = 2, Navn = "Bent",
                             Indkasserede_Maal = 2, Scorede_Maal = 3,
                             Tabte = 4, Uafgjorte= 5, Vundne=6, WS=7,
                             Administrator = 0},
                new Spiller {Spiller_ID = 3, Navn = "Bent",
                             Indkasserede_Maal = 2, Scorede_Maal = 3,
                             Tabte = 4, Uafgjorte= 5, Vundne=6, WS=7,
                             Administrator = 0}
            });

      SpillerController controller = new SpillerController(mock.Object);

      //Act
      Spiller s1 = controller.Rediger(1).ViewData.Model as Spiller;
      Spiller s2 = controller.Rediger(2).ViewData.Model as Spiller;
      Spiller s3 = controller.Rediger(3).ViewData.Model as Spiller;

      //Assert
      Assert.AreEqual(1, s1.Spiller_ID);
      Assert.AreEqual(2, s2.Spiller_ID);
      Assert.AreEqual(3, s3.Spiller_ID);
    }

    [TestMethod]
    public void Test_Kan_gemme_redigeringer() {
      //Arrange
      Mock<IRepository> mock = new Mock<IRepository>();
      SpillerController controller = new SpillerController(mock.Object);

      Spiller spiller = new Spiller {
        Spiller_ID = 1,
        Navn = "Hans",
        Indkasserede_Maal = 1,
        Scorede_Maal = 2,
        Tabte = 3,
        Uafgjorte = 4,
        Vundne = 5,
        WS = 6,
        Administrator = 0
      };

      //Act
      ActionResult result = controller.Rediger(spiller);

      //Assert
      mock.Verify(m => m.GemSpiller(spiller));

      //Tjek om vores viewresult er af typen ViewResult eller ActionResult
      Assert.IsNotInstanceOfType(result, typeof(ViewResult));
    }

    [TestMethod]
    public void Test_kan_ikke_gemme_redigeringer() {
      //Arrange
      Mock<IRepository> mock = new Mock<IRepository>();

      SpillerController controller = new SpillerController(mock.Object);

      Spiller spiller = new Spiller {
        Spiller_ID = 1,
        Navn = "Hans",
        Indkasserede_Maal = 1,
        Scorede_Maal = 2,
        Tabte = 3,
        Uafgjorte = 4,
        Vundne = 5,
        WS = 6,
        Administrator = 0
      };

      controller.ModelState.AddModelError("error", "error");

      //Act
      ActionResult result = controller.Rediger(spiller);

      //Assert - sørger for at repository ikke bliver kaldt
      mock.Verify(m => m.GemSpiller(It.IsAny<Spiller>()), Times.Never());

      //Assert - Tjekker hvilket view vi returnere    
      Assert.IsInstanceOfType(result, typeof(ViewResult));
    }
  }
}
