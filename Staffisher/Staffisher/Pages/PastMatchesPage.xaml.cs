using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Staffisher.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PastMatchesPage : ContentPage
    {
        public PastMatchesPage()
        {
            InitializeComponent();

            Classes.PastMatchSummary summary = new Classes.PastMatchSummary() 
            { MatchID = "1332", Date = "1st of April 2021", Venue = "Old Ground", Pool = "Pool Alpha", Placement = "3rd out of 10", Weight = "12Lbs 12oz" };

            stackLayout.Children.Add(new Layouts.PastMatchLayout(summary));
            stackLayout.Children.Add(new Layouts.PastMatchLayout(summary));
            stackLayout.Children.Add(new Layouts.PastMatchLayout(summary));
            stackLayout.Children.Add(new Layouts.PastMatchLayout(summary));
            stackLayout.Children.Add(new Layouts.PastMatchLayout(summary));
        }
    }
}