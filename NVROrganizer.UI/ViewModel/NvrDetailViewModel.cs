using NvrOrganizer.Model;
using NvrOrganizer.UI.Data;
using NvrOrganizer.UI.Event;
using Prism.Events;
using System.Threading.Tasks;
using System;
using System.Windows.Input;
using Prism.Commands;
using NvrOrganizer.UI.Wrapper;
using NvrOrganizer.UI.Data.Repositories;

namespace NvrOrganizer.UI.ViewModel
{
    public class NvrDetailViewModel : ViewModelBase, INvrDetailViewModel
    {
        private INvrRepository _nvrRepository;
        private IEventAggregator _eventAggregator;
        private NvrWrapper _nvr;

        public NvrDetailViewModel(INvrRepository nvrRepository, 
            IEventAggregator eventAggregator)
        {
            _nvrRepository = nvrRepository;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenNvrDetailViewEvent>()
                .Subscribe(OnOpenNvrDetailView);

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute); 
         }

        public async Task LoadAsync(int nvrId)
        {
            var nvr = await _nvrRepository.GetByIdAsync(nvrId);

            Nvr = new NvrWrapper(nvr);
            Nvr.PropertyChanged += (s, e) =>
              {
                if(e.PropertyName == nameof(Nvr.HasErrors))
                  {
                      ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                  }
              };
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        public NvrWrapper Nvr
        {
            get { return _nvr; }
            private set
            {
                _nvr = value;
                OnPropertyChanged();
            }

        }

        public ICommand SaveCommand { get; }

        private bool OnSaveCanExecute()
        {
            //ToDo: Check in addition if Nvr has changes
            return Nvr!=null && !Nvr.HasErrors;
        }

        private async void OnSaveExecute()
        {
          await _nvrRepository.SaveAsync();
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

       
    }
}
