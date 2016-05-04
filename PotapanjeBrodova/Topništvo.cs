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
        public Topništvo(int redaka, int stupaca, int[] duljineBrodova)
        {
            mreža = new Mreža(redaka, stupaca);
            this.duljineBrodova = new List<int>(duljineBrodova);
            this.duljineBrodova.Sort((d1, d2) => d2 - d1);
            PromijeniTaktikuUNapipavanje();
        }

        public Polje UputiPucanj()
        {
            return pucač.UputiPucanj();
        }

        public void ObradiGađanje(RezultatGađanja rezultat)
        {
            if (rezultat == RezultatGađanja.Pogodak)
            {
                if (TrenutnaTaktika == TaktikaGađanja.Napipavanje)
                    PromijeniTaktikuUOkruživanje();
                else if (TrenutnaTaktika == TaktikaGađanja.Okruživanje)
                    PromijeniTaktikuUSustavnoUništavanje();
            }
            else if (rezultat == RezultatGađanja.Potonuće)
                PromijeniTaktikuUNapipavanje();
        }

        private void PromijeniTaktikuUNapipavanje()
        {
            TrenutnaTaktika = TaktikaGađanja.Napipavanje;
            pucač = new Napipač(mreža, duljineBrodova[0]);
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

        
        iPucač pucač;
        Mreža mreža;
        List<int> duljineBrodova;
    }
}
