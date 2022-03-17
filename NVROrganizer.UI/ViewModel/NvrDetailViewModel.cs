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
        private bool _hasChanges;

        public NvrDetailViewModel(INvrRepository nvrRepository, 
            IEventAggregator eventAggregator)
        {
            _nvrRepository = nvrRepository;
            _eventAggregator = eventAggregator;
           

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute); 
         }

        public async Task LoadAsync(int? nvrId)
        {
            var nvr =  nvrId.HasValue
               ? await _nvrRepository.GetByIdAsync(nvrId.Value)
               : CreateNewNvr();

            Nvr = new NvrWrapper(nvr);
            Nvr.PropertyChanged += (s, e) =>
              {
                  if (!HasChanges)
                  {
                      HasChanges = _nvrRepository.HasChanges();
                  }
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

        public bool HasChanges
        {
            get { return _hasChanges; }
            set
            {
                if (_hasChanges != value)
                {
                    _hasChanges = value;
                    OnPropertyChanged();
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            }
        }


        public ICommand SaveCommand { get; }

        private async void OnSaveExecute()
        {
          await _nvrRepository.SaveAsync();
            HasChanges = _nvrRepository.HasChanges();
            _eventAggregator.GetEvent<AfterNvrSavedEvent>().Publish(
                new AfterNvrSavedEventArgs
                {
                    Id = Nvr.Id,
                    DisplayMember = $"{Nvr.FirstName} {Nvr.LastName}"
                });
        }

        private bool OnSaveCanExecute()
        {
            return Nvr != null && !Nvr.HasErrors && HasChanges;
        }

        private Nvr CreateNewNvr()
        {
           var nvr = new Nvr();
            _nvrRepository.Add(nvr);
            return nvr;
        }

    }
}
