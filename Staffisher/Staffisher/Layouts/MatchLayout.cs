using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Staffisher.Layouts
{
    class MatchLayout : StackLayout
    {
        protected string matchID;

        protected Style labelStyle = new Style(typeof(Label))
        {
            Setters =
                {
                    new Setter { Property = Label.HorizontalOptionsProperty, Value = LayoutOptions.Center },
                    new Setter { Property = Label.FontSizeProperty, Value = 16}
                }
        };

        public MatchLayout(Classes.MatchSummary summary)
        {
            this.matchID = summary.MatchID;
            this.HorizontalOptions = LayoutOptions.Center;

            this.Children.Add(new Label() { Text = summary.Date, Style = labelStyle });
            this.Children.Add(new Label() { Text = summary.Venue + " - " + summary.Pool, Style = labelStyle });
        }
    }
}
