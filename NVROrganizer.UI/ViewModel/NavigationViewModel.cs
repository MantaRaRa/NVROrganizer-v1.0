using NvrOrganizer.Model;
using NvrOrganizer.UI.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NvrOrganizer.UI.ViewModel
{
    public class NavigationViewModel : INavigationViewModel
    {
        private INvrLookupDataService _nvrLookupServices;

        public NavigationViewModel(INvrLookupDataService nvrLookupServices)

        {
            _nvrLookupServices = nvrLookupServices;
            Nvrs = new ObservableCollection<LookupItem>();
        }

        public async Task LoadAsync()
        {
            var lookup = await _nvrLookupServices.GetNvrLookupAsync();
            Nvrs.Clear();
            foreach (var item in lookup)
            {
                Nvrs.Add(item);
            }
        }
        public ObservableCollection<LookupItem> Nvrs { get; }
    }
}
