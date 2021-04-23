using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Staffisher.Layouts
{
    class CurrentMatchLayout : MatchLayout
    {
        public CurrentMatchLayout(Classes.CurrentMatchSummary summary) : base(summary)
        {
            this.Children.Add(new Label() { Text = summary.HasWeighedIn ? "You Have Weighed In" : "You Have Not Weighed In", Style = labelStyle });

            Button weighIn = new Button() 
            { Text = "Weigh In", IsEnabled = !summary.HasWeighedIn, Margin = 10, Style = buttonStyle };

            this.Children.Add(weighIn);

            ListView listView = new ListView
            {
                ItemsSource = summary.AnglersWeighedIn,
                SelectionMode = ListViewSelectionMode.None,
                ItemTemplate = new DataTemplate(() =>
                {
                    Label positionLabel = new Label()
                    { FontSize = 17, WidthRequest = 30, HorizontalTextAlignment = TextAlignment.End };
                    positionLabel.SetBinding(Label.TextProperty, "Position");

                    Label anglerLabel = new Label()
                    { FontSize = 17, WidthRequest = 180 };
                    anglerLabel.SetBinding(Label.TextProperty, "Angler");

                    Label weightLabel = new Label()
                    { FontSize = 17, WidthRequest = 95, HorizontalTextAlignment = TextAlignment.End };
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
    }
}
