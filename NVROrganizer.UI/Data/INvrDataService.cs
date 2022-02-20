using NVROrganizer.Model;
using System.Collections.Generic;

namespace NVROrganizer.UI.Data
{
    public interface INvrDataService
    {
        IEnumerable<Nvr> GetAll();
    }
}