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
                    Label positionLabel = new Label();
                    positionLabel.SetBinding(Label.TextProperty, "Position");
                    positionLabel.FontSize = 17;
                    positionLabel.WidthRequest = 30;
                    positionLabel.HorizontalTextAlignment = TextAlignment.End;

                    Label anglerLabel = new Label();
                    anglerLabel.SetBinding(Label.TextProperty, "Angler");
                    anglerLabel.FontSize = 17;
                    anglerLabel.WidthRequest = 180;

                    Label weightLabel = new Label();
                    weightLabel.SetBinding(Label.TextProperty, "Weight");
                    weightLabel.FontSize = 17;
                    weightLabel.WidthRequest = 95;
                    weightLabel.HorizontalTextAlignment = TextAlignment.Center;

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
