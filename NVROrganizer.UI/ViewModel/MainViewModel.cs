using NvrOrganizer.UI.Event;
using NvrOrganizer.UI.View.Services;
using Prism.Commands;
using Prism.Events;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NvrOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private Func<INvrDetailViewModel> _nvrDetailViewModelCreator;
        private IMessageDialogService _messageDialogService;
        private INvrDetailViewModel _nvrDetailViewModel;

        public MainViewModel(INavigationViewModel navigationViewModel,
            Func<INvrDetailViewModel> nvrDetailViewModelCreator,
            IEventAggregator eventAggregator,
            IMessageDialogService messageDialogService)
        {
            _eventAggregator = eventAggregator;
            _nvrDetailViewModelCreator = nvrDetailViewModelCreator;
            _messageDialogService = messageDialogService;

            _eventAggregator.GetEvent<OpenNvrDetailViewEvent>()
               .Subscribe(OnOpenNvrDetailView);
            _eventAggregator.GetEvent<AfterNvrDeleteEvent>()
                .Subscribe(AfterNvrDeleted);

            CreateNewNvrCommand = new DelegateCommand(OnCreateNewNvrExecute);

            NavigationViewModel = navigationViewModel;
        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }
        public ICommand CreateNewNvrCommand { get; }
                
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


        private async void OnOpenNvrDetailView(int? nvrId)
        {
            if(NvrDetailViewModel!=null && NvrDetailViewModel.HasChanges)
            {
                var result = _messageDialogService.ShowOKCancelDialog("Changes have not been Saved, Navigate away?", "Warning");
                   
                if(result == MessageDialogResult.Cancel)
                {
                  return;
                }
            }
            NvrDetailViewModel=_nvrDetailViewModelCreator();
            await NvrDetailViewModel.LoadAsync(nvrId);
        }

        private void OnCreateNewNvrExecute()
        {
            OnOpenNvrDetailView(null);
        }

        private void AfterNvrDeleted(int nvrId)
        {
           NvrDetailViewModel = null;
        }

    }
}
