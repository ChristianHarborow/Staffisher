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
    public partial class CreateMatchPage : ContentPage
    {
        public CreateMatchPage()
        {
            InitializeComponent();

            datePicker.Date = DateTime.Today.AddDays(1);
            datePicker.MinimumDate = DateTime.Today.AddDays(1);
            datePicker.MaximumDate = DateTime.Today.AddYears(3);
        }

        private async void OnCreateClicked(object sender, EventArgs e)
        {
            string venue = venueEntry.Text.Trim();
            string pool = poolEntry.Text.Trim();

            if (venue.Length == 0 || pool.Length == 0)
            {
                errorLabel.Text = "All Fields Must Be Filled";
                return;
            }

            DateTime dateTime = datePicker.Date + timePicker.Time;
            FutureMatch futureMatch = new FutureMatch(dateTime, venue, pool);
            App.FutureMatches.Add(futureMatch);
            App.FutureMatches.Sort(CompareMatchesByDateTime);
            App.SerializeFutureMatches();

            await Navigation.PopAsync();
        }

        private static int CompareMatchesByDateTime(FutureMatch x, FutureMatch y)
        {
            return x.DateTime.CompareTo(y.DateTime);
        }
    }
}