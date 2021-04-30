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
    public partial class CurrentMatchPage : ContentPage
    {
        public CurrentMatchPage()
        {
            InitializeComponent();
        }

        public void DisplayCurrentMatch()
        {
            stackLayout.Children.Clear();

            if (App.CurrentMatch == null)
            {
                Label noMatchLabel;

                if (App.User.IsAdmin)
                {
                    if (App.FutureMatches.Count == 0)
                    {
                        noMatchLabel = new Label() { Text = "There Is No Match In Progress\nAnd No Future Match Planned", 
                            Style = (Style)App.Current.Resources["centeredLabel"] };
                        stackLayout.Children.Add(noMatchLabel);
                        return;
                    }

                    Button nextMatchButton = new Button() { Text = "Start Next Match", Style = (Style)App.Current.Resources["orangeButton"] };
                    nextMatchButton.Clicked += OnStartNextMatchClicked;
                    stackLayout.Children.Add(nextMatchButton);
                    return;
                }

                noMatchLabel = new Label() { Text = "There Is No Match In Progress", Style = (Style) App.Current.Resources["centeredLabel"] };
                stackLayout.Children.Add(noMatchLabel);
                return;
            }

            stackLayout.Children.Add(new Layouts.CurrentMatchLayout(App.CurrentMatch, this));
        }

        private void OnStartNextMatchClicked(object sender, EventArgs e)
        {
            FutureMatch futureMatch = App.FutureMatches.ElementAt(0);
            App.FutureMatches.RemoveAt(0);
            App.SerializeFutureMatches();
            App.CurrentMatch = new CurrentMatch(futureMatch.DateTime, futureMatch.Venue, futureMatch.Pool);
            App.SerializeCurrentMatch();
            DisplayCurrentMatch();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DisplayCurrentMatch();
        }
    }
}