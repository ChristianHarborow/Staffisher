using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Staffisher.Layouts
{
    class PastMatchLayout : StackLayout
    {
        private string matchID;

        public PastMatchLayout(Classes.PastMatchSummary summary)
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

            this.Children.Add(new Label() { Text = summary.Date, Style = labelStyle});
            this.Children.Add(new Label() { Text = summary.Venue + " - " + summary.Pool, Style = labelStyle });
            this.Children.Add(new Label() { Text = summary.Placement, Style = labelStyle });
            this.Children.Add(new Label() { Text = summary.Weight, Style = labelStyle });
            
            Button moreDetails = new Button { Text = "More Details" };
            this.Children.Add(moreDetails);
            moreDetails.Clicked += OnMoreDetailsClicked;
        }

        private async void OnMoreDetailsClicked(object sender, EventArgs e)
        {
            //something
        }
    }
}
