using NvrOrganizer.Model;
using NvrOrganizer.UI.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NvrOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(INavigationViewModel navigationViewModel)
        {
          NavigationViewModel = navigationViewModel;
        }

        public async Task LoadAsync()
        {
         await NavigationViewModel.LoadAsync();
        }

        public INavigationViewModel NavigationViewModel { get; }            
    }
}
