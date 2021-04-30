using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Staffisher.Classes;
using Staffisher.Pages;

namespace Staffisher.Layouts
{
    class CurrentMatchLayout : MatchLayout
    {
        private CurrentMatchPage page;

        public CurrentMatchLayout(CurrentMatch currentMatch, CurrentMatchPage page) : base(currentMatch)
        {
            this.page = page;
            this.Children.Add(new Label() { Text = currentMatch.HasWeighedIn() ? "You Have Weighed In" : "You Have Not Weighed In", Style = labelStyle });
            
            StackLayout buttons = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.Center, Margin = 10 };

            Button weighInButton = new Button() 
            { Text = "Weigh In", IsEnabled = !currentMatch.HasWeighedIn(), Style = buttonStyle };
            weighInButton.Clicked += OnWeighInClicked;
            buttons.Children.Add(weighInButton);

            if (App.User.IsAdmin)
            {
                Button endMatchButton = new Button() { Text = "End Match", Style = buttonStyle };
                endMatchButton.Clicked += OnEndMatchClicked;
                buttons.Children.Add(endMatchButton);
            }

            this.Children.Add(buttons);

            ListView listView = new ListView
            {
                ItemsSource = currentMatch.WeighIns,
                SelectionMode = ListViewSelectionMode.None,
                ItemTemplate = new DataTemplate(() =>
                {
                    Label positionLabel = new Label()
                    { FontSize = 17, TextColor = Color.LightGray, WidthRequest = 30, HorizontalTextAlignment = TextAlignment.End };
                    positionLabel.SetBinding(Label.TextProperty, "Placement");

                    Label anglerLabel = new Label()
                    { FontSize = 17, TextColor = Color.LightGray, WidthRequest = 180 };
                    anglerLabel.SetBinding(Label.TextProperty, "Angler");

                    Label weightLabel = new Label()
                    { FontSize = 17, TextColor = Color.LightGray, WidthRequest = 95, HorizontalTextAlignment = TextAlignment.End };
                    weightLabel.SetBinding(Label.TextProperty, "Weight");

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            VerticalOptions = LayoutOptions.Center,
                            Spacing = 15,
                            Children = { positionLabel, anglerLabel, weightLabel }
                        }
                    };
                })
            };

            this.Children.Add(listView);
        }

        private async void OnWeighInClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WeighInPage());
        }

        private async void OnEndMatchClicked(object sender, EventArgs e)
        {
            bool endMatch = await page.DisplayAlert("End Match", "Are You Sure You Want To End The Match?", "Yes", "No");

            if (endMatch)
            {
                PastMatch pastMatch = new PastMatch(App.CurrentMatch.DateTime, App.CurrentMatch.Venue, App.CurrentMatch.Pool)
                { WeighIns = App.CurrentMatch.WeighIns };
                App.CurrentMatch = null;
                App.SerializeCurrentMatch();
                App.PastMatches.Insert(0, pastMatch);
                App.SerializePastMatches();
                page.DisplayCurrentMatch();
            }
        }
    }
}
