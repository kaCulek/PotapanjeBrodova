using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PotapanjeBrodova
{
    public enum Orijentacija
    {
        Horizontalno,
        Vertikalno
    }

    public enum Smjer
    {
        Gore,
        Dolje,
        Lijevo,
        Desno
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

        static public IEnumerable<Polje> DajPoljaZaBrod(Orijentacija orijentacija, Polje početno, int duljinaBroda)
        {
            int redak = početno.Redak;
            int stupac = početno.Stupac;
            int deltaRedak = orijentacija == Orijentacija.Horizontalno ? 0 : 1;
            int deltaStupac = orijentacija == Orijentacija.Vertikalno ? 0 : 1;
            List<Polje> polja = new List<Polje>();
            for (int i = 0; i < duljinaBroda; ++i)
            {
                polja.Add(new Polje(redak, stupac));
                redak += deltaRedak;
                stupac += deltaStupac;
            }
            return polja;
        }

        public IEnumerable<Polje> DajPoljaUZadanomSmjeru(int redak, int stupac, Smjer smjer)
        {
            switch (smjer)
            {
                case Smjer.Gore:
                    return DajPoljaIznad(redak, stupac);
                case Smjer.Desno:
                    return DajPoljaDesno(redak, stupac);
                case Smjer.Dolje:
                    return DajPoljaDolje(redak, stupac);
                case Smjer.Lijevo:
                    return DajPoljaLijevo(redak, stupac);
                default:
                    Debug.Assert(false, string.Format("Nije podržan smjer: {0}", smjer.ToString()));
                    return null;
            }
        }
        private IEnumerable<Polje> DajPoljaIznad(int redak, int stupac)
        {
            List<Polje> slobodna = new List<Polje>();
            while (--redak >= 0 && polja[redak, stupac] != null)
                slobodna.Add(polja[redak, stupac]);
            return slobodna;         
        }

        private IEnumerable<Polje> DajPoljaDesno(int redak, int stupac)
        {
            List<Polje> slobodna = new List<Polje>();
            while (++stupac < Stupaca && polja[redak, stupac] != null)
                slobodna.Add(polja[redak, stupac]);
            return slobodna;
        }

        private IEnumerable<Polje> DajPoljaDolje(int redak, int stupac)
        {
            List<Polje> slobodna = new List<Polje>();
            while (++redak < Redaka && polja[redak, stupac] != null)
                slobodna.Add(polja[redak, stupac]);
            return slobodna;
        }

        private IEnumerable<Polje> DajPoljaLijevo(int redak, int stupac)
        {
            List<Polje> slobodna = new List<Polje>();
            while (--stupac >= 0 && polja[redak, stupac] != null)
                slobodna.Add(polja[redak, stupac]);
            return slobodna;
        }

    }
}
