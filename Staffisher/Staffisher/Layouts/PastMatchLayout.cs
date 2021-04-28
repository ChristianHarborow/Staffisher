using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Staffisher.Layouts
{
    class PastMatchLayout : MatchLayout
    {

        public PastMatchLayout(Classes.PastMatch pastMatch) : base(pastMatch)
        {
            string placement = pastMatch.GetPlacement();

            this.Children.Add(new Label() { Text = placement, Style = labelStyle });

            if (placement != "Did Not Weigh In")
                this.Children.Add(new Label() { Text = pastMatch.GetWeight(), Style = labelStyle });
            
            Button scoreboard = new Button { Text = "More Details", Style = buttonStyle };
            this.Children.Add(scoreboard);
            scoreboard.Clicked += OnScoreboardClicked;
        }

        private async void OnScoreboardClicked(object sender, EventArgs e)
        {
            //something
        }
    }
}
