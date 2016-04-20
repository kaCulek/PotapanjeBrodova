using System;
using System.Linq;
using PotapanjeBrodova;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TestEliminatoraPolja
    {
        [TestMethod]
        public void Brodograditelj_PoljaKojaTrebaEliminiratiOkoBrodaVraćaPoljaBrodaISvaOkolnaPoljaZaBrodUSrediniMreže()
        {
            int redaka = 10;
            int stupaca = 10;
            int duljinaBroda = 4;
            Polje početnoPolje = new Polje(3, 2);
            Smjer smjer = Smjer.Vertikalno;

            var poljaBroda = Mreža.DajPoljaZaBrod(smjer, početnoPolje, duljinaBroda);

            IEliminatorPolja e = new KlasičniEliminatorPolja();
            var zaEliminirati = e.PoljaKojaTrebaEliminiratiOkoBroda(poljaBroda, redaka, stupaca);
            Assert.AreEqual(18, zaEliminirati.Count());
            foreach (Polje p in poljaBroda)
                Assert.IsTrue(zaEliminirati.Contains(p));
            // provjerimo polja u uglovima broda (lijevo-gore, lijevo-dolje, desno-gore i desno-dolje)
            Assert.IsTrue(zaEliminirati.Contains(new Polje(2, 1)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(2, 3)));
           Assert.IsTrue(zaEliminirati.Contains(new Polje(7, 1)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(7, 3)));
        }

        [TestMethod]
        public void Brodograditelj_PoljaKojaTrebaEliminiratiOkoBrodaVraćaPoljaBrodaIPoljaIspodIDesnoZaBrodUGornjemLijevomKutuMreže()
        {
            int redaka = 10;
            int stupaca = 10;
            int duljinaBroda = 4;
            Polje početnoPolje = new Polje(0, 0);
            Smjer smjer = Smjer.Horizontalno;

            var poljaBroda = Mreža.DajPoljaZaBrod(smjer, početnoPolje, duljinaBroda);

            IEliminatorPolja e = new KlasičniEliminatorPolja();
            var zaEliminirati = e.PoljaKojaTrebaEliminiratiOkoBroda(poljaBroda, redaka, stupaca);
            Assert.AreEqual(10, zaEliminirati.Count());
            foreach (Polje p in poljaBroda)
                Assert.IsTrue(zaEliminirati.Contains(p));
            // provjerimo 3 krajnja polja uz brod (ispod-lijevo, ispod-desno, desno)
            Assert.IsTrue(zaEliminirati.Contains(new Polje(1, 0)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(1, 4)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(0, 4)));
        }

        [TestMethod]
        public void Brodograditelj_PoljaKojaTrebaEliminiratiOkoBrodaVraćaPoljaBrodaIPoljaLijevoIIspodZaBrodUGornjemDesnomKutuMreže()
        {
            int redaka = 10;
            int stupaca = 10;
            int duljinaBroda = 4;
            Polje početnoPolje = new Polje(0, stupaca - 1);
            Smjer smjer = Smjer.Vertikalno;

            var poljaBroda = Mreža.DajPoljaZaBrod(smjer, početnoPolje, duljinaBroda);

            IEliminatorPolja e = new KlasičniEliminatorPolja();
            var zaEliminirati = e.PoljaKojaTrebaEliminiratiOkoBroda(poljaBroda, redaka, stupaca);
            Assert.AreEqual(10, zaEliminirati.Count());
            foreach (Polje p in poljaBroda)
                Assert.IsTrue(zaEliminirati.Contains(p));
            // provjerimo 3 krajnja polja uz brod (lijevo-gore, lijevo-ispod, ispod)
            Assert.IsTrue(zaEliminirati.Contains(new Polje(0, stupaca - 2)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(duljinaBroda, stupaca - 2)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(duljinaBroda, stupaca - 1)));
        }

        [TestMethod]
        public void Brodograditelj_PoljaKojaTrebaEliminiratiOkoBrodaVraćaPoljaBrodaIPoljaLijevoIIznadZaBrodUDonjemDesnomKutuMreže()
        {
            int redaka = 10;
            int stupaca = 10;
            int duljinaBroda = 4;
            Polje početnoPolje = new Polje(redaka - 1, stupaca - duljinaBroda);
            Smjer smjer = Smjer.Horizontalno;

            var poljaBroda = Mreža.DajPoljaZaBrod(smjer, početnoPolje, duljinaBroda);

            IEliminatorPolja e = new KlasičniEliminatorPolja();
            var zaEliminirati = e.PoljaKojaTrebaEliminiratiOkoBroda(poljaBroda, redaka, stupaca);
            Assert.AreEqual(10, zaEliminirati.Count());
            foreach (Polje p in poljaBroda)
                Assert.IsTrue(zaEliminirati.Contains(p));
            // provjerimo 3 krajnja polja uz brod (lijevo, lijevo-iznad, desno iznad)
            Assert.IsTrue(zaEliminirati.Contains(new Polje(redaka - 1, početnoPolje.Stupac - 1)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(redaka - 2, početnoPolje.Stupac - 1)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(redaka - 2, stupaca - 1)));
        }

        [TestMethod]
        public void Brodograditelj_PoljaKojaTrebaEliminiratiOkoBrodaVraćaPoljaBrodaIPoljaLijevoIIznadZaBrodUDonjemLijevomKutuMreže()
        {
            int redaka = 10;
            int stupaca = 10;
            int duljinaBroda = 4;
            Polje početnoPolje = new Polje(redaka - duljinaBroda, 0);
            Smjer smjer = Smjer.Vertikalno;

            var poljaBroda = Mreža.DajPoljaZaBrod(smjer, početnoPolje, duljinaBroda);

            IEliminatorPolja e = new KlasičniEliminatorPolja();
            var zaEliminirati = e.PoljaKojaTrebaEliminiratiOkoBroda(poljaBroda, redaka, stupaca);
            Assert.AreEqual(10, zaEliminirati.Count());
            foreach (Polje p in poljaBroda)
                Assert.IsTrue(zaEliminirati.Contains(p));
            // provjerimo 3 krajnja polja uz brod (iznad, iznad-desno, desno dolje)
            Assert.IsTrue(zaEliminirati.Contains(new Polje(početnoPolje.Redak - 1, 0)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(početnoPolje.Redak - 1, 1)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(redaka - 1, 1)));
        }
    }
}
