using NvrOrganizer.Model;
using NvrOrganizer.UI.Data;
using NvrOrganizer.UI.Event;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
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
            Nvrs = new ObservableCollection<LookupItem>();
        }

        public async Task LoadAsync()
        {
            var lookup = await _nvrLookupService.GetNvrLookupAsync();
            Nvrs.Clear();
            foreach (var item in lookup)
            {
                Nvrs.Add(item);
            }
        }
        public ObservableCollection<LookupItem> Nvrs { get; }

        private LookupItem _selectedNvr;

        public LookupItem SelectedNvr
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
