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
    public partial class CurrentMatchPage : ContentPage
    {
        public CurrentMatchPage()
        {
            InitializeComponent();

            List<Classes.AnglerWeighIn> weighIns = new List<Classes.AnglerWeighIn>();
            weighIns.Add(new Classes.AnglerWeighIn() { Angler = "Christian Harborow", Weight = new Classes.PoundsAndOunces(200, 10), Position = 11 });
            weighIns.Add(new Classes.AnglerWeighIn() { Angler = "Angler2", Weight = new Classes.PoundsAndOunces(7, 8), Position = 2 });
            weighIns.Add(new Classes.AnglerWeighIn() { Angler = "Angler3", Weight = new Classes.PoundsAndOunces(7, 8), Position = 3 });

            Classes.CurrentMatchSummary summary = new Classes.CurrentMatchSummary()
            { MatchID = "1332", Date = "31st of December 2021", Venue = "A Very Long Venu Name", Pool = "A Very Long Pool Name", AnglersWeighedIn = weighIns, HasWeighedIn = false };

            stackLayout.Children.Add(new Layouts.CurrentMatchLayout(summary));
        }
    }
}