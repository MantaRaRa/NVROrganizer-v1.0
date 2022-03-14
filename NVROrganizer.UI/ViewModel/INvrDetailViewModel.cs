using System.Threading.Tasks;

namespace NvrOrganizer.UI.ViewModel
{
    public interface INvrDetailViewModel
    {
        Task LoadAsync(int nvrId);
        bool HasChanges { get; }
    }
}