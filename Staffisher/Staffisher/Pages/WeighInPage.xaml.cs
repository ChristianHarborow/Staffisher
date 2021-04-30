using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Staffisher.Classes;

namespace Staffisher.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeighInPage : ContentPage
    {
        public WeighInPage()
        {
            InitializeComponent();
        }

        private async void OnWeighInClicked(object sender, EventArgs e)
        {
            string poundsString = poundsEntry.Text.Trim();
            string ouncesString = ouncesEntry.Text.Trim();

            if (poundsString.Length == 0 || ouncesString.Length == 0)
            {
                errorLabel.Text = "Both Fields Must Be Filled";
                return;
            }

            int pounds, ounces;
            
            if (!Int32.TryParse(poundsString, out pounds) || !Int32.TryParse(ouncesString, out ounces))
            {
                errorLabel.Text = "Invalid Entry";
                return;
            }

            if (pounds < 0 || ounces < 0 || ounces > 15)
            {
                errorLabel.Text = "Invalid Entry";
                return;
            }

            WeighIn weighIn = new WeighIn(App.User, new PoundsAndOunces(pounds, ounces));
            App.CurrentMatch.WeighIns.Add(weighIn);
            App.CurrentMatch.WeighIns.Sort(SortWeighInsByWeight);
            
            for (int i = 0; i < App.CurrentMatch.WeighIns.Count; i++)
            {
                App.CurrentMatch.WeighIns.ElementAt(i).Placement = i + 1;
            }

            App.SerializeCurrentMatch();
            await Navigation.PopAsync();
        }

        private static int SortWeighInsByWeight(WeighIn x, WeighIn y)
        {
            return y.Weight.CompareTo(x.Weight);
        }
    }
}