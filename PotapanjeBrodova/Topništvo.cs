using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public enum TaktikaGađanja
    {
        Napipavanje,
        Okruživanje,
        SustavnoUništavanje
    }

    public class Topništvo
    {
        public Topništvo()
        {
            PromijeniTaktikuUNapipavanje();
        }

        public Polje UputiPucanj()
        {
            throw new NotImplementedException();
        }

        public void ObradiGađanje(RezultatGađanja rezultat)
        {

        }

        private void PromijeniTaktikuUNapipavanje()
        {
            TrenutnaTaktika = TaktikaGađanja.Napipavanje;
        }

        private void PromijeniTaktikuUOkruživanje()
        {
            TrenutnaTaktika = TaktikaGađanja.Okruživanje;
        }

        private void PromijeniTaktikuUSustavnoUništavanje()
        {
            TrenutnaTaktika = TaktikaGađanja.SustavnoUništavanje;
        }

        public TaktikaGađanja TrenutnaTaktika
        {
            get; private set;
        }
    }
}
