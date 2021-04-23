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
    public partial class FutureMatchesPage : ContentPage
    {
        public FutureMatchesPage()
        {
            InitializeComponent();

            Classes.FutureMatchSummary summary = new Classes.FutureMatchSummary()
            { MatchID = "1332", Date = "21st of April 2021", Venue = "Old Ground", 
                Pool = "Pool Alpha", Going = 9, NotGoing = 4, UserAttending = ""};

            stackLayout.Children.Add(new Layouts.FutureMatchLayout(summary));
            stackLayout.Children.Add(new Layouts.FutureMatchLayout(summary));
            stackLayout.Children.Add(new Layouts.FutureMatchLayout(summary));
            stackLayout.Children.Add(new Layouts.FutureMatchLayout(summary));
            stackLayout.Children.Add(new Layouts.FutureMatchLayout(summary));

        }
    }
}