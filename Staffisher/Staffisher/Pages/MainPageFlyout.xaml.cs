using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Staffisher.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageFlyout : ContentPage
    {
        public ListView ListView;

        public MainPageFlyout()
        {
            InitializeComponent();

            usernameLabel.Text = "Signed In As:\n" + App.User.Username;

            BindingContext = new MainPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private async void OnLogOutClicked(object sender, EventArgs e)
        {
            bool logOut = await DisplayAlert("Log Out", "Are You Sure You Want To Log Out?", "Yes", "No");

            if (logOut)
            {
                App.User = null;
                Navigation.InsertPageBefore(new LoginPage(), Navigation.NavigationStack.ElementAt(0));
                await Navigation.PopAsync();
            }
        }

        class MainPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainPageFlyoutMenuItem> MenuItems { get; set; }

            public MainPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MainPageFlyoutMenuItem>(new[]
                {
                    new MainPageFlyoutMenuItem { Id = 0, Title = "Matches", TargetType = typeof(MatchesPage)},
                    new MainPageFlyoutMenuItem { Id = 1, Title = "Stats", TargetType = typeof(StatsPage)},
                    new MainPageFlyoutMenuItem { Id = 2, Title = "Social" },
                    new MainPageFlyoutMenuItem { Id = 3, Title = "Settings" }
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}