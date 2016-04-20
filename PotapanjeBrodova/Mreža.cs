using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public enum Smjer
    {
        Horizontalno,
        Vertikalno
    }

    public class Mreža
    {
        public Mreža(int redaka, int stupaca)
        {
            Redaka = redaka;
            Stupaca = stupaca;
            for (int r = 0; r < redaka; ++r)
            {
                for (int s = 0; s < stupaca; ++s)
                    polja.Add(new Polje(r, s));
            }
        }

        public IEnumerable<Polje> DajSlobodnaPolja()
        {
            return polja;
        }

        public void EliminirajPolje(Polje p)
        {
            polja.Remove(p);
        }

        private List<Polje> polja = new List<Polje>();
        public readonly int Redaka;
        public readonly int Stupaca;

        static public IEnumerable<Polje> DajPoljaZaBrod(Smjer smjer, Polje početno, int duljinaBroda)
        {
            int redak = početno.Redak;
            int stupac = početno.Stupac;
            int deltaRedak = smjer == Smjer.Horizontalno ? 0 : 1;
            int deltaStupac = smjer == Smjer.Vertikalno ? 0 : 1;
            List<Polje> polja = new List<Polje>();
            for (int i = 0; i < duljinaBroda; ++i)
            {
                polja.Add(new Polje(redak, stupac));
                redak += deltaRedak;
                stupac += deltaStupac;
            }
            return polja;
        }
    }
}
