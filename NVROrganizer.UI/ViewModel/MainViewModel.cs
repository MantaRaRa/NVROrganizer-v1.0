using NVROrganizer.Model;
using NVROrganizer.UI.Data;
using System.Collections.ObjectModel;

namespace NVROrganizer.UI.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        private INvrDataService _nvrDataService;
        private Nvr _selectedNvr;
                
        public MainViewModel(INvrDataService nvrDataService)
        {
            Nvrs = new ObservableCollection<Nvr>();
            _nvrDataService = nvrDataService;
        }

        public void Load()
        {
            var nvrs = _nvrDataService.GetAll();
            Nvrs.Clear();
            foreach (var nvr in nvrs)
            {
                Nvrs.Add(nvr);
            }
        }

        public ObservableCollection<Nvr> Nvrs { get; set; }
                
        public Nvr SelectedNvr
        {
            get { return _selectedNvr; }
            set 
            { _selectedNvr = value;
            OnPropertyChanged();
            }
            
        }

        
    }
}
