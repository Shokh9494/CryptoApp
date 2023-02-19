
using Autofac;
using CryptoAppXamarin.Models.Wallet;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using IContainer = Autofac.IContainer;

namespace CryptoAppXamarin
{
    public partial class App : Application
    {
        public static IContainer Container;

        public App()
        {
            InitializeComponent();
            //class used for registration
            var builder = new ContainerBuilder();
            //scan and register all classes in the assembly
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                   .AsImplementedInterfaces()
                   .AsSelf();
            //TODO - register repositories if you use them
            //builder.RegisterType<Repository<User>>().As<IRepository<User>>();

            //get container
            Container = builder.Build();
            //set first page
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
