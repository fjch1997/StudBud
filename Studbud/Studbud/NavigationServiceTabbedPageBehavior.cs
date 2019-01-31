using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Studbud
{
    public class NavigationServiceTabbedPageBehavior : Behavior<TabbedPage>
    {
        public NavigationService NavigationService { get; set; }
        private TabbedPage associatedObjetct;
        protected override void OnAttachedTo(TabbedPage bindable)
        {
            associatedObjetct = bindable;
            NavigationService.NavigationPage = (NavigationPage)bindable.CurrentPage;
            bindable.CurrentPageChanged += Bindable_CurrentPageChanged;
            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom(TabbedPage bindable)
        {
            associatedObjetct = null;
            bindable.CurrentPageChanged -= Bindable_CurrentPageChanged;
            base.OnDetachingFrom(bindable);
        }
        private void Bindable_CurrentPageChanged(object sender, EventArgs e)
        {
            NavigationService.NavigationPage = (NavigationPage) associatedObjetct.CurrentPage;
        }
    }
}
