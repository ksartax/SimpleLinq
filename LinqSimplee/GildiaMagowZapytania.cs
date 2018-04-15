using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqSimplee
{
    public partial class GildiaMagow
    {
        public void Lista()
        {
            var mags = Mags
                .OrderBy(m => m.Imie);

            foreach (var item in mags)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void ListaPoPoziomiePosortowana(int poziom)
        {
            var mags = Mags
                .Where(m => m.Poziom > poziom)
                .OrderBy(m => m.Poziom);

            foreach (var item in mags)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void ListaPoMniejszymPoziomieIInteligencjWiekszejNiz20(int poziom)
        {
            var mags = Mags
                .Where(
                    m => m.Inteligencja >= 20 
                    && m.Poziom <= poziom
                )
                .OrderByDescending(m => m.Poziom);

            foreach (var item in mags)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void IloscMagowOPotencjale()
        {
            var magsCount = Mags
                .Where(
                    m => m.Poziom > 2 
                    && m.Zrecznosc > 10
                )
                .Sum(m => m.PunktyManyBazowe);

            Console.WriteLine(magsCount);
        }

        public void ListaMagowPoIlosciCzarow(int czarCount)
        {
            var mags = Mags
                .Where(m => m.KsiegaCzarowList.Count > czarCount)
                .Select(
                    num => new {
                        num.Imie,
                        num.KsiegaCzarowList.Count,
                        num.PunktyManyBazowe
                    }
                )
                .OrderByDescending(m => m.Imie);

            foreach (var item in mags)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void ListaWszechstronnychMagow()
        {
            var mags = Mags
                .Select(
                    num => new {
                        num.Imie,
                        num.Poziom,
                        sredniaZrecznosc = num.Zrecznosc / Mags.Sum(m => m.Zrecznosc),
                        sredniaSila = num.Sila / Mags.Sum(m => m.Sila),
                        sredniaInteligencja = num.Inteligencja / Mags.Sum(m => m.Inteligencja)
                    }
                )
                .OrderByDescending(m => m.sredniaSila);

            foreach (var item in mags)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void ListaMagowONajwiekszejLiczbieCzarow()
        {
            var mags = Mags
                .Where(
                    m => m.KsiegaCzarowList.Count == Mags.Max(p => p.KsiegaCzarowList.Count)
                );

            foreach (var item in mags)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void ListaCzarowMagow()
        {
            var mags = Mags
                .SelectMany(
                    p => p.KsiegaCzarowList
                );

            foreach (var item in mags)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void ListaCzarowPoTypie(string typ)
        {
            List<Czar> list = null;
            list = Mags
                    .SelectMany((num) => num.KsiegaCzarowList
                        .Where(p => p.GetType().Name.Contains(typ)).Distinct()
                    )
                    .ToList();

            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void ListaCzarowPoImieniuMaga(string name)
        {
            var mags = Mags
                .Where(m => m.Imie.Contains(name))
                .Select((num) => num.KsiegaCzarowList)
                .Single();

            foreach (var item in mags)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void ListaIloscCzarowKazdegoTypu()
        {
            var mags = Mags
                .SelectMany(
                    p => p.KsiegaCzarowList
                        .Distinct()
                        .GroupBy(a => a.GetType().Name)
                        .Select((i) => new {
                            ilosc = i.Count(),
                            nazwa = i.First().GetType().Name
                        })
                );

            foreach (var item in mags)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void ListaIlosciCzarowTypowPoImieniuMaga(string name)
        {
            var mags = Mags
                .Single(p => p.Imie == name)
                    .KsiegaCzarowList
                    .Distinct()
                    .GroupBy(p => p.GetType().Name)
                    .Select((n) => new {
                        ilosc = n.Count(),
                        Nawa = n.First().GetType().Name
                    });

            foreach (var item in mags)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void ListaNajleprzychMagow()
        {
            var mags = Mags
                .OrderByDescending(a => a.Poziom)
                .ThenByDescending(a => a.PunktyDoswiadczenia)
                .Skip(1)
                .Take(2)
                .Select(p => new {
                    p.Imie,
                    p.Poziom
                });

            foreach (var item in mags)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void CzyMagowieSaGotowiDoWalki()
        {
            Console.WriteLine($"Czy gotowi : {Mags.All(p => p.PunktyZyciaAktualne == p.PunktyZyciaBazowe && p.PunktyManyBazowe == p.PunktyManyAktualne)}");
        }

        public void CzyMagowieUmarli()
        {
            Console.WriteLine($"Czy ded : {Mags.Any(p => p.PunktyManyAktualne == 0)}");
        }

        public void ListaMagowDoMisjiSpecjalnej()
        {
            var mags = Mags
                .Select((num) => new
                {
                    num.Imie,
                    num.Poziom,
                    num.OdpornoscNaObrazeniaFizyczne,
                    num.OdpornoscNaObrazeniaMrozu,
                    num.OdpornoscNaObrazeniaOgnia,
                    num.OdpornoscNaObrazeniaTrucizny,
                    sumaOdpornosci = num.GetSumOdpornosci()
                })
                .OrderByDescending(p => p.sumaOdpornosci).ThenByDescending(p => p.Poziom)
                .Take(3);

            foreach (var item in mags)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
