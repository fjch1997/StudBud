
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Studbud.Statistics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimelinePage : ContentPage
    {
        public TimelinePage()
        {
            InitializeComponent();
            ((TimelinePageViewModel)BindingContext).EndInit();
        }
    }
}