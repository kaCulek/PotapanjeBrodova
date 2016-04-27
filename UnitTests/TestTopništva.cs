using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;

namespace UnitTests
{
    [TestClass]
    public class TestTopništva
    {
        [TestMethod]
        public void Topništvo_PočetnaTaktikaGađanjaJeNapipavanje()
        {
            Topništvo t = new Topništvo();
            Assert.AreEqual(TaktikaGađanja.Napipavanje, t.TrenutnaTaktika);
        }

        [TestMethod]
        public void Topništvo_TaktikaGađanjaNakonPrvogPogodkaJeOkruživanje()
        {
            Topništvo t = new Topništvo();
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            Assert.AreEqual(TaktikaGađanja.Okruživanje, t.TrenutnaTaktika);
        }

        [TestMethod]
        public void Topništvo_TaktikaGađanjaNakonDrugogPogodkaJeSustavnoUništavanje()
        {
            Topništvo t = new Topništvo();
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            Assert.AreEqual(TaktikaGađanja.SustavnoUništavanje, t.TrenutnaTaktika);
        }

        [TestMethod]
        public void Topništvo_TaktikaGađanjaNakonPotonućaJeNapipavanje()
        {
            Topništvo t = new Topništvo();
            t.ObradiGađanje(RezultatGađanja.Potonuće);
            Assert.AreEqual(TaktikaGađanja.Napipavanje, t.TrenutnaTaktika);
        }

        [TestMethod]
        public void Topništvo_TaktikaGađanjaNakonPromašajaSeNeMijenja()
        {
            Topništvo t = new Topništvo();
            // inicijalno je Napipavanje
            t.ObradiGađanje(RezultatGađanja.Promašaj);
            Assert.AreEqual(TaktikaGađanja.Napipavanje, t.TrenutnaTaktika);
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            // nakon prvog pogotka je Okruživanje
            t.ObradiGađanje(RezultatGađanja.Promašaj);
            Assert.AreEqual(TaktikaGađanja.Okruživanje, t.TrenutnaTaktika);
            t.ObradiGađanje(RezultatGađanja.Pogodak);
            // nakon drugog pogotka je SustavnoUništavanje
            t.ObradiGađanje(RezultatGađanja.Promašaj);
            Assert.AreEqual(TaktikaGađanja.SustavnoUništavanje, t.TrenutnaTaktika);
        }
    }
}
