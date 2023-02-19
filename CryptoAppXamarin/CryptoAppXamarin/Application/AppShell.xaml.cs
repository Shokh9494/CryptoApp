
using Autofac;
using CryptoAppXamarin.Models.Wallet;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CryptoAppXamarin
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            BindingContext = App.Container.Resolve<AppShellViewModel>();
        }

    }
}
