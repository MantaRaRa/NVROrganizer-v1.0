using NvrOrganizer.Model;
using System.Collections.Generic;

namespace NvrOrganizer.UI.Data
{
    public interface INvrDataSevice
    {
        IEnumerable<Nvr> GetAll();
    }
}