using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Studbud
{
    public class OnPageAppearingBehavior : Behavior<ContentPage>
    {
        public ICommand Command { get; set; }
        public object CommandParameter { get; set; }
        protected override void OnAttachedTo(ContentPage bindable)
        {
            bindable.Appearing += Bindable_Appearing;
            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            bindable.Appearing -= Bindable_Appearing;
            base.OnDetachingFrom(bindable);
        }
        private void Bindable_Appearing(object sender, EventArgs e)
        {
            Command.Execute(CommandParameter);
        }
    }
}
