using Microcharts.Forms;
using Studbud.External;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microcharts;

namespace Studbud.Statistics
{
    public class StatisticsHomePageViewModel : INotifyPropertyChanged
    {
        public INavigationService NavigationSerive { get; set; }

        public ICommand OpenTimelineCommand { get; set; }
        public ChartView ChartView { get; set; }
        public StatisticsHomePageViewModel()
        {
            OpenTimelineCommand = new DelegateCommand(() =>
            {
                NavigationSerive.PushAsync(new TimelinePage());
            });
        }
        private void InitializeChart()
        {
            ChartView.Chart = new BarChart(); // TODO: This should be a pie chart here. See Microchart's documentation to find what to call.
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
