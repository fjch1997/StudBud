using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using Studbud.Data;
using Studbud.External;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Studbud.Statistics
{
    public class StatisticsHomePageViewModel : INotifyPropertyChanged, ISupportInitialize
    {
        public INavigationService NavigationSerive { get; set; }
        public ITransactionStorageService TransactionStorageService { get; set; }
        public ICommand OpenTimelineCommand { get; set; }
        public ChartView CatagoryChartView { get; set; }
        public ChartView MerchantChartView { get; set; }
        public TimeRange[] TimeRangeValues { get; set; } = new TimeRange[] { TimeRange.Day, TimeRange.Week, TimeRange.Month, TimeRange.Year };
        public TimeRange SelectedTimeRange { get => selectedTimeRange; set { selectedTimeRange = value; OnPropertyChanged(); InitializeCharts(); } }
        private TimeRange selectedTimeRange = TimeRange.Week;
        public StatisticsHomePageViewModel()
        {
            OpenTimelineCommand = new DelegateCommand(() =>
            {
                NavigationSerive.PushAsync(new TimelinePage());
            });
        }
        private void InitializeCharts()
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
            var colors = new List<string> { "#e6194b", "#3cb44b", "#c4ad13", "#4363d8", "#f58231", "#911eb4", "#f032e6", "#bcf60c", "#fabebe", "#008080", "#e6beff", "#9a6324", "#800000", "#aaffc3", "#808000", "#ffd8b1", "#000075", "#808080", "#ffffff", "#000000" };
            var colorsUnique = new List<string> { "#e6194b", "#3cb44b", "#c4ad13", "#4363d8", "#f58231", "#911eb4", "#f032e6", "#bcf60c", "#fabebe", "#008080", "#e6beff", "#9a6324", "#800000", "#aaffc3", "#808000", "#ffd8b1", "#000075", "#808080", "#ffffff", "#000000" };
            string GetColor(string key)
            {
                if (colorsUnique.Count > 0)
                {
                    var index = (int)unchecked((uint)key.GetHashCode() % colorsUnique.Count);
                    var color = colorsUnique[index];
                    colorsUnique.RemoveAt(index);
                    return color;
                }
                else
                {
                    return colors[(int)unchecked((uint)key.GetHashCode() % colors.Count)];
                }
            }
            Func<IGrouping<string, decimal>, Entry> getEntry =
                 g => new Entry((float)g.Sum())
                 {
                     Label = g.Key ?? "",
                     Color = SKColor.Parse(GetColor(g.Key ?? "")),
                     ValueLabel = g.Sum().ToString("C"),
                 };

            var transactions = TransactionStorageService.GetTransactions(startTime.ToUniversalTime(), DateTime.UtcNow);
            var entries = transactions.GroupBy(t => t.Catagory, t => t.Amount).Select(getEntry).ToArray();
            CatagoryChartView.Chart = new DonutChart { Entries = entries };
            entries = transactions.GroupBy(t => t.Merchant, t => t.Amount).Select(getEntry).ToArray();
            MerchantChartView.Chart = new DonutChart { Entries = entries };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public void BeginInit()
        {
        }
        public void EndInit()
        {
            if (NavigationSerive == null) throw new ArgumentNullException(nameof(NavigationSerive));
            if (CatagoryChartView == null) throw new ArgumentNullException(nameof(CatagoryChartView));
            InitializeCharts();
        }
    }
    public enum TimeRange
    {
        Day, Week, Month, Year
    }
}
