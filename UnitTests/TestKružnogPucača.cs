using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Collections.Generic;


namespace UnitTests
{
    [TestClass]
    public class TestKružnogPucača
    {
        [TestMethod]
        public void KružniPucač_UpućujePucanjUJednoOdČetiriOkolnihPolja()
        {
            Mreža m = new Mreža(10, 10);
            Polje prvoPogođeno = new Polje(5, 5);
            KružniPucač pucač = new KružniPucač(prvoPogođeno, m);
            List<Polje> kandidati = new List<Polje> { new Polje(4, 5), new Polje(6, 5), new Polje(5, 4), new Polje(5, 6)};
            Assert.IsTrue(kandidati.Contains(pucač.UputiPucanj()));
        }
    }
}
