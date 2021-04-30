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
    public partial class PastMatchesPage : ContentPage
    {
        public PastMatchesPage()
        {
            InitializeComponent();
        }

        private void DisplayPastMatches()
        {
            stackLayout.Children.Clear();

            foreach (PastMatch pastMatch in App.PastMatches)
            {
                stackLayout.Children.Add(new Layouts.PastMatchLayout(pastMatch));
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DisplayPastMatches();
        }
    }
}