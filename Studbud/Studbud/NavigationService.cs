using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Studbud
{
    public class NavigationService : INavigationService, ISupportInitialize
    {
        public NavigationPage NavigationPage { get; set; }

        public void BeginInit() { }
        public void EndInit()
        {
            if (NavigationPage == null) throw new ArgumentNullException(nameof(NavigationPage));

        }

        public Task<Page> PopAsync() => NavigationPage.PopAsync();
        public Task<Page> PopAsync(bool animated) => NavigationPage.PopAsync(animated);
        public Task PopToRootAsync() => NavigationPage.PopToRootAsync();
        public Task PopToRootAsync(bool animated) => NavigationPage.PopToRootAsync(animated);

        public Task PushAsync(Page page) => NavigationPage.PushAsync(page);
        public Task PushAsync(Page page, bool animated) => NavigationPage.PushAsync(page, animated);
    }
    public interface INavigationService
    {
        Task PushAsync(Page page);
        Task PushAsync(Page page, bool animated);
        Task<Page> PopAsync();
        Task<Page> PopAsync(bool animated);
        Task PopToRootAsync();
        Task PopToRootAsync(bool animated);
    }
}
