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
    public partial class StatsPage : ContentPage
    {
        public StatsPage()
        {
            InitializeComponent();

            PoundsAndOunces totalWeight = new PoundsAndOunces();
            PoundsAndOunces highestWeight = new PoundsAndOunces();
            int numberOfWeighIns = 0;
            int firstPlace = 0;
            int topThree = 0;

            foreach (PastMatch pastMatch in App.PastMatches)
            {
                foreach (WeighIn weighIn in pastMatch.WeighIns)
                {
                    if (weighIn.Angler.Email == App.User.Email)
                    {
                        totalWeight += weighIn.Weight;
                        highestWeight = weighIn.Weight > highestWeight ? weighIn.Weight : highestWeight;
                        numberOfWeighIns++;

                        if (weighIn.Placement <= 3)
                        {
                            topThree++;
                            if (weighIn.Placement == 1) firstPlace++;
                        }

                        break;
                    }
                }
            }

            PoundsAndOunces averageWeight = totalWeight / numberOfWeighIns;

            totalWeightLabel.Text = $"{totalWeight.Pounds} lb\n{totalWeight.Ounces} oz";
            averageWeightLabel.Text = $"{averageWeight.Pounds} lb\n{averageWeight.Ounces} oz";
            highestWeightLabel.Text = $"{highestWeight.Pounds} lb\n{highestWeight.Ounces} oz";
            numMatchesLabel.Text = $"Matches Completed: {numberOfWeighIns}";
            firstPlaceLabel.Text = $"1st Place Finishes: {firstPlace}";
            topThreeLabel.Text = $"Top 3 Finishes: {topThree}";
        }
    }
}