using System.Collections.Generic;
using System.Linq;

namespace LinqSimplee
{
    public delegate Mag AddEvent(Mag mag);
    public delegate Mag RemoveEvent(Mag mag);

    public partial class GildiaMagow
    {
        public event RemoveEvent RemoveEvent;
        public event AddEvent AddEvent;

        public List<Mag> Mags { get; set; } = new List<Mag>();

        public void Zatrudnij(Mag mag)
        {
            if (Mags.Where(m => m.Imie.Contains(mag.Imie)).Count() > 0)
            {
                throw new DuplikatException("Pruba dodania Maga o tym samym imieniu");
            }

            if (AddEvent != null)
            {
                Mags.Add(AddEvent(mag));

                return;
            }

            Mags.Add(mag);
        }

        public bool UsunPoImieniu(string imie)
        {
            var mags = Mags
                .Where(m => m.Imie == imie)
                .FirstOrDefault();

            if (Mags.Any(m => m.Imie == imie))
            {
                throw new DuplikatException("Występuje więcej magów o podanym imieniu");
            }

            if (mags == null)
            {
                throw new NotFoundException("Nie znaleziono maga");
            }

            if (AddEvent != null)
            {
                return Mags.Remove(RemoveEvent(mags));
            }

            return Mags.Remove(mags);
        }
    }
}
