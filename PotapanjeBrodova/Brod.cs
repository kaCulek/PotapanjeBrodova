using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public enum RezultatGađanja
    {
        Promašaj,
        Pogodak,
        Potonuće
    }

    public class Brod
    {
        public Brod(IEnumerable<Polje> polja)
        {
            this.Polja = polja;
        }

        public int Duljina
        {
            get { return Polja.Count(); }
        }

        public readonly IEnumerable<Polje> Polja;
    }
}
