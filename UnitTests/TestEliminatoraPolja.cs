using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;

namespace UnitTests
{
    [TestClass]
    public class TestKlasičnogEliminatoraPolja
    {
        [TestMethod]
        public void KlasičniEliminatorPolja_PoljaKojaTrebaUklonitiOkoBrodaVraćaPoljaBrodaISvaOkolnaPoljaZaBrodUSrediniMreže()
        {
            int redaka = 10;
            int stupaca = 10;
            int duljinaBroda = 4;
            Polje početnoPolje = new Polje(3, 2);
            Orijentacija smjer = Orijentacija.Vertikalno;

            Mreža m = new Mreža(redaka, stupaca);
            var poljaBroda = m.DajPoljaZaBrod(smjer, početnoPolje, duljinaBroda);

            IEliminatorPolja e = new KlasičniEliminatorPolja();
            var zaEliminirati = e.PoljaKojaTrebaUklonitiOkoBroda(poljaBroda, redaka, stupaca);
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
        public void KlasičniEliminatorPolja_PoljaKojaTrebaUklonitiOkoBrodaVraćaPoljaBrodaIPoljaIspodIDesnoZaBrodUGornjemLijevomKutuMreže()
        {
            int redaka = 10;
            int stupaca = 10;
            int duljinaBroda = 4;
            Polje početnoPolje = new Polje(0, 0);
            Orijentacija smjer = Orijentacija.Horizontalno;

            Mreža m = new Mreža(redaka, stupaca);
            var poljaBroda = m.DajPoljaZaBrod(smjer, početnoPolje, duljinaBroda);

            IEliminatorPolja e = new KlasičniEliminatorPolja();
            var zaEliminirati = e.PoljaKojaTrebaUklonitiOkoBroda(poljaBroda, redaka, stupaca);
            Assert.AreEqual(10, zaEliminirati.Count());
            foreach (Polje p in poljaBroda)
                Assert.IsTrue(zaEliminirati.Contains(p));
            // provjerimo 3 krajnja polja uz brod (ispod-lijevo, ispod-desno, desno)
            Assert.IsTrue(zaEliminirati.Contains(new Polje(1, 0)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(1, 4)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(0, 4)));
        }

        [TestMethod]
        public void KlasičniEliminatorPolja_PoljaKojaTrebaUklonitiOkoBrodaVraćaPoljaBrodaIPoljaLijevoIIspodZaBrodUGornjemDesnomKutuMreže()
        {
            int redaka = 10;
            int stupaca = 10;
            int duljinaBroda = 4;
            Polje početnoPolje = new Polje(0, stupaca - 1);
            Orijentacija smjer = Orijentacija.Vertikalno;

            Mreža m = new Mreža(redaka, stupaca);
            var poljaBroda = m.DajPoljaZaBrod(smjer, početnoPolje, duljinaBroda);

            IEliminatorPolja e = new KlasičniEliminatorPolja();
            var zaEliminirati = e.PoljaKojaTrebaUklonitiOkoBroda(poljaBroda, redaka, stupaca);
            Assert.AreEqual(10, zaEliminirati.Count());
            foreach (Polje p in poljaBroda)
                Assert.IsTrue(zaEliminirati.Contains(p));
            // provjerimo 3 krajnja polja uz brod (lijevo-gore, lijevo-ispod, ispod)
            Assert.IsTrue(zaEliminirati.Contains(new Polje(0, stupaca - 2)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(duljinaBroda, stupaca - 2)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(duljinaBroda, stupaca - 1)));
        }

        [TestMethod]
        public void KlasičniEliminatorPolja_PoljaKojaTrebaUklonitiOkoBrodaVraćaPoljaBrodaIPoljaLijevoIIznadZaBrodUDonjemDesnomKutuMreže()
        {
            int redaka = 10;
            int stupaca = 10;
            int duljinaBroda = 4;
            Polje početnoPolje = new Polje(redaka - 1, stupaca - duljinaBroda);
            Orijentacija smjer = Orijentacija.Horizontalno;

            Mreža m = new Mreža(redaka, stupaca);
            var poljaBroda = m.DajPoljaZaBrod(smjer, početnoPolje, duljinaBroda);

            IEliminatorPolja e = new KlasičniEliminatorPolja();
            var zaEliminirati = e.PoljaKojaTrebaUklonitiOkoBroda(poljaBroda, redaka, stupaca);
            Assert.AreEqual(10, zaEliminirati.Count());
            foreach (Polje p in poljaBroda)
                Assert.IsTrue(zaEliminirati.Contains(p));
            // provjerimo 3 krajnja polja uz brod (lijevo, lijevo-iznad, desno iznad)
            Assert.IsTrue(zaEliminirati.Contains(new Polje(redaka - 1, početnoPolje.Stupac - 1)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(redaka - 2, početnoPolje.Stupac - 1)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(redaka - 2, stupaca - 1)));
        }

        [TestMethod]
        public void KlasičniEliminatorPolja_PoljaKojaTrebaUklonitiOkoBrodaVraćaPoljaBrodaIPoljaLijevoIIznadZaBrodUDonjemLijevomKutuMreže()
        {
            int redaka = 10;
            int stupaca = 10;
            int duljinaBroda = 4;
            Polje početnoPolje = new Polje(redaka - duljinaBroda, 0);
            Orijentacija smjer = Orijentacija.Vertikalno;

            Mreža m = new Mreža(redaka, stupaca);
            var poljaBroda = m.DajPoljaZaBrod(smjer, početnoPolje, duljinaBroda);

            IEliminatorPolja e = new KlasičniEliminatorPolja();
            var zaEliminirati = e.PoljaKojaTrebaUklonitiOkoBroda(poljaBroda, redaka, stupaca);
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