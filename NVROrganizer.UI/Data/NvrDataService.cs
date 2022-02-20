using NVROrganizer.Model;
using System.Collections.Generic;

namespace NVROrganizer.UI.Data
{
    public class NvrDataService : INvrDataService
    {
        public IEnumerable<Nvr> GetAll()
        {
            //TODO: Load data from database
            yield return new Nvr { FirstName = "Appalachian", LastName = "Smoke" };
            yield return new Nvr { FirstName = "Crater", LastName = "Pharmacy" };
            yield return new Nvr { FirstName = "DoubleKwik", LastName = "Isom" };
            yield return new Nvr { FirstName = "GoTime4", LastName = "Winchester" };
        }
    }
}
