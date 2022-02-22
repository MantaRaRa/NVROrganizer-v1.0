using NvrOrganizer.Model;
using System.Collections.Generic;

namespace NvrOrganizer.UI.Data
{
    public class NvrDataSevice : INvrDataSevice
    {
        public IEnumerable<Nvr> GetAll()
        {
            // ToDo: Load data from real DataBase
            yield return new Nvr { FirstName = "GoTime4", LastName = "Winchester" };
            yield return new Nvr { FirstName = "DoubleKwik", LastName = "Isom" };
            yield return new Nvr { FirstName = "HT", LastName = "Hackney" };
            yield return new Nvr { FirstName = "PCCEK", LastName = "Vicco 2" };
        }
    }
}
