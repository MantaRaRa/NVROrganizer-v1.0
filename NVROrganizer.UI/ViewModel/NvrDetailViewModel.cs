using NvrOrganizer.Model;
using NvrOrganizer.UI.Data;
using NvrOrganizer.UI.Event;
using Prism.Events;
using System.Threading.Tasks;
using System;
using System.Windows.Input;
using Prism.Commands;

namespace NvrOrganizer.UI.ViewModel
{
    public class NvrDetailViewModel : ViewModelBase, INvrDetailViewModel
    {
        private INvrDataSevice _dataService;
        private IEventAggregator _eventAggregator;

        public NvrDetailViewModel(INvrDataSevice dataService, 
            IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenNvrDetailViewEvent>()
                .Subscribe(OnOpenNvrDetailView);

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute); 
         }

        private bool OnSaveCanExecute()
        {
            //ToDo: Check if Nvr is Valid
            return true;
        }

        private async void OnSaveExecute()
        {
          await _dataService.SaveAsync(Nvr);
            _eventAggregator.GetEvent<AfterNvrSavedEvent>().Publish(
                new AfterNvrSavedEventArgs
                {
                    Id = Nvr.Id,
                    DisplayMember = $"{Nvr.FirstName} {Nvr.LastName}"
                });
        }

        private async void OnOpenNvrDetailView(int nvrId)
        {
           await LoadAsync(nvrId);
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
        public ICommand SaveCommand { get;}
    }
}
