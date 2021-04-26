using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Staffisher
{
    public partial class App : Application
    {
        public static Classes.Angler User { get; set; }
        
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Pages.LoginPage());
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
