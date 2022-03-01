using NvrOrganizer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NvrOrganizer.UI.Data
{
    public interface INvrLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetNvrLookupAsync();
    }
}