using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Staffisher.Layouts
{
    class FutureMatchLayout : MatchLayout
    {
        private string attending;
        private Button going;
        private Button maybe;
        private Button notGoing;

        public FutureMatchLayout(Classes.FutureMatchSummary summary) : base(summary)
        {
            attending = summary.Attending;

            this.Children.Add(new Label() { Text = summary.Going + " Going", Style = labelStyle });
            this.Children.Add(new Label() { Text = summary.MaybeGoing + " Maybe Going", Style = labelStyle });
            this.Children.Add(new Label() { Text = summary.NotGoing + " Not Going", Style = labelStyle });

            StackLayout buttons = new StackLayout() { Orientation = StackOrientation.Horizontal };

            going = new Button() { Text = "Going", IsEnabled = attending != "Going", Style = buttonStyle };
            maybe = new Button() { Text = "Maybe", IsEnabled = attending != "Maybe", Style = buttonStyle };
            notGoing = new Button() { Text = "Not Going", IsEnabled = attending != "Not Going", Style = buttonStyle };

            going.Clicked += OnAttendenceButtonClicked;
            maybe.Clicked += OnAttendenceButtonClicked;
            notGoing.Clicked += OnAttendenceButtonClicked;

            buttons.Children.Add(going);
            buttons.Children.Add(maybe);
            buttons.Children.Add(notGoing);
            
            this.Children.Add(buttons);
        }

        private void OnAttendenceButtonClicked(object sender, EventArgs e)
        {
            if (sender == going)
            {
                attending = "Going";
                going.IsEnabled = false;
                maybe.IsEnabled = true;
                notGoing.IsEnabled = true;
            }
            else if (sender == maybe)
            {
                attending = "Maybe";
                going.IsEnabled = true;
                maybe.IsEnabled = false;
                notGoing.IsEnabled = true;
            }
            else if (sender == notGoing)
            {
                attending = "Not Going";
                going.IsEnabled = true;
                maybe.IsEnabled = true;
                notGoing.IsEnabled = false;
            }
        }
    }
}
