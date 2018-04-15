using System.Collections.Generic;

namespace LinqSimplee
{
    public abstract class Czar
    {
        public string Nazwa { get; set; }
        public int KosztMany { get; set; }
        public int Ladowanie { get; set; }

        public override bool Equals(object obj)
        {
            var czar = obj as Czar;

            return czar != null &&
                   Nazwa == czar.Nazwa;
        }

        public override int GetHashCode()
        {
            var hashCode = 1641480444;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nazwa);

            return hashCode;
        }

        public override string ToString()
        {
            return $"{Nazwa}, {KosztMany}, {Ladowanie}";
        }
    }
}
