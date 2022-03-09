using NvrOrganizer.Model;
using NvrOrganizer.UI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NvrOrganizer.UI.ViewModel
{
    public class NvrDetailViewModel : ViewModelBase, INvrDetailViewModel
    {
        private INvrDataSevice _dataService;

        public NvrDetailViewModel(INvrDataSevice dataService)
        {
            _dataService = dataService;
        }

        public async Task LoadAsync(int nvrId)
        {
            Nvr = await _dataService.GetByIdAsync(nvrId);
        }

        private Nvr _nvr;

        public Nvr Nvr
        {
            get { return _nvr; }
            private set
            {
                _nvr = value;
                OnPropertyChanged();
            }

        }
    }
}
