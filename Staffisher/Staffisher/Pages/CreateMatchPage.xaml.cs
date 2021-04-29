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
    public partial class CreateMatchPage : ContentPage
    {
        public CreateMatchPage()
        {
            InitializeComponent();

            datePicker.Date = DateTime.Today.AddDays(1);
            datePicker.MinimumDate = DateTime.Today.AddDays(1);
            datePicker.MaximumDate = DateTime.Today.AddYears(3);
        }
    }
}