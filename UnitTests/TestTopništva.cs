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
    }
}
