using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Staffisher.Classes;

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
        }

        private void DisplayFutureMatches()
        {
            scrollStackLayout.Children.Clear();
            
            if (App.FutureMatches.Count == 0)
            {
                Label label = new Label() { Text = "There Are No Future Matches Planned", Style = (Style) App.Current.Resources["centeredLabel"] };
                scrollStackLayout.Children.Add(label);
                return;
            }

            foreach (FutureMatch futureMatch in App.FutureMatches)
            {
                scrollStackLayout.Children.Add(new Layouts.FutureMatchLayout(futureMatch));
            }
        }

        private async void OnCreateMatchClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateMatchPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DisplayFutureMatches();
        }
    }
}