using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NvrOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(INavigationViewModel navigationViewModel,
            INvrDetailViewModel nvrDetailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            NvrDetailViewModel = nvrDetailViewModel;
        }
        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }
        public INavigationViewModel NavigationViewModel { get; }

        public INvrDetailViewModel NvrDetailViewModel { get; }
    }
}
