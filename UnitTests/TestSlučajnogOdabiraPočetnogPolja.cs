using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class TestSlučajnogOdabiraPočetnogPolja
    {
        [TestMethod]
        public void SlučajniOdabirPočetnogPolja_DajHorizontalnaPočetnaPoljaZa5HorizontalnihPoljaVraća2KrajnjaLijevaPoljaZaBrodDuljine4()
        {
            List<Polje> polja = new List<Polje>
            {
                new Polje(0, 0),
                new Polje(0, 1),
                new Polje(0, 2),
                new Polje(0, 3),
                new Polje(0, 4)
            };

            SlučajniOdabirPočetnogPolja sopp = new SlučajniOdabirPočetnogPolja();
            var slobodnaPolja = sopp.DajHorizontalnaPočetnaPolja(polja, 4);
            Assert.AreEqual(2, slobodnaPolja.Count());
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(0, 0)));
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(0, 1)));
        }

        [TestMethod]
        public void SlučajniOdabirPočetnogPolja_DajHorizontalnaPočetnaPoljaZa5HorizontalnihPoljaVraćaSvaPoljaZaBrodDuljine1()
        {
            List<Polje> polja = new List<Polje>
            {
                new Polje(0, 0),
                new Polje(0, 1),
                new Polje(0, 2),
                new Polje(0, 3),
                new Polje(0, 4)
            };

            SlučajniOdabirPočetnogPolja sopp = new SlučajniOdabirPočetnogPolja();
            var slobodnaPolja = sopp.DajHorizontalnaPočetnaPolja(polja, 1);
            Assert.AreEqual(5, slobodnaPolja.Count());
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(0, 0)));
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(0, 1)));
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(0, 2)));
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(0, 3)));
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(0, 4)));
        }

        [TestMethod]
        public void SlučajniOdabirPočetnogPolja_DajHorizontalnaPočetnaPoljaZa4HorizontalnaPoljaNeVraćaNitiJednoPoljeZaBrodDuljine5()
        {
            List<Polje> polja = new List<Polje>
            {
                new Polje(0, 1),
                new Polje(0, 2),
                new Polje(0, 3),
                new Polje(0, 4)
            };

            SlučajniOdabirPočetnogPolja sopp = new SlučajniOdabirPočetnogPolja();
            var slobodnaPolja = sopp.DajHorizontalnaPočetnaPolja(polja, 5);
            Assert.AreEqual(0, slobodnaPolja.Count());
        }


        [TestMethod]
        public void SlučajniOdabirPočetnogPolja_DajVertikalnaPočetnaPoljaZa5VertikalnihPoljaVraća2KrajnjaGornjaPoljaZaBrodDuljine4()
        {
            List<Polje> polja = new List<Polje>
            {
                new Polje(1, 2),
                new Polje(2, 2),
                new Polje(3, 2),
                new Polje(4, 2),
                new Polje(5, 2)
            };

            SlučajniOdabirPočetnogPolja sopp = new SlučajniOdabirPočetnogPolja();
            var slobodnaPolja = sopp.DajVertikalnaPočetnaPolja(polja, 4);
            Assert.AreEqual(2, slobodnaPolja.Count());
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(1, 2)));
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(2, 2)));
        }

        [TestMethod]
        public void SlučajniOdabirPočetnogPolja_DajVertikalnaPočetnaPoljaZa5VertikalnihPoljaVraćaSvaPoljaZaBrodDuljine1()
        {
            List<Polje> polja = new List<Polje>
            {
                new Polje(3, 3),
                new Polje(4, 3),
                new Polje(5, 3),
                new Polje(6, 3),
                new Polje(7, 3)
            };

            SlučajniOdabirPočetnogPolja sopp = new SlučajniOdabirPočetnogPolja();
            var slobodnaPolja = sopp.DajVertikalnaPočetnaPolja(polja, 1);
            Assert.AreEqual(5, slobodnaPolja.Count());
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(3, 3)));
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(4, 3)));
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(5, 3)));
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(6, 3)));
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(7, 3)));
        }

        [TestMethod]
        public void SlučajniOdabirPočetnogPolja_DajVertikalnaPočetnaPoljaZa4VertikalnaPoljaNeVraćaNitiJednoPoljeZaBrodDuljine5()
        {
            List<Polje> polja = new List<Polje>
            {
                new Polje(2, 1),
                new Polje(3, 1),
                new Polje(4, 1),
                new Polje(5, 1)
            };

            SlučajniOdabirPočetnogPolja sopp = new SlučajniOdabirPočetnogPolja();
            var slobodnaPolja = sopp.DajVertikalnaPočetnaPolja(polja, 5);
            Assert.AreEqual(0, slobodnaPolja.Count());
        }
    }
}