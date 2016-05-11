using System.Collections.Generic;

namespace PotapanjeBrodova
{
    public interface IEliminatorPolja
    {
        IEnumerable<Polje> PoljaKojaTrebaUklonitiOkoBroda(IEnumerable<Polje> brodskaPolja, int redaka, int stupaca);
    }
}
