using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Staffisher.Layouts
{
    class CurrentMatchLayout : MatchLayout
    {
        public CurrentMatchLayout(Classes.CurrentMatch currentMatch) : base(currentMatch)
        {
            this.Children.Add(new Label() { Text = currentMatch.HasWeighedIn() ? "You Have Weighed In" : "You Have Not Weighed In", Style = labelStyle });

            Button weighIn = new Button() 
            { Text = "Weigh In", IsEnabled = !currentMatch.HasWeighedIn(), Margin = 10, Style = buttonStyle };
            weighIn.Clicked += OnWeighInClicked;

            this.Children.Add(weighIn);

            ListView listView = new ListView
            {
                ItemsSource = currentMatch.WeighIns,
                SelectionMode = ListViewSelectionMode.None,
                ItemTemplate = new DataTemplate(() =>
                {
                    Label positionLabel = new Label()
                    { FontSize = 17, TextColor = Color.LightGray, WidthRequest = 30, HorizontalTextAlignment = TextAlignment.End };
                    positionLabel.SetBinding(Label.TextProperty, "Position");

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
            await Navigation.PushAsync(new Pages.WeighInPage());
        }
    }
}
