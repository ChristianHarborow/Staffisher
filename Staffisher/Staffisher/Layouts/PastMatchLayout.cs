using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Staffisher.Layouts
{
    class PastMatchLayout : MatchLayout
    {

        public PastMatchLayout(Classes.PastMatchSummary summary) : base(summary)
        {
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
