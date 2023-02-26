using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CryptoAppXamarin.Models.Wallet
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WalletPage : ContentPage
	{
		public WalletPage ()
		{
			InitializeComponent ();
			BindingContext=App.Container.Resolve<WalletViewModel> ();
		}
        protected override  void OnAppearing()
        {
            base.OnAppearing();
			(BindingContext as WalletViewModel).InitializeAsync(null);
        }
    }
}