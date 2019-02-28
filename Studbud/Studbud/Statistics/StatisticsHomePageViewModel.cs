using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using Studbud.Data;
using Studbud.External;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Studbud.Statistics
{
    public class StatisticsHomePageViewModel : INotifyPropertyChanged, ISupportInitialize
    {
        public INavigationService NavigationSerive { get; set; }
        public ITransactionStorageService TransactionStorageService { get; set; }
        public ICommand OpenTimelineCommand { get; set; }
        public ChartView ChartView { get; set; }
        public TimeRange[] TimeRangeValues { get; set; } = new TimeRange[] { TimeRange.Day, TimeRange.Week, TimeRange.Month, TimeRange.Year };
        public TimeRange SelectedTimeRange { get => selectedTimeRange; set { selectedTimeRange = value; OnPropertyChanged(); InitializeChart(); } }
        private TimeRange selectedTimeRange;
        public StatisticsHomePageViewModel()
        {
            OpenTimelineCommand = new DelegateCommand(() =>
            {
                NavigationSerive.PushAsync(new TimelinePage());
            });
        }
        private void InitializeChart()
        {
            DateTime startTime;
            switch (SelectedTimeRange)
            {
                case TimeRange.Day:
                    startTime = DateTime.Now.AddDays(-1);
                    break;
                case TimeRange.Week:
                    startTime = DateTime.Now.AddDays(-7);
                    break;
                case TimeRange.Month:
                    startTime = DateTime.Now.AddMonths(-1);
                    break;
                case TimeRange.Year:
                    startTime = DateTime.Now.AddYears(-1);
                    break;
                default:
                    throw new NotImplementedException();
            }
            var colors = new string[] { "#CCCC00", "#660000", "#006600", "#0066FF", "#000000", "#330099", "#993399", "#009999", "#FF0000" };
            var entries = TransactionStorageService.GetTransactions(startTime.ToUniversalTime(), DateTime.UtcNow)
                .GroupBy(t => t.Catagory, t => t.Amount)
                .Select(g => new Microcharts.Entry((float)g.Sum())
                {
                    Label = g.Key + g.Sum().ToString("C"),
                    Color = SKColor.Parse(colors[unchecked(((uint)g.Key.GetHashCode()) % colors.Length)]),
                });
            ChartView.Chart = new DonutChart() { Entries = entries };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void BeginInit()
        {
        }

        public void EndInit()
        {
            if (NavigationSerive == null) throw new ArgumentNullException(nameof(NavigationSerive));
            if (ChartView == null) throw new ArgumentNullException(nameof(ChartView));
            InitializeChart();
        }
    }
    public enum TimeRange
    {
        Day, Week, Month, Year
    }
}
