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
                    new Setter { Property = Label.HorizontalTextAlignmentProperty, Value = TextAlignment.Center },
                    new Setter { Property = Label.FontSizeProperty, Value = 17}
                }
        };

        protected Style buttonStyle = new Style(typeof(Button))
        {
            Setters =
                {
                    new Setter { Property = Button.BackgroundColorProperty, Value = (Color)Application.Current.Resources["accentOrange"] },
                    new Setter { Property = Button.HorizontalOptionsProperty, Value = LayoutOptions.Center },
                    new Setter { Property = Button.HeightRequestProperty, Value = 40 },
                    new Setter { Property = Button.MarginProperty, Value = 5 }
                }
        };

        public MatchLayout(Classes.MatchSummary summary)
        {
            this.matchID = summary.MatchID;
            this.HorizontalOptions = LayoutOptions.Center;

            this.Children.Add(new Label() { Text = summary.Date, Style = labelStyle });
            this.Children.Add(new Label() { Text = summary.Venue + " - " + summary.Pool, Style = labelStyle, LineBreakMode = LineBreakMode.WordWrap });
        }
    }
}
