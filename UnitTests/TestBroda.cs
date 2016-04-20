using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;

namespace UnitTests
{
    /// <summary>
    /// Summary description for TestBroda
    /// </summary>
    [TestClass]
    public class TestBroda
    {
        [TestMethod]
        public void Brod_GađajVraćaPromašajZaPoljeKojeNijeUBrodu()
        {
            Polje[] polja = { new Polje(1, 2), new Polje(1, 3), new Polje(1, 4) };
            Brod b = new Brod(polja);
            Assert.AreEqual(RezultatGađanja.Promašaj, b.Gađaj(new Polje(2, 3)));
        }

        [TestMethod]
        public void Brod_GađajVraćaPogodakZaPoljeKojeJeUBrodu()
        {
            Polje[] polja = { new Polje(1, 2), new Polje(1, 3), new Polje(1, 4) };
            Brod b = new Brod(polja);
            Assert.AreEqual(RezultatGađanja.Pogodak, b.Gađaj(new Polje(1, 2)));
        }

        [TestMethod]
        public void Brod_GađajVraćaPotounćeZaZadnjePoljeKojeJeUBrodu()
        {
            Polje[] polja = { new Polje(1, 2), new Polje(1, 3), new Polje(1, 4) };
            Brod b = new Brod(polja);
            Assert.AreEqual(RezultatGađanja.Pogodak, b.Gađaj(new Polje(1, 2)));
            Assert.AreEqual(RezultatGađanja.Pogodak, b.Gađaj(new Polje(1, 4)));
            Assert.AreEqual(RezultatGađanja.Potonuće, b.Gađaj(new Polje(1, 3)));
        }

        [TestMethod]
        public void Brod_GađajVraćaPogodakZaPoljeKojeJePonovnoPogođeno()
        {
            Polje[] polja = { new Polje(1, 2), new Polje(1, 3), new Polje(1, 4) };
            Brod b = new Brod(polja);
            Assert.AreEqual(RezultatGađanja.Pogodak, b.Gađaj(new Polje(1, 2)));
            Assert.AreEqual(RezultatGađanja.Pogodak, b.Gađaj(new Polje(1, 2)));
        }

        [TestMethod]
        public void Brod_GađajVraćaPotonućeZaZadnjePoljeKojeJePonovnoPogođeno()
        {
            Polje[] polja = { new Polje(1, 2), new Polje(1, 3), new Polje(1, 4) };
            Brod b = new Brod(polja);
            Assert.AreEqual(RezultatGađanja.Pogodak, b.Gađaj(new Polje(1, 2)));
            Assert.AreEqual(RezultatGađanja.Pogodak, b.Gađaj(new Polje(1, 4)));
            Assert.AreEqual(RezultatGađanja.Potonuće, b.Gađaj(new Polje(1, 3)));
            Assert.AreEqual(RezultatGađanja.Potonuće, b.Gađaj(new Polje(1, 3)));
        }
    }
}
