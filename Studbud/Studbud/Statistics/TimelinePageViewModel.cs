using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using Studbud.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Studbud.Statistics
{
    public class TimelinePageViewModel : INotifyPropertyChanged, ISupportInitialize
    {
        public TimelinePageViewModel()
        {
            YearValues = Enumerable.Range(DateTime.Now.Year - 10, 11);
        }
        public ChartView ChartView { get; set; }
        public ITransactionStorageService TransactionStorageService { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public IEnumerable<int> YearValues { get; set; }
        public int SelectedYear { get => selectedYear; set { selectedYear = value; OnPropertyChanged(); } }
        private int selectedYear = DateTime.Now.Year;
        public void BeginInit()
        {

        }
        private void InitializeChart()
        {
            DateTime startTime;
            if (selectedYear == DateTime.Now.Year)
                startTime = DateTime.Now.AddMonths(-11);
            else
                startTime = new DateTime(SelectedYear, 1, 1);
            var colors = new Stack<string>(new[] { "#e6194b", "#3cb44b", "#ffe119", "#4363d8", "#f58231", "#911eb4", "#46f0f0", "#f032e6", "#bcf60c", "#fabebe", "#008080", "#e6beff", "#9a6324", "#fffac8", "#800000", "#aaffc3", "#808000", "#ffd8b1", "#000075", "#808080", "#ffffff", "#000000" });
            var entries = Enumerable.Range(0, 12)
                .Select(i => startTime.AddMonths(i))
                .Select(time => (transactions: TransactionStorageService.GetTransactions(new DateTime(time.Year, time.Month, 1), new DateTime(time.Year, time.Month, 1).AddMonths(1)), month: time.Month))
                .Select(t => new Entry((float)t.transactions.Sum(e => e.Amount))
                {
                    ValueLabel = t.transactions.Sum(e => e.Amount).ToString("C"),
                    Color = SKColor.Parse(colors.Pop()),
                    Label = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(t.month),
                }).ToArray();
            ChartView.Chart = new PointChart() { Entries = entries, LabelTextSize = 8, };
        }
        public void EndInit()
        {
            InitializeChart();
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
