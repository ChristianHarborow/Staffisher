using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Staffisher.Classes;
using Staffisher.Pages;

namespace Staffisher.Layouts
{
    class PastMatchLayout : MatchLayout
    {
        private List<AnglerWeighIn> weighIns;
        public PastMatchLayout(PastMatch pastMatch) : base(pastMatch)
        {
            weighIns = pastMatch.WeighIns;
            AnglerWeighIn weighIn = pastMatch.FindWeighIn();
            string placement = pastMatch.GetPlacement(weighIn);

            this.Children.Add(new Label() { Text = placement, Style = labelStyle });

            if (placement != "Did Not Weigh In")
                this.Children.Add(new Label() { Text = pastMatch.GetWeight(weighIn), Style = labelStyle });
            
            Button scoreboardButton = new Button { Text = "Scoreboard", Style = buttonStyle };
            this.Children.Add(scoreboardButton);
            scoreboardButton.Clicked += OnScoreboardClicked;
        }

        private async void OnScoreboardClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScoreboardPage(weighIns));
        }
    }
}
