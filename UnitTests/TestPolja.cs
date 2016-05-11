using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PotapanjeBrodova;

namespace UnitTests
{
    [TestClass]
    public class TestPolja
    {
        [TestMethod]
        public void Polje_SvojstvaRedakStupacJednakaSuVrijednostimaZadanimKonstruktorom()
        {
            Polje p = new Polje(1, 2);
            Assert.AreEqual(1, p.Redak);
            Assert.AreEqual(2, p.Stupac);
        }

        [TestMethod]
        public void Polje_PoljaSIstimRetkomIStupcemSuJednaka()
        {
            Polje p1 = new Polje(1, 2);
            Polje p2 = new Polje(1, 2);
            Assert.AreEqual(p1, p2);
        }

        [TestMethod]
        public void Polje_PoljaSRazličitimRetkomIliStupcemSuRazličita()
        {
            Polje p1 = new Polje(1, 2);
            Assert.AreNotEqual(new Polje(1, 1), p1);
            Assert.AreNotEqual(new Polje(2, 2), p1);
        }
    }
}