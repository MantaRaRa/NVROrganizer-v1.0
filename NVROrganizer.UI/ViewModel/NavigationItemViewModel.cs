using NvrOrganizer.UI.Event;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NvrOrganizer.UI.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displayMember;

        public NavigationItemViewModel(int id, string displayMember,
            IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Id = id;
            DisplayMember = displayMember;
            OpenNvrDetailViewCommand = new DelegateCommand(OnOpenNvrDetailView);
        }

        private IEventAggregator _eventAggregator;

        public int Id { get; }

        public string DisplayMember
        {
            get { return _displayMember; }
            set
            {
                _displayMember = value;
                OnPropertyChanged();

            }
        }

        public ICommand OpenNvrDetailViewCommand { get; }

        private void OnOpenNvrDetailView()
        {
            _eventAggregator.GetEvent<OpenNvrDetailViewEvent>()
                       .Publish(Id);
        }

    }
}
