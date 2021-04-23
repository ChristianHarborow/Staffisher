using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Staffisher.Layouts
{
    class FutureMatchLayout : MatchLayout
    {
        private string userAttending;
        private Button goingButton;
        private Button notGoingButton;
        private Label goingLabel;
        private Label notGoingLabel;
        private int going;
        private int notGoing;

        public FutureMatchLayout(Classes.FutureMatchSummary summary) : base(summary)
        {
            userAttending = summary.UserAttending;
            going = summary.Going;
            notGoing = summary.NotGoing;

            goingLabel = new Label() { Text = going + " Going", Style = labelStyle };
            notGoingLabel = new Label() { Text = notGoing + " Not Going", Style = labelStyle };

            this.Children.Add(goingLabel);
            this.Children.Add(notGoingLabel);

            StackLayout buttons = new StackLayout() { Orientation = StackOrientation.Horizontal };

            goingButton = new Button() { Text = "Going", IsEnabled = userAttending != "Going", Style = buttonStyle };
            notGoingButton = new Button() { Text = "Not Going", IsEnabled = userAttending != "Not Going", Style = buttonStyle };

            goingButton.Clicked += OnAttendenceButtonClicked;
            notGoingButton.Clicked += OnAttendenceButtonClicked;

            buttons.Children.Add(goingButton);
            buttons.Children.Add(notGoingButton);
            
            this.Children.Add(buttons);
        }

        private void OnAttendenceButtonClicked(object sender, EventArgs e)
        {
            if (userAttending == "Going") going--;
            else if (userAttending == "Not Going") notGoing--;

            if (sender == goingButton)
            {
                userAttending = "Going";
                goingButton.IsEnabled = false;
                notGoingButton.IsEnabled = true;
                going++;
            }
            else if (sender == notGoingButton)
            {
                userAttending = "Not Going";
                goingButton.IsEnabled = true;
                notGoingButton.IsEnabled = false;
                notGoing++;
            }

            goingLabel.Text = going + " Going";
            notGoingLabel.Text = notGoing + " Not Going";
        }
    }
}
