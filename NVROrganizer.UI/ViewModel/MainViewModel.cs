using NvrOrganizer.Model;
using NvrOrganizer.UI.Data;
using System.Collections.ObjectModel;

namespace NvrOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private INvrDataSevice _nvrDataService;
        private Nvr _selectedNvr;

        public MainViewModel(INvrDataSevice nvrDataService)
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
            {
                _selectedNvr = value;
                OnPropertyChanged();
            }
        }
                    
    }
}
