using Studbud.External;
using System.ComponentModel;
using System.Windows.Input;

namespace Studbud.Statistics
{
    public class StatisticsHomePageViewModel : INotifyPropertyChanged
    {
        public INavigationService NavigationSerive { get; set; }

        public ICommand OpenTimelineCommand { get; set; }
        public StatisticsHomePageViewModel()
        {
            OpenTimelineCommand = new DelegateCommand(() =>
            {
                NavigationSerive.PushAsync(new TimelinePage());
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
