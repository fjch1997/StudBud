using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Studbud.Transactions
{
    class NewTransactionViewModel
    {
        public class CodeButtonClickPage : ContentPage
        { 
        {
            public CodeButtonClickPage()
            {
                Title = "Add";

                Label label = new Label
                {
                    Text = "New Transaction",
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.Center
                };

                Button button = new Button
                {
                    Text = "Add Transaction",
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.Center
                };
                button.Clicked += async (sender, args) => await label.RelRotateTo(360, 1000);

                Content = new StackLayout
                {
                    Children =
            {
                label,
                button
            }
                };
                button.Clicked += async (sender, args) => await label.RelRotateTo(360, 1000);
            }
        }
        public int Price { get; set; }
        public string ItemName { get; set; }
        public DateTime
    }
}
