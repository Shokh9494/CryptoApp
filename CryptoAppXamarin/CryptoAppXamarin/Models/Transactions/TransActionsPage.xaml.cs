using Autofac;
using CryptoAppXamarin.Models.AddTransaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CryptoAppXamarin.Models.Transactions
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TransActionsPage : ContentPage
	{
		public TransActionsPage ()
		{
			InitializeComponent ();
			BindingContext = App.Container.Resolve<TransactionViewModel>();
		}
        protected override async void OnAppearing()
        {
            base.OnAppearing();
			await (BindingContext as TransactionViewModel).InitializeAsync(null);
        }
    }
}