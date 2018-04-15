namespace LinqSimplee
{
    public class Mag
    {
        public string Imie { get; set; }
        public int Poziom { get; set; }
        public int PunktyDoswiadczenia { get; set; }
        public int Sila { get; set; }
        public int Zrecznosc { get; set; }
        public int Inteligencja { get; set; }
        public int PunktyZyciaAktualne { get; set; }
        public int PunktyZyciaBazowe { get; set; }
        public int PunktyManyAktualne { get; set; }
        public int PunktyManyBazowe { get; set; }
        public int ZadawaneObrazenia { get; set; }
        public int OdpornoscNaObrazeniaFizyczne { get; set; }
        public int OdpornoscNaObrazeniaOgnia { get; set; }
        public int OdpornoscNaObrazeniaMrozu { get; set; }
        public int OdpornoscNaObrazeniaTrucizny { get; set; }
        public KsiegaCzarowList KsiegaCzarowList { get; set; } = new KsiegaCzarowList();

        public int GetSumOdpornosci()
        {
            return OdpornoscNaObrazeniaFizyczne + OdpornoscNaObrazeniaMrozu + OdpornoscNaObrazeniaOgnia + OdpornoscNaObrazeniaTrucizny;
        }

        public override string ToString()
        {
            return $"{Imie}, " +
                $"{Poziom}, " +
                $"{PunktyDoswiadczenia}, " +
                $"{Sila}, " +
                $"{Zrecznosc}, " +
                $"{Inteligencja}, " +
                $"{PunktyZyciaAktualne}, " +
                $"{PunktyZyciaBazowe}, " +
                $"{PunktyManyAktualne}," +
                $"{PunktyManyBazowe}, " +
                $"{ZadawaneObrazenia}," +
                $"{OdpornoscNaObrazeniaFizyczne}," +
                $"{OdpornoscNaObrazeniaMrozu}, " +
                $"{OdpornoscNaObrazeniaOgnia}," +
                $"{OdpornoscNaObrazeniaTrucizny}," +
                $"{KsiegaCzarowList.ToString()}";
        }
    }
}
