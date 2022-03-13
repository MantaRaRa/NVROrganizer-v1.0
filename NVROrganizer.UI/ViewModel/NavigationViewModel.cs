using NvrOrganizer.Model;
using NvrOrganizer.UI.Data;
using NvrOrganizer.UI.Data.Lookups;
using NvrOrganizer.UI.Event;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace NvrOrganizer.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private INvrLookupDataService _nvrLookupService;
        private IEventAggregator _eventAggregator;

        public NavigationViewModel(INvrLookupDataService nvrLookupService,
            IEventAggregator eventAggregator)
        {
            _nvrLookupService = nvrLookupService;
            _eventAggregator = eventAggregator;
            Nvrs = new ObservableCollection<NavigationItemViewModel>();
            _eventAggregator.GetEvent<AfterNvrSavedEvent>().Subscribe(AfterNvrSaved);
        }

        private void AfterNvrSaved(AfterNvrSavedEventArgs obj)
        {
            var lookupItem = Nvrs.Single(l => l.Id == obj.Id);
            lookupItem.DisplayMember = obj.DisplayMember;
        }

        public async Task LoadAsync()
        {
            var lookup = await _nvrLookupService.GetNvrLookupAsync();
            Nvrs.Clear();
            foreach (var item in lookup)
            {
                Nvrs.Add(new NavigationItemViewModel(item.Id,item.DisplayMember));
            }
        }
        public ObservableCollection<NavigationItemViewModel> Nvrs { get; }

        private NavigationItemViewModel _selectedNvr;

        public NavigationItemViewModel SelectedNvr
        {
            get { return _selectedNvr; }
            set 
            { 
                _selectedNvr = value;
                OnPropertyChanged();
                if(_selectedNvr!= null)
                {
                    _eventAggregator.GetEvent<OpenNvrDetailViewEvent>()
                        .Publish(_selectedNvr.Id);
                }
            }
        }
        
    }
}
