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

            Classes.FutureMatch futureMatch = new Classes.FutureMatch(
                new DateTime(2021, 5, 4, 9, 0, 0), "A Very Long Venu Name", "A Very Long Pool Name");

            stackLayout.Children.Add(new Layouts.FutureMatchLayout(futureMatch));
            stackLayout.Children.Add(new Layouts.FutureMatchLayout(futureMatch));
            stackLayout.Children.Add(new Layouts.FutureMatchLayout(futureMatch));
            stackLayout.Children.Add(new Layouts.FutureMatchLayout(futureMatch));
            stackLayout.Children.Add(new Layouts.FutureMatchLayout(futureMatch));

        }
    }
}