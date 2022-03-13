using NvrOrganizer.UI.Event;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NvrOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private Func<INvrDetailViewModel> _nvrDetailViewModelCreator;
        private INvrDetailViewModel _nvrDetailViewModel;

        public MainViewModel(INavigationViewModel navigationViewModel,
            Func<INvrDetailViewModel> nvrDetailViewModelCreator,
            IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _nvrDetailViewModelCreator = nvrDetailViewModelCreator;

            _eventAggregator.GetEvent<OpenNvrDetailViewEvent>()
               .Subscribe(OnOpenNvrDetailView);

            NavigationViewModel = navigationViewModel;
        }
        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }
                
        public INavigationViewModel NavigationViewModel { get; }
                
        public INvrDetailViewModel NvrDetailViewModel
        {
            get { return _nvrDetailViewModel; }
            private set 
            { 
                _nvrDetailViewModel = value;
                OnPropertyChanged();
            }
        }


        private async void OnOpenNvrDetailView(int nvrId)
        {
            NvrDetailViewModel=_nvrDetailViewModelCreator();
            await NvrDetailViewModel.LoadAsync(nvrId);
        }
    }
}
