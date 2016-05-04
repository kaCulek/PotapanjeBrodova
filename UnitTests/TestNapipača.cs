using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class TestNapipača
    {
        [TestMethod]
        public void Napipač_ListaPoljaZaHorizontalniBrodDuljine3MoraSadržavati15Polja()
        {
            Mreža m = new Mreža(1, 7);
            const int duljinaBroda = 3;
            Napipač n = new Napipač(m, duljinaBroda);
            Assert.AreEqual(15, n.DajKandidateZaHorizontalniBrod().Count());
        }

  //      [TestMethod]
  //      public void Napipač_ListaPoljaZaHorizontalniBrodDuljine3MoraSadržavatiPoljaUOdređenomPolju()
  //      {
  //          Mreža m = new Mreža(1, 7);
  //          const int duljinaBroda = 3;
  //          Napipač n = new Napipač(m, duljinaBroda);
  //          Assert.AreEqual(15, n.DajKandidateZaHorizontalniBrod().Count());
  //      }
  // izračunati koliko se koje polje pojavljuje za provjeru testa : DZ

        [TestMethod]
        public void Napipač_ListaPoljaZaVertikalniBrodDuljine4MoraSadržavati16Polja()
        {
            Mreža m = new Mreža(2, 5);
            const int duljinaBroda = 4;
            Napipač n = new Napipač(m, duljinaBroda);
            Assert.AreEqual(16, n.DajKandidateZaHorizontalniBrod().Count());
        }

    }
}
