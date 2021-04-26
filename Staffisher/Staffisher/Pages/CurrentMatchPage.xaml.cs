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
            weighIns.Add(new Classes.AnglerWeighIn(new Classes.Angler("Christian Harborow"), new Classes.PoundsAndOunces(200, 10)));
            weighIns.Add(new Classes.AnglerWeighIn(new Classes.Angler("Christian Harborow"), new Classes.PoundsAndOunces(200, 10)));
            weighIns.Add(new Classes.AnglerWeighIn(new Classes.Angler("Christian Harborow"), new Classes.PoundsAndOunces(200, 10)));

            Classes.CurrentMatch currentMatch = new Classes.CurrentMatch(
                new DateTime(2021, 5, 4, 9, 0, 0), "A Very Long Venu Name", "A Very Long Pool Name", weighIns);

            stackLayout.Children.Add(new Layouts.CurrentMatchLayout(currentMatch));
        }
    }
}