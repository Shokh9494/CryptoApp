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
	public partial class WithdrawTransActionPage : ContentPage
	{
		public WithdrawTransActionPage ()
		{
			InitializeComponent ();
		}
	}
}