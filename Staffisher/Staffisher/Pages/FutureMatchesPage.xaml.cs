using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Staffisher.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FutureMatchesPage : ContentPage
    {
        private Button createMatchButton;

        public FutureMatchesPage()
        {
            InitializeComponent();

            if (App.User.IsAdmin)
            {
                createMatchButton = new Button() { Text = "Create Match", TextColor = Color.White ,Margin = new Thickness(5), 
                    BackgroundColor = (Color)Application.Current.Resources["accentOrange"] };

                createMatchButton.Clicked += OnCreateMatchClicked;
                mainStackLayout.Children.Insert(0, createMatchButton);
            }

            Classes.FutureMatch futureMatch = new Classes.FutureMatch(
                new DateTime(2021, 5, 4, 9, 0, 0), "A Very Long Venue Name", "A Very Long Pool Name");

            scrollStackLayout.Children.Add(new Layouts.FutureMatchLayout(futureMatch));
            scrollStackLayout.Children.Add(new Layouts.FutureMatchLayout(futureMatch));
            scrollStackLayout.Children.Add(new Layouts.FutureMatchLayout(futureMatch));
            scrollStackLayout.Children.Add(new Layouts.FutureMatchLayout(futureMatch));
            scrollStackLayout.Children.Add(new Layouts.FutureMatchLayout(futureMatch));

        }

        private async void OnCreateMatchClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateMatchPage());
        }
    }
}