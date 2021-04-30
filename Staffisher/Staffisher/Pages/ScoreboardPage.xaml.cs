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

    public partial class ScoreboardPage : ContentPage
    {
        public ScoreboardPage(List<WeighIn> weighIns)
        {
            InitializeComponent();

            listView.ItemsSource = weighIns;
        }
    }
}