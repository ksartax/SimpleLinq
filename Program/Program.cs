using LinqSimplee;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            GildiaMagow gildiaMagow = new GildiaMagow();

            gildiaMagow.AddEvent += (val) => val;
            gildiaMagow.RemoveEvent += (val) => val;

            gildiaMagow.Zatrudnij(new Mag() {
                Imie = "Gandalf",
                Inteligencja = 5,
                OdpornoscNaObrazeniaFizyczne = 1,
                OdpornoscNaObrazeniaMrozu = 2,
                OdpornoscNaObrazeniaOgnia = 3,
                OdpornoscNaObrazeniaTrucizny = 2,
                Poziom = 100,
                PunktyDoswiadczenia = 3,
                PunktyManyAktualne = 20,
                PunktyManyBazowe = 20,
                PunktyZyciaAktualne = 20,
                PunktyZyciaBazowe = 20,
                Sila = 111,
                ZadawaneObrazenia = 20,
                Zrecznosc = 2,
                KsiegaCzarowList = new KsiegaCzarowList()
                {
                    new CzarDefensywny()
                    {
                        KosztMany = 200,
                        Ladowanie = 2,
                        Nazwa = "Fire",
                        Obrona = 20
                    },
                    new CzaryOfensywne()
                    {
                        KosztMany = 300,
                        Ladowanie = 1,
                        Nazwa = "Oslona",
                        Obrazenia = 20
                    },
                    new CzaryOfensywne()
                    {
                        KosztMany = 302,
                        Ladowanie = 2,
                        Nazwa = "Oss",
                        Obrazenia = 23
                    },
                    new CzarUzdrawiajacy()
                    {
                        KosztMany = 300,
                        Ladowanie = 1,
                        Nazwa = "Oslona2",
                        PktZycia = 200
                    }
                }
            });

            gildiaMagow.Zatrudnij(new Mag()
            {
                Imie = "Ba",
                Inteligencja = 5,
                OdpornoscNaObrazeniaFizyczne = 1,
                OdpornoscNaObrazeniaMrozu = 2,
                OdpornoscNaObrazeniaOgnia = 3,
                OdpornoscNaObrazeniaTrucizny = 2,
                Poziom = 9,
                PunktyDoswiadczenia = 3,
                PunktyManyAktualne = 20,
                PunktyManyBazowe = 20,
                PunktyZyciaAktualne = 20,
                PunktyZyciaBazowe = 20,
                Sila = 3,
                ZadawaneObrazenia = 20,
                Zrecznosc = 2,
                KsiegaCzarowList = new KsiegaCzarowList()
                {
                    new CzarUzdrawiajacy()
                    {
                        KosztMany = 300,
                        Ladowanie = 1,
                        Nazwa = "Oasdasdslona2",
                        PktZycia = 200
                    }
                }
            });

            gildiaMagow.Zatrudnij(new Mag()
            {
                Imie = "Ca",
                Inteligencja = 5,
                OdpornoscNaObrazeniaFizyczne = 1,
                OdpornoscNaObrazeniaMrozu = 2,
                OdpornoscNaObrazeniaOgnia = 9,
                OdpornoscNaObrazeniaTrucizny = 2,
                Poziom = 1,
                PunktyDoswiadczenia = 3,
                PunktyManyAktualne = 20,
                PunktyManyBazowe = 20,
                PunktyZyciaAktualne = 20,
                PunktyZyciaBazowe = 20,
                Sila = 3,
                ZadawaneObrazenia = 20,
                Zrecznosc = 2,
                KsiegaCzarowList = new KsiegaCzarowList()
                {
                    new CzarDefensywny()
                    {
                        KosztMany = 200,
                        Ladowanie = 2,
                        Nazwa = "Fasdaire",
                        Obrona = 20
                    }
                }
            });

            gildiaMagow.Zatrudnij(new Mag()
            {
                Imie = "Ga",
                Inteligencja = 5,
                OdpornoscNaObrazeniaFizyczne = 1,
                OdpornoscNaObrazeniaMrozu = 2,
                OdpornoscNaObrazeniaOgnia = 3,
                OdpornoscNaObrazeniaTrucizny = 2,
                Poziom = 2,
                PunktyDoswiadczenia = 3,
                PunktyManyAktualne = 20,
                PunktyManyBazowe = 20,
                PunktyZyciaAktualne = 20,
                PunktyZyciaBazowe = 20,
                Sila = 2,
                ZadawaneObrazenia = 20,
                Zrecznosc = 2,
                KsiegaCzarowList = new KsiegaCzarowList()
                {
                    new CzarDefensywny()
                    {
                        KosztMany = 200,
                        Ladowanie = 2,
                        Nazwa = "Firsade",
                        Obrona = 20
                    },
                    new CzaryOfensywne()
                    {
                        KosztMany = 300,
                        Ladowanie = 1,
                        Nazwa = "Osldasdona",
                        Obrazenia = 20
                    }
                }
            });


            Console.Read();
        }
    }

    public delegate bool Where(Mag mag);
    public delegate bool OrderBy(Mag mag);

    public static class T
    {
        public static void A(this GildiaMagow gildiaMagow)
        {
            IEnumerable mags = from g in gildiaMagow.Mags where g.Sila > 10 orderby g.Sila select g;

            foreach (var item in mags)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void B(this GildiaMagow gildiaMagow)
        {
            IEnumerable mags = gildiaMagow.Mags.Where(g => g.Sila > 10).OrderBy(g => g.Sila);

            foreach (var item in mags)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void C(this GildiaMagow gildiaMagow)
        {
            var mags = Enumerable.Where(gildiaMagow.Mags, g => g.Sila > 10).OrderBy(g => g.Sila);

            foreach (var item in mags)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void D(this GildiaMagow gildiaMagow)
        {
            var mags = gildiaMagow.Mags.Where(delegate(Mag item) { return item.Sila > 1; }).OrderByDescending(delegate(Mag mag) { return mag.Sila; });

            foreach (var item in mags)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void E(this GildiaMagow gildiaMagow, Func<Mag, bool> where, Func<Mag, int> orderBy)
        {
            var mags = gildiaMagow.Mags.Where(where).OrderByDescending(orderBy);

            foreach (var item in mags)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void F(this GildiaMagow gildiaMagow)
        {
            List<Mag> mags = new List<Mag>();
            foreach (var item in gildiaMagow.Mags)
            {
                if (item.Sila > 1)
                {
                    mags.Add(item);
                }
            }

            mags.Sort(new CompareSila());

            foreach (var item in mags)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    public class CompareSila : IComparer<Mag>
    {
        public int Compare(Mag x, Mag y)
        {
            if (x.Sila == y.Sila)
            {
                return 0;
            }

            if (x.Sila > y.Sila)
            {
                return -1;
            } else
            {
                return 1 ;
            }
        }
    }
}
