using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Staffisher.Layouts
{
    class FutureMatchLayout : StackLayout
    {
        private string matchID;
        public FutureMatchLayout(Classes.FutureMatchSummary summary)
        {
            this.matchID = summary.MatchID;
            this.HorizontalOptions = LayoutOptions.Center;

            Style labelStyle = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter { Property = Label.HorizontalOptionsProperty, Value = LayoutOptions.Center },
                    new Setter { Property = Label.FontSizeProperty, Value = 16}
                }
            };

            this.Children.Add(new Label() { Text = summary.Date, Style = labelStyle });
            this.Children.Add(new Label() { Text = summary.Venue + " - " + summary.Pool, Style = labelStyle });
            this.Children.Add(new Label() { Text = summary.Going + " Going", Style = labelStyle });
            this.Children.Add(new Label() { Text = summary.MaybeGoing + " Maybe Going", Style = labelStyle });
            this.Children.Add(new Label() { Text = summary.NotGoing + " Not Going", Style = labelStyle });

            StackLayout buttons = new StackLayout() { Orientation = StackOrientation.Horizontal };
            Button going = new Button() { Text = "Going" };
            Button maybe = new Button() { Text = "Maybe" };
            Button notGoing = new Button() { Text = "Not Going" };
            buttons.Children.Add(going);
            buttons.Children.Add(maybe);
            buttons.Children.Add(notGoing);
            this.Children.Add(buttons);
        }
    }
}
