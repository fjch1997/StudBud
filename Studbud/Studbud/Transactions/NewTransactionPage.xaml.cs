using Studbud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Studbud.Transactions
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTransactionPage : ContentPage
	{
		public NewTransactionPage (Transaction transaction = null)
		{
			InitializeComponent ();
            if(transaction != null)
            {
                var vm = BindingContext as NewTransactionPageViewModel;
                vm.Name = transaction.Name;
                vm.Merchant = transaction.Merchant;
                vm.Amount = transaction.Amount;
                vm.Catagory = transaction.Catagory;
                vm.Date = transaction.DateTimeUtc.ToLocalTime().Date;
                vm.Time = transaction.DateTimeUtc.ToLocalTime().TimeOfDay;
                vm.Transaction = transaction;
            }
		}
	}
}