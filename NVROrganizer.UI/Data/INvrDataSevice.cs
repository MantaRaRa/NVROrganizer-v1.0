using NvrOrganizer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NvrOrganizer.UI.Data
{
    public interface INvrDataSevice
    {
        Task<Nvr> GetByIdAsync(int nvrId);
        Task SaveAsync(Nvr nvr);
    }
}