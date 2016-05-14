﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class KružniPucač : iPucač
    {
        public KružniPucač(Polje prvoPogođeno, Mreža mreža)
        {
            this.prvoPogođeno = prvoPogođeno;
            this.mreža = mreža;
        }
        public Polje UputiPucanj()
        {
            int redak = prvoPogođeno.Redak;
            int stupac = prvoPogođeno.Stupac;
            List<IEnumerable<Polje>> kandidati = new List<IEnumerable<Polje>>();
            foreach (Smjer smjer in Enum.GetValues(typeof(Smjer)))
            {
                kandidati.Add(mreža.DajPoljaUZadanomSmjeru(redak, stupac, smjer));
            }
            kandidati.Sort((lista1, lista2) => lista2.Count() - lista1.Count());
            var grupe = kandidati.GroupBy(lista => lista.Count());
            // između najduljih biram jednu slučajnim odabirom
            var najdulji = grupe.First();
            if (najdulji.Count() == 1)

                return najdulji.First().First();
            int indeks = slučajni.Next(0, najdulji.Count());
            return najdulji.ElementAt(indeks).First();
        }

        Polje prvoPogođeno;
        Mreža mreža;
        Random slučajni = new Random();
    }
}
