using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class Brodograditelj
    {
        public Brodograditelj()
        {
            this.eliminatorPolja = new KlasičniEliminatorPolja();
        }

        public Brodograditelj(IEliminatorPolja eliminator)
        {
           eliminatorPolja = eliminator;
        }

        public Flota SložiFlotu(int redaka, int stupaca, int[] duljineBrodova)
        {
            Flota f = new Flota();
            // napravi mrežu
            Mreža m = new Mreža(redaka, stupaca);
            do
            {
                f = new Flota();
                m = new Mreža(redaka, stupaca);
                // za svaku duljinu broda:
                for (int i = 0; i < duljineBrodova.Length; ++i)
                {
                    var slobodnaPolja = m.DajSlobodnaPolja();
                    var pp = IzaberiPočetnoPolje(slobodnaPolja, duljineBrodova[i]);
                    if (pp == null)
                    {
                        m = null;
                        break;
                    }
                    var pbr = Mreža.DajPoljaZaBrod(pp.Item1, pp.Item2, duljineBrodova[i]);
                    Brod b = new Brod(pbr);
                    f.DodajBrod(b);
                    EliminirajPoljaOkoBroda(m, pbr);
                }
            } while (m == null);

            return f;
        }
   

        

       

        private void EliminirajPoljaOkoBroda(Mreža mreža, IEnumerable<Polje> brodskaPolja)
        {
            IEnumerable<Polje> zaEliminirati = eliminatorPolja.PoljaKojaTrebaEliminiratiOkoBroda(brodskaPolja, mreža.Redaka, mreža.Stupaca);
            foreach (Polje p in zaEliminirati)
                mreža.EliminirajPolje(p);
        }

        public Tuple<Smjer, Polje> IzaberiPočetnoPolje(IEnumerable<Polje> slobodnaPolja, int duljinaBroda)
        {
            var horizontalnaPolja = DajHorizontalnaPočetnaPolja(slobodnaPolja, duljinaBroda);
            var vertikalnaPolja = DajVertikalnaPočetnaPolja(slobodnaPolja, duljinaBroda);
            int ukupnoKandidata = horizontalnaPolja.Count() + vertikalnaPolja.Count();
            if (ukupnoKandidata == 0)
                return null;
            int izbor = slučajni.Next(0, ukupnoKandidata);
            if (izbor >= horizontalnaPolja.Count())
                return new Tuple<Smjer, Polje>(Smjer.Vertikalno, vertikalnaPolja.ElementAt(izbor - horizontalnaPolja.Count()));
            return new Tuple<Smjer, Polje>(Smjer.Horizontalno, horizontalnaPolja.ElementAt(izbor));
        }

        public IEnumerable<Polje> DajHorizontalnaPočetnaPolja(IEnumerable<Polje> slobodnaPolja, int duljinaBroda)
        {
            List<Polje> polja = new List<Polje>();
            foreach (Polje p in slobodnaPolja)
            {
                if (ImaDovoljnoPoljaDesno(p, slobodnaPolja, duljinaBroda))
                    polja.Add(p);
            }
            return polja;
        }

        public IEnumerable<Polje> DajVertikalnaPočetnaPolja(IEnumerable<Polje> slobodnaPolja, int duljinaBroda)
        {
            List<Polje> polja = new List<Polje>();
            foreach (Polje p in slobodnaPolja)
            {
                if (ImaDovoljnoPoljaIspod(p, slobodnaPolja, duljinaBroda))
                    polja.Add(p);
            }
            return polja;
        }

        bool ImaDovoljnoPoljaDesno(Polje p, IEnumerable<Polje> slobodnaPolja, int duljinaBroda)
        {
            int redak = p.Redak;
            int stupac = p.Stupac;
            for (int s = stupac + 1; s < stupac + duljinaBroda; ++s)
                if (!slobodnaPolja.Contains(new Polje(redak, s)))
                    return false;
            return true;
        }

        bool ImaDovoljnoPoljaIspod(Polje p, IEnumerable<Polje> slobodnaPolja, int duljinaBroda)
        {
            int redak = p.Redak;
            int stupac = p.Stupac;
            for (int r = redak + 1; r < redak + duljinaBroda; ++r)
                if (!slobodnaPolja.Contains(new Polje(r, stupac)))
                    return false;
            return true;
        }
        Random slučajni = new Random();

        IEliminatorPolja eliminatorPolja;
    }
}
