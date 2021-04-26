using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Staffisher.Layouts
{
    class FutureMatchLayout : MatchLayout
    {
        private Classes.FutureMatch futureMatch;
        private Button attendingButton;
        private Button notAttendingButton;
        
        private Label attendingLabel;
        private Label notAttendingLabel;

        public FutureMatchLayout(Classes.FutureMatch futureMatch) : base(futureMatch)
        {
            this.futureMatch = futureMatch;

            attendingLabel = new Label() { Text = futureMatch.Attending.Count + " Attending", Style = labelStyle };
            notAttendingLabel = new Label() { Text = futureMatch.NotAttending.Count + " Not Attending", Style = labelStyle };

            this.Children.Add(attendingLabel);
            this.Children.Add(notAttendingLabel);

            StackLayout buttons = new StackLayout() { Orientation = StackOrientation.Horizontal };
            buttons.HorizontalOptions = LayoutOptions.Center;

            attendingButton = new Button() { Text = "Attending", IsEnabled = futureMatch.IsAnglerAttending() != "Attending", Style = buttonStyle };
            notAttendingButton = new Button() { Text = "Not Attending", IsEnabled = futureMatch.IsAnglerAttending() != "Not Attending", Style = buttonStyle };

            attendingButton.Clicked += OnAttendenceButtonClicked;
            notAttendingButton.Clicked += OnAttendenceButtonClicked;

            buttons.Children.Add(attendingButton);
            buttons.Children.Add(notAttendingButton);
            
            this.Children.Add(buttons);
        }

        private void OnAttendenceButtonClicked(object sender, EventArgs e)
        {
            bool attending = sender == attendingButton;
            futureMatch.SetAnglerAttendance(attending);
            
            attendingButton.IsEnabled = !attending;
            notAttendingButton.IsEnabled = attending;
            
            attendingLabel.Text = futureMatch.Attending.Count + " Attending";
            notAttendingLabel.Text = futureMatch.NotAttending.Count + " Not Attending";
        }
    }
}
