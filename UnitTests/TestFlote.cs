using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using PotapanjeBrodova;

namespace UnitTests
{
    [TestClass]
    public class TestFlote
    {
        private IEnumerable<Polje> SložiPolja(Smjer smjer, Polje početno, int duljinaBroda)
        {
            return Mreža.DajPoljaZaBrod(smjer, početno, duljinaBroda);
        }

        [TestMethod]
        public void Flota_DodajBrodaTriRazličitaBrodaSlažeFlotuOdTriBroda()
        {
            Flota f = new Flota();
            Brod b1 = new Brod(SložiPolja(Smjer.Horizontalno, new Polje(0, 0), 5));
            f.DodajBrod(b1);
            Brod b2 = new Brod(SložiPolja(Smjer.Vertikalno, new Polje(1, 3), 4));
            f.DodajBrod(b2);
            Brod b3 = new Brod(SložiPolja(Smjer.Horizontalno, new Polje(4, 5), 3));
            f.DodajBrod(b3);

            Assert.AreEqual(3, f.Brodovi.Count());
            Assert.IsTrue(f.Brodovi.Contains(b1));
            Assert.IsTrue(f.Brodovi.Contains(b2));
            Assert.IsTrue(f.Brodovi.Contains(b3));
        }
    }
}
