using CreateAccountPage_ex4.Services;
using CreateAccountPage_ex4.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CreateAccountPage_ex4
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<ICreateAccountService, CreateAccountService>();
            MainPage = new  NavigationPage( new CreateAccountPage());
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
